using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ImprovedFingerprint.Models;
using ImprovedFingerprint.Helpers;

namespace ImprovedFingerprint.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService()
        {
            _connectionString = AppSettings.GetConnectionString("cn");
        }

        #region Employee Operations

        public List<Employee> GetAllEmployees()
        {
            var employees = new List<Employee>();
            const string query = @"
                SELECT EmployeeId, EmployeeNumber, FullName, Department, Position, 
                       HireDate, PhoneNumber, Email, IsActive, DeviceUserId, 
                       CreatedDate, ModifiedDate, Notes, Shift
                FROM Employees 
                ORDER BY FullName";

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                employees.Add(new Employee
                                {
                                    EmployeeId = reader.GetInt32("EmployeeId"),
                                    EmployeeNumber = reader.GetString("EmployeeNumber"),
                                    FullName = reader.GetString("FullName"),
                                    Department = reader.IsDBNull("Department") ? "" : reader.GetString("Department"),
                                    Position = reader.IsDBNull("Position") ? "" : reader.GetString("Position"),
                                    HireDate = reader.GetDateTime("HireDate"),
                                    PhoneNumber = reader.IsDBNull("PhoneNumber") ? "" : reader.GetString("PhoneNumber"),
                                    Email = reader.IsDBNull("Email") ? "" : reader.GetString("Email"),
                                    IsActive = reader.GetBoolean("IsActive"),
                                    DeviceUserId = reader.GetInt32("DeviceUserId"),
                                    CreatedDate = reader.GetDateTime("CreatedDate"),
                                    ModifiedDate = reader.IsDBNull("ModifiedDate") ? null : (DateTime?)reader.GetDateTime("ModifiedDate"),
                                    Notes = reader.IsDBNull("Notes") ? "" : reader.GetString("Notes"),
                                    Shift = reader.IsDBNull("Shift") ? "" : reader.GetString("Shift")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"خطأ في قراءة بيانات الموظفين من قاعدة البيانات: {ex.Message}");
            }

            return employees;
        }

        public bool InsertEmployee(Employee employee)
        {
            const string query = @"
                INSERT INTO Employees (EmployeeNumber, FullName, Department, Position, 
                                     HireDate, PhoneNumber, Email, IsActive, DeviceUserId, 
                                     CreatedDate, Notes, Shift)
                VALUES (@EmployeeNumber, @FullName, @Department, @Position, 
                        @HireDate, @PhoneNumber, @Email, @IsActive, @DeviceUserId, 
                        @CreatedDate, @Notes, @Shift)";

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeNumber", employee.EmployeeNumber);
                        command.Parameters.AddWithValue("@FullName", employee.FullName);
                        command.Parameters.AddWithValue("@Department", employee.Department ?? "");
                        command.Parameters.AddWithValue("@Position", employee.Position ?? "");
                        command.Parameters.AddWithValue("@HireDate", employee.HireDate);
                        command.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber ?? "");
                        command.Parameters.AddWithValue("@Email", employee.Email ?? "");
                        command.Parameters.AddWithValue("@IsActive", employee.IsActive);
                        command.Parameters.AddWithValue("@DeviceUserId", employee.DeviceUserId);
                        command.Parameters.AddWithValue("@CreatedDate", employee.CreatedDate);
                        command.Parameters.AddWithValue("@Notes", employee.Notes ?? "");
                        command.Parameters.AddWithValue("@Shift", employee.Shift ?? "");

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"خطأ في إضافة الموظف: {ex.Message}");
            }
        }

        public bool UpdateEmployee(Employee employee)
        {
            const string query = @"
                UPDATE Employees SET 
                    FullName = @FullName, Department = @Department, Position = @Position,
                    HireDate = @HireDate, PhoneNumber = @PhoneNumber, Email = @Email,
                    IsActive = @IsActive, ModifiedDate = @ModifiedDate, Notes = @Notes,
                    Shift = @Shift
                WHERE EmployeeId = @EmployeeId";

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                        command.Parameters.AddWithValue("@FullName", employee.FullName);
                        command.Parameters.AddWithValue("@Department", employee.Department ?? "");
                        command.Parameters.AddWithValue("@Position", employee.Position ?? "");
                        command.Parameters.AddWithValue("@HireDate", employee.HireDate);
                        command.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber ?? "");
                        command.Parameters.AddWithValue("@Email", employee.Email ?? "");
                        command.Parameters.AddWithValue("@IsActive", employee.IsActive);
                        command.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
                        command.Parameters.AddWithValue("@Notes", employee.Notes ?? "");
                        command.Parameters.AddWithValue("@Shift", employee.Shift ?? "");

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"خطأ في تحديث بيانات الموظف: {ex.Message}");
            }
        }

        public bool EmployeeExists(string employeeNumber)
        {
            const string query = "SELECT COUNT(*) FROM Employees WHERE EmployeeNumber = @EmployeeNumber";

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeNumber", employeeNumber);
                        return (int)command.ExecuteScalar() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"خطأ في التحقق من وجود الموظف: {ex.Message}");
            }
        }

        #endregion

        #region Attendance Operations

        public bool InsertAttendanceRecord(AttendanceRecord record)
        {
            const string query = @"
                INSERT INTO AttendanceRecords (EmployeeNumber, EmployeeName, AttendanceDateTime, 
                                             Type, Source, DeviceId, Notes, IsProcessed, 
                                             CreatedDate, Shift)
                VALUES (@EmployeeNumber, @EmployeeName, @AttendanceDateTime, 
                        @Type, @Source, @DeviceId, @Notes, @IsProcessed, 
                        @CreatedDate, @Shift)";

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeNumber", record.EmployeeNumber);
                        command.Parameters.AddWithValue("@EmployeeName", record.EmployeeName ?? "");
                        command.Parameters.AddWithValue("@AttendanceDateTime", record.AttendanceDateTime);
                        command.Parameters.AddWithValue("@Type", (int)record.Type);
                        command.Parameters.AddWithValue("@Source", (int)record.Source);
                        command.Parameters.AddWithValue("@DeviceId", record.DeviceId ?? "");
                        command.Parameters.AddWithValue("@Notes", record.Notes ?? "");
                        command.Parameters.AddWithValue("@IsProcessed", record.IsProcessed);
                        command.Parameters.AddWithValue("@CreatedDate", record.CreatedDate);
                        command.Parameters.AddWithValue("@Shift", record.Shift ?? "");

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"خطأ في إدراج سجل الحضور: {ex.Message}");
            }
        }

        public List<AttendanceRecord> GetAttendanceRecords(DateTime fromDate, DateTime toDate)
        {
            var records = new List<AttendanceRecord>();
            const string query = @"
                SELECT ar.*, e.FullName as EmployeeName
                FROM AttendanceRecords ar
                LEFT JOIN Employees e ON ar.EmployeeNumber = e.EmployeeNumber
                WHERE ar.AttendanceDateTime BETWEEN @FromDate AND @ToDate
                ORDER BY ar.AttendanceDateTime DESC";

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FromDate", fromDate);
                        command.Parameters.AddWithValue("@ToDate", toDate.AddDays(1).AddSeconds(-1));

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                records.Add(new AttendanceRecord
                                {
                                    RecordId = reader.GetInt32("RecordId"),
                                    EmployeeNumber = reader.GetString("EmployeeNumber"),
                                    EmployeeName = reader.IsDBNull("EmployeeName") ? "" : reader.GetString("EmployeeName"),
                                    AttendanceDateTime = reader.GetDateTime("AttendanceDateTime"),
                                    Type = (AttendanceType)reader.GetInt32("Type"),
                                    Source = (AttendanceSource)reader.GetInt32("Source"),
                                    DeviceId = reader.IsDBNull("DeviceId") ? "" : reader.GetString("DeviceId"),
                                    Notes = reader.IsDBNull("Notes") ? "" : reader.GetString("Notes"),
                                    IsProcessed = reader.GetBoolean("IsProcessed"),
                                    CreatedDate = reader.GetDateTime("CreatedDate"),
                                    Shift = reader.IsDBNull("Shift") ? "" : reader.GetString("Shift")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"خطأ في قراءة سجلات الحضور: {ex.Message}");
            }

            return records;
        }

        #endregion

        #region Time Settings Operations

        public List<TimeSettings> GetTimeSettings()
        {
            var settings = new List<TimeSettings>();
            const string query = @"
                SELECT SettingId, ShiftName, CheckInStartTime, CheckInEndTime, 
                       CheckOutStartTime, CheckOutEndTime, IsActive, CreatedDate, 
                       ModifiedDate, Notes
                FROM TimeSettings 
                WHERE IsActive = 1
                ORDER BY ShiftName";

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                settings.Add(new TimeSettings
                                {
                                    SettingId = reader.GetInt32("SettingId"),
                                    ShiftName = reader.GetString("ShiftName"),
                                    CheckInStartTime = reader.GetTimeSpan("CheckInStartTime"),
                                    CheckInEndTime = reader.GetTimeSpan("CheckInEndTime"),
                                    CheckOutStartTime = reader.GetTimeSpan("CheckOutStartTime"),
                                    CheckOutEndTime = reader.GetTimeSpan("CheckOutEndTime"),
                                    IsActive = reader.GetBoolean("IsActive"),
                                    CreatedDate = reader.GetDateTime("CreatedDate"),
                                    ModifiedDate = reader.IsDBNull("ModifiedDate") ? null : (DateTime?)reader.GetDateTime("ModifiedDate"),
                                    Notes = reader.IsDBNull("Notes") ? "" : reader.GetString("Notes")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"خطأ في قراءة إعدادات الأوقات: {ex.Message}");
            }

            return settings;
        }

        public bool SaveTimeSettings(TimeSettings settings)
        {
            const string query = @"
                IF EXISTS (SELECT 1 FROM TimeSettings WHERE SettingId = @SettingId)
                    UPDATE TimeSettings SET 
                        ShiftName = @ShiftName,
                        CheckInStartTime = @CheckInStartTime,
                        CheckInEndTime = @CheckInEndTime,
                        CheckOutStartTime = @CheckOutStartTime,
                        CheckOutEndTime = @CheckOutEndTime,
                        ModifiedDate = @ModifiedDate,
                        Notes = @Notes
                    WHERE SettingId = @SettingId
                ELSE
                    INSERT INTO TimeSettings (ShiftName, CheckInStartTime, CheckInEndTime, 
                                            CheckOutStartTime, CheckOutEndTime, IsActive, 
                                            CreatedDate, Notes)
                    VALUES (@ShiftName, @CheckInStartTime, @CheckInEndTime, 
                            @CheckOutStartTime, @CheckOutEndTime, @IsActive, 
                            @CreatedDate, @Notes)";

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SettingId", settings.SettingId);
                        command.Parameters.AddWithValue("@ShiftName", settings.ShiftName);
                        command.Parameters.AddWithValue("@CheckInStartTime", settings.CheckInStartTime);
                        command.Parameters.AddWithValue("@CheckInEndTime", settings.CheckInEndTime);
                        command.Parameters.AddWithValue("@CheckOutStartTime", settings.CheckOutStartTime);
                        command.Parameters.AddWithValue("@CheckOutEndTime", settings.CheckOutEndTime);
                        command.Parameters.AddWithValue("@IsActive", settings.IsActive);
                        command.Parameters.AddWithValue("@CreatedDate", settings.CreatedDate);
                        command.Parameters.AddWithValue("@ModifiedDate", DateTime.Now);
                        command.Parameters.AddWithValue("@Notes", settings.Notes ?? "");

                        return command.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"خطأ في حفظ إعدادات الأوقات: {ex.Message}");
            }
        }

        #endregion

        #region User Authentication

        public string AuthenticateUser(string username, string password)
        {
            const string query = "SELECT Role FROM UserType WHERE Username = @Username AND Password = @Password";

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        var result = command.ExecuteScalar();
                        return result?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"خطأ في التحقق من المستخدم: {ex.Message}");
            }
        }

        #endregion

        public bool TestConnection()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    return connection.State == ConnectionState.Open;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}