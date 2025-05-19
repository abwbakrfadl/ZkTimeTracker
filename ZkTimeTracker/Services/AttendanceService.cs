using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ZKTecoAttendanceSystem.Models;

namespace ZKTecoAttendanceSystem.Services
{
    /// <summary>
    /// Service for managing attendance records
    /// </summary>
    public class AttendanceService
    {
        private readonly string _connectionString;
        
        /// <summary>
        /// Initializes a new instance of the AttendanceService class
        /// </summary>
        public AttendanceService()
        {
            // Get connection string from app.config or default to local database
            _connectionString = ConfigurationManager.ConnectionStrings["ZKTecoAttendanceDB"]?.ConnectionString
                ?? @"Data Source=.\SQLEXPRESS;Initial Catalog=ZKTecoAttendanceDB;Integrated Security=True";
        }
        
        /// <summary>
        /// Gets attendance records from the database based on criteria
        /// </summary>
        /// <param name="fromDate">Start date for records</param>
        /// <param name="toDate">End date for records</param>
        /// <param name="employeeId">Employee ID filter (optional)</param>
        /// <returns>A list of attendance records</returns>
        public List<AttendanceRecord> GetAttendanceRecords(DateTime fromDate, DateTime toDate, int? employeeId = null)
        {
            List<AttendanceRecord> records = new List<AttendanceRecord>();
            
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    
                    string query = @"
                        SELECT * FROM AttendanceRecords 
                        WHERE RecordTime BETWEEN @FromDate AND @ToDate";
                    
                    if (employeeId.HasValue)
                    {
                        query += " AND EmployeeId = @EmployeeId";
                    }
                    
                    query += " ORDER BY RecordTime DESC";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FromDate", fromDate);
                        command.Parameters.AddWithValue("@ToDate", toDate);
                        
                        if (employeeId.HasValue)
                        {
                            command.Parameters.AddWithValue("@EmployeeId", employeeId.Value);
                        }
                        
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                records.Add(new AttendanceRecord
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                                    RecordTime = Convert.ToDateTime(reader["RecordTime"]),
                                    RecordType = (AttendanceType)Convert.ToInt32(reader["RecordType"]),
                                    VerifyMode = Convert.ToInt32(reader["VerifyMode"]),
                                    WorkCode = Convert.ToInt32(reader["WorkCode"]),
                                    CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                                    IsProcessed = Convert.ToBoolean(reader["IsProcessed"])
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving attendance records: " + ex.Message);
            }
            
            return records;
        }
        
        /// <summary>
        /// Gets daily attendance summary by employee
        /// </summary>
        /// <param name="date">The date to get summary for</param>
        /// <returns>A DataTable with the summary</returns>
        public DataTable GetDailyAttendanceSummary(DateTime date)
        {
            DataTable dt = new DataTable();
            
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    
                    string query = @"
                        SELECT 
                            e.EmployeeId,
                            e.Name,
                            e.Department,
                            MIN(CASE WHEN a.RecordType = 0 THEN a.RecordTime ELSE NULL END) AS FirstCheckIn,
                            MAX(CASE WHEN a.RecordType = 1 THEN a.RecordTime ELSE NULL END) AS LastCheckOut,
                            DATEDIFF(MINUTE, 
                                MIN(CASE WHEN a.RecordType = 0 THEN a.RecordTime ELSE NULL END), 
                                MAX(CASE WHEN a.RecordType = 1 THEN a.RecordTime ELSE NULL END)) AS MinutesWorked
                        FROM AttendanceRecords a
                        JOIN Employees e ON a.EmployeeId = e.EmployeeId
                        WHERE CONVERT(DATE, a.RecordTime) = @Date
                        GROUP BY e.EmployeeId, e.Name, e.Department
                        ORDER BY e.EmployeeId";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Date", date.Date);
                        
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error generating daily attendance summary: " + ex.Message);
            }
            
