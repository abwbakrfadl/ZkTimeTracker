using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ZKTecoAttendanceSystem.Models;

namespace ZKTecoAttendanceSystem.Services
{
    /// <summary>
    /// Service for managing application settings
    /// </summary>
    public class SettingsService
    {
        private readonly string _connectionString;
        
        /// <summary>
        /// Initializes a new instance of the SettingsService class
        /// </summary>
        public SettingsService()
        {
            // Get connection string from app.config or default to local database
            _connectionString = ConfigurationManager.ConnectionStrings["ZKTecoAttendanceDB"]?.ConnectionString
                ?? @"Data Source=.\SQLEXPRESS;Initial Catalog=ZKTecoAttendanceDB;Integrated Security=True";
        }
        
        /// <summary>
        /// Gets the connection settings from the database
        /// </summary>
        /// <returns>The connection settings or null if not found</returns>
        public ConnectionSettings GetConnectionSettings()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    
                    string query = "SELECT TOP 1 * FROM ConnectionSettings ORDER BY LastModified DESC";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new ConnectionSettings
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    IPAddress = reader["IPAddress"].ToString(),
                                    Port = Convert.ToInt32(reader["Port"]),
                                    Password = reader["Password"].ToString(),
                                    AutoConnect = Convert.ToBoolean(reader["AutoConnect"]),
                                    LastConnected = reader["LastConnected"] != DBNull.Value 
                                        ? Convert.ToDateTime(reader["LastConnected"]) 
                                        : (DateTime?)null,
                                    LastModified = Convert.ToDateTime(reader["LastModified"])
                                };
                            }
                        }
                    }
                }
                
                return null;
            }
            catch (Exception)
            {
                // If database not accessible, return default settings
                return new ConnectionSettings
                {
                    IPAddress = "192.168.1.201",
                    Port = 4370,
                    Password = "",
                    AutoConnect = false,
                    LastModified = DateTime.Now
                };
            }
        }
        
        /// <summary>
        /// Saves connection settings to the database
        /// </summary>
        /// <param name="settings">The connection settings to save</param>
        public void SaveConnectionSettings(ConnectionSettings settings)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    
                    // Check if settings already exist
                    string checkQuery = "SELECT COUNT(*) FROM ConnectionSettings WHERE Id = @Id";
                    bool exists = false;
                    
                    if (settings.Id > 0)
                    {
                        using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                        {
                            checkCommand.Parameters.AddWithValue("@Id", settings.Id);
                            exists = (int)checkCommand.ExecuteScalar() > 0;
                        }
                    }
                    
                    if (exists)
                    {
                        // Update existing settings
                        string updateQuery = @"
                            UPDATE ConnectionSettings 
                            SET IPAddress = @IPAddress, 
                                Port = @Port, 
                                Password = @Password, 
                                AutoConnect = @AutoConnect, 
                                LastConnected = @LastConnected, 
                                LastModified = @LastModified 
                            WHERE Id = @Id";
                        
                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@Id", settings.Id);
                            updateCommand.Parameters.AddWithValue("@IPAddress", settings.IPAddress);
                            updateCommand.Parameters.AddWithValue("@Port", settings.Port);
                            updateCommand.Parameters.AddWithValue("@Password", settings.Password);
                            updateCommand.Parameters.AddWithValue("@AutoConnect", settings.AutoConnect);
                            updateCommand.Parameters.AddWithValue("@LastConnected", 
                                settings.LastConnected.HasValue ? (object)settings.LastConnected.Value : DBNull.Value);
                            updateCommand.Parameters.AddWithValue("@LastModified", DateTime.Now);
                            
                            updateCommand.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // Insert new settings
                        string insertQuery = @"
                            INSERT INTO ConnectionSettings 
                                (IPAddress, Port, Password, AutoConnect, LastConnected, LastModified) 
                            VALUES 
                                (@IPAddress, @Port, @Password, @AutoConnect, @LastConnected, @LastModified); 
                            SELECT SCOPE_IDENTITY();";
                        
                        using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@IPAddress", settings.IPAddress);
                            insertCommand.Parameters.AddWithValue("@Port", settings.Port);
                            insertCommand.Parameters.AddWithValue("@Password", settings.Password);
                            insertCommand.Parameters.AddWithValue("@AutoConnect", settings.AutoConnect);
                            insertCommand.Parameters.AddWithValue("@LastConnected", 
                                settings.LastConnected.HasValue ? (object)settings.LastConnected.Value : DBNull.Value);
                            insertCommand.Parameters.AddWithValue("@LastModified", DateTime.Now);
                            
                            settings.Id = Convert.ToInt32(insertCommand.ExecuteScalar());
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Ignore database errors when saving settings
                // This allows the application to work even without database access
            }
        }
        
        /// <summary>
        /// Gets the time settings from the database
        /// </summary>
        /// <returns>The time settings or null if not found</returns>
        public TimeSettings GetTimeSettings()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    
                    string query = "SELECT TOP 1 * FROM TimeSettings ORDER BY LastModified DESC";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new TimeSettings
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    MorningShiftStart = TimeSpan.Parse(reader["MorningShiftStart"].ToString()),
                                    MorningShiftEnd = TimeSpan.Parse(reader["MorningShiftEnd"].ToString()),
                                    AfternoonShiftStart = TimeSpan.Parse(reader["AfternoonShiftStart"].ToString()),
                                    AfternoonShiftEnd = TimeSpan.Parse(reader["AfternoonShiftEnd"].ToString()),
                                    LateArrivalThreshold = TimeSpan.Parse(reader["LateArrivalThreshold"].ToString()),
                                    EarlyDepartureThreshold = TimeSpan.Parse(reader["EarlyDepartureThreshold"].ToString()),
                                    OvertimeStart = TimeSpan.Parse(reader["OvertimeStart"].ToString()),
                                    LastModified = Convert.ToDateTime(reader["LastModified"])
                                };
                            }
                        }
                    }
                }
                
                return null;
            }
            catch (Exception)
            {
                // If database not accessible, return default settings
                return new TimeSettings
                {
                    MorningShiftStart = new TimeSpan(8, 0, 0),
                    MorningShiftEnd = new TimeSpan(12, 0, 0),
                    AfternoonShiftStart = new TimeSpan(13, 0, 0),
                    AfternoonShiftEnd = new TimeSpan(17, 0, 0),
                    LateArrivalThreshold = new TimeSpan(0, 15, 0),
                    EarlyDepartureThreshold = new TimeSpan(0, 15, 0),
                    OvertimeStart = new TimeSpan(17, 30, 0),
                    LastModified = DateTime.Now
                };
            }
        }
        
        /// <summary>
        /// Saves time settings to the database
        /// </summary>
        /// <param name="settings">The time settings to save</param>
        public void SaveTimeSettings(TimeSettings settings)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    
                    // Check if settings already exist
                    string checkQuery = "SELECT COUNT(*) FROM TimeSettings WHERE Id = @Id";
                    bool exists = false;
                    
                    if (settings.Id > 0)
                    {
                        using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                        {
                            checkCommand.Parameters.AddWithValue("@Id", settings.Id);
                            exists = (int)checkCommand.ExecuteScalar() > 0;
                        }
                    }
                    
                    if (exists)
                    {
                        // Update existing settings
                        string updateQuery = @"
                            UPDATE TimeSettings 
                            SET MorningShiftStart = @MorningShiftStart, 
                                MorningShiftEnd = @MorningShiftEnd, 
                                AfternoonShiftStart = @AfternoonShiftStart, 
                                AfternoonShiftEnd = @AfternoonShiftEnd, 
                                LateArrivalThreshold = @LateArrivalThreshold, 
                                EarlyDepartureThreshold = @EarlyDepartureThreshold, 
                                OvertimeStart = @OvertimeStart, 
                                LastModified = @LastModified 
                            WHERE Id = @Id";
                        
                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@Id", settings.Id);
                            updateCommand.Parameters.AddWithValue("@MorningShiftStart", settings.MorningShiftStart.ToString());
                            updateCommand.Parameters.AddWithValue("@MorningShiftEnd", settings.MorningShiftEnd.ToString());
                            updateCommand.Parameters.AddWithValue("@AfternoonShiftStart", settings.AfternoonShiftStart.ToString());
                            updateCommand.Parameters.AddWithValue("@AfternoonShiftEnd", settings.AfternoonShiftEnd.ToString());
                            updateCommand.Parameters.AddWithValue("@LateArrivalThreshold", settings.LateArrivalThreshold.ToString());
                            updateCommand.Parameters.AddWithValue("@EarlyDepartureThreshold", settings.EarlyDepartureThreshold.ToString());
                            updateCommand.Parameters.AddWithValue("@OvertimeStart", settings.OvertimeStart.ToString());
                            updateCommand.Parameters.AddWithValue("@LastModified", DateTime.Now);
                            
                            updateCommand.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // Insert new settings
                        string insertQuery = @"
                            INSERT INTO TimeSettings 
                                (MorningShiftStart, MorningShiftEnd, AfternoonShiftStart, AfternoonShiftEnd,
                                LateArrivalThreshold, EarlyDepartureThreshold, OvertimeStart, LastModified) 
                            VALUES 
                                (@MorningShiftStart, @MorningShiftEnd, @AfternoonShiftStart, @AfternoonShiftEnd,
                                @LateArrivalThreshold, @EarlyDepartureThreshold, @OvertimeStart, @LastModified); 
                            SELECT SCOPE_IDENTITY();";
                        
                        using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@MorningShiftStart", settings.MorningShiftStart.ToString());
                            insertCommand.Parameters.AddWithValue("@MorningShiftEnd", settings.MorningShiftEnd.ToString());
                            insertCommand.Parameters.AddWithValue("@AfternoonShiftStart", settings.AfternoonShiftStart.ToString());
                            insertCommand.Parameters.AddWithValue("@AfternoonShiftEnd", settings.AfternoonShiftEnd.ToString());
                            insertCommand.Parameters.AddWithValue("@LateArrivalThreshold", settings.LateArrivalThreshold.ToString());
                            insertCommand.Parameters.AddWithValue("@EarlyDepartureThreshold", settings.EarlyDepartureThreshold.ToString());
                            insertCommand.Parameters.AddWithValue("@OvertimeStart", settings.OvertimeStart.ToString());
                            insertCommand.Parameters.AddWithValue("@LastModified", DateTime.Now);
                            
                            settings.Id = Convert.ToInt32(insertCommand.ExecuteScalar());
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Ignore database errors when saving settings
                // This allows the application to work even without database access
            }
        }
    }
}