            return dt;
        }
        
        /// <summary>
        /// Saves attendance records to the database
        /// </summary>
        /// <param name="records">The records to save</param>
        /// <returns>The number of records saved</returns>
        public int SaveAttendanceRecords(List<AttendanceRecord> records)
        {
            int savedCount = 0;
            
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    
                    // Begin a transaction to ensure all records are saved atomically
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Insert query
                            string query = @"
                                IF NOT EXISTS (
                                    SELECT 1 FROM AttendanceRecords 
                                    WHERE EmployeeId = @EmployeeId AND RecordTime = @RecordTime
                                )
                                BEGIN
                                    INSERT INTO AttendanceRecords (
                                        EmployeeId, RecordTime, RecordType, VerifyMode, WorkCode, CreatedDate, IsProcessed
                                    ) VALUES (
                                        @EmployeeId, @RecordTime, @RecordType, @VerifyMode, @WorkCode, @CreatedDate, @IsProcessed
                                    );
                                    SELECT SCOPE_IDENTITY();
                                END
                                ELSE
                                BEGIN
                                    SELECT 0;
                                END";
                            
                            foreach (var record in records)
                            {
                                using (SqlCommand command = new SqlCommand(query, connection, transaction))
                                {
                                    command.Parameters.AddWithValue("@EmployeeId", record.EmployeeId);
                                    command.Parameters.AddWithValue("@RecordTime", record.RecordTime);
                                    command.Parameters.AddWithValue("@RecordType", (int)record.RecordType);
                                    command.Parameters.AddWithValue("@VerifyMode", record.VerifyMode);
                                    command.Parameters.AddWithValue("@WorkCode", record.WorkCode);
                                    command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                                    command.Parameters.AddWithValue("@IsProcessed", record.IsProcessed);
                                    
                                    object result = command.ExecuteScalar();
                                    
                                    if (result != null && result != DBNull.Value)
                                    {
                                        int id = Convert.ToInt32(result);
                                        
                                        if (id > 0)
                                        {
                                            record.Id = id;
                                            savedCount++;
                                        }
                                    }
                                }
                            }
                            
                            // Commit the transaction if all records were processed
                            transaction.Commit();
                        }
                        catch
                        {
                            // Rollback the transaction if an error occurred
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error saving attendance records: " + ex.Message);
            }
            
            return savedCount;
        }
        
        /// <summary>
        /// Updates the type of an attendance record
        /// </summary>
        /// <param name="id">The record ID</param>
        /// <param name="recordType">The new record type</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool UpdateAttendanceRecordType(int id, AttendanceType recordType)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    
                    string query = @"
                        UPDATE AttendanceRecords 
                        SET RecordType = @RecordType, IsProcessed = 1 
                        WHERE Id = @Id";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.Parameters.AddWithValue("@RecordType", (int)recordType);
                        
                        int rowsAffected = command.ExecuteNonQuery();
                        
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating attendance record: " + ex.Message);
            }
        }
        
        /// <summary>
        /// Deletes attendance records from the database
        /// </summary>
        /// <param name="recordIds">The IDs of the records to delete</param>
        /// <returns>The number of records deleted</returns>
        public int DeleteAttendanceRecords(List<int> recordIds)
        {
            int deletedCount = 0;
            
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    
                    // Begin a transaction to ensure all deletions are atomic
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string query = "DELETE FROM AttendanceRecords WHERE Id = @Id";
                            
                            foreach (int id in recordIds)
                            {
                                using (SqlCommand command = new SqlCommand(query, connection, transaction))
                                {
                                    command.Parameters.AddWithValue("@Id", id);
                                    
                                    int rowsAffected = command.ExecuteNonQuery();
                                    
                                    if (rowsAffected > 0)
                                    {
                                        deletedCount++;
                                    }
                                }
                            }
                            
                            // Commit the transaction if all deletions were successful
                            transaction.Commit();
                        }
                        catch
                        {
                            // Rollback the transaction if an error occurred
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting attendance records: " + ex.Message);
            }
            
            return deletedCount;
        }
        
        /// <summary>
        /// Classifies an attendance record based on time settings
        /// </summary>
        /// <param name="record">The attendance record to classify</param>
        /// <param name="settings">The time settings to use for classification</param>
        /// <returns>The classified attendance type</returns>
        public AttendanceType ClassifyAttendanceRecord(AttendanceRecord record, TimeSettings settings)
        {
            // Extract just the time part for comparison
            TimeSpan recordTime = record.RecordTime.TimeOfDay;
            
            // Check if the time falls within morning shift
            if (recordTime < settings.MorningShiftStart.Add(settings.LateArrivalThreshold))
            {
                return AttendanceType.CheckIn; // Early check-in
            }
            else if (recordTime >= settings.MorningShiftStart && recordTime <= settings.MorningShiftEnd)
            {
                // If closer to start, it's check-in, otherwise it's check-out
                TimeSpan diffToStart = recordTime - settings.MorningShiftStart;
                TimeSpan diffToEnd = settings.MorningShiftEnd - recordTime;
                
                return diffToStart < diffToEnd ? AttendanceType.CheckIn : AttendanceType.BreakStart;
            }
            else if (recordTime > settings.MorningShiftEnd && recordTime < settings.AfternoonShiftStart)
            {
                return AttendanceType.BreakStart; // Break time
            }
            else if (recordTime >= settings.AfternoonShiftStart && recordTime <= settings.AfternoonShiftEnd)
            {
                // If closer to start, it's break-end, otherwise it's check-out
                TimeSpan diffToStart = recordTime - settings.AfternoonShiftStart;
                TimeSpan diffToEnd = settings.AfternoonShiftEnd - recordTime;
                
                return diffToStart < diffToEnd ? AttendanceType.BreakEnd : AttendanceType.CheckOut;
            }
            else if (recordTime > settings.AfternoonShiftEnd && 
                    recordTime < settings.AfternoonShiftEnd.Add(settings.EarlyDepartureThreshold))
            {
                return AttendanceType.CheckOut; // Regular check-out
            }
            else if (recordTime >= settings.OvertimeStart)
            {
                return AttendanceType.OvertimeEnd; // Overtime
            }
            
            return AttendanceType.Unknown;
        }
    }
}