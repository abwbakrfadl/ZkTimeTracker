using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ZKTecoAttendanceSystem.Utils
{
    /// <summary>
    /// Helper class for database operations
    /// </summary>
    public static class DatabaseHelper
    {
        private static string _connectionString;
        
        /// <summary>
        /// Gets the connection string from app.config or uses default if not found
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = ConfigurationManager.ConnectionStrings["ZKTecoAttendanceDB"]?.ConnectionString
                        ?? @"Data Source=.\SQLEXPRESS;Initial Catalog=ZKTecoAttendanceDB;Integrated Security=True";
                }
                
                return _connectionString;
            }
        }
        
        /// <summary>
        /// Initializes the database by creating required tables if they don't exist
        /// </summary>
        /// <returns>True if initialization is successful, false otherwise</returns>
        public static bool InitializeDatabase()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    
                    // Check if tables already exist
                    if (TablesExist(connection))
                    {
                        return true; // Database already initialized
                    }
                    
                    // Create Users table
                    ExecuteNonQuery(connection, @"
                        CREATE TABLE Users (
                            Id INT IDENTITY(1,1) PRIMARY KEY,
                            Username NVARCHAR(50) NOT NULL,
                            Password NVARCHAR(100) NOT NULL,
                            IsAdmin BIT NOT NULL,
                            CanManageUsers BIT NOT NULL,
                            CanEditTimeSettings BIT NOT NULL,
                            CanManageDevices BIT NOT NULL,
                            CanViewAttendance BIT NOT NULL,
                            CanViewReports BIT NOT NULL,
                            CreatedDate DATETIME NOT NULL,
                            LastModifiedDate DATETIME NULL,
                            LastLoginDate DATETIME NULL
                        )");
                    
                    // Create ConnectionSettings table
                    ExecuteNonQuery(connection, @"
                        CREATE TABLE ConnectionSettings (
                            Id INT IDENTITY(1,1) PRIMARY KEY,
                            IPAddress NVARCHAR(50) NOT NULL,
                            Port INT NOT NULL,
                            Password NVARCHAR(50) NULL,
                            AutoConnect BIT NOT NULL,
                            LastConnected DATETIME NULL,
                            LastModified DATETIME NOT NULL
                        )");
                    
                    // Create TimeSettings table
                    ExecuteNonQuery(connection, @"
                        CREATE TABLE TimeSettings (
                            Id INT IDENTITY(1,1) PRIMARY KEY,
                            MorningShiftStart NVARCHAR(10) NOT NULL,
                            MorningShiftEnd NVARCHAR(10) NOT NULL,
                            AfternoonShiftStart NVARCHAR(10) NOT NULL,
                            AfternoonShiftEnd NVARCHAR(10) NOT NULL,
                            LateArrivalThreshold NVARCHAR(10) NOT NULL,
                            EarlyDepartureThreshold NVARCHAR(10) NOT NULL,
                            OvertimeStart NVARCHAR(10) NOT NULL,
                            LastModified DATETIME NOT NULL
                        )");
                    
                    // Create Employees table
                    ExecuteNonQuery(connection, @"
                        CREATE TABLE Employees (
                            Id INT IDENTITY(1,1) PRIMARY KEY,
                            EmployeeId INT NOT NULL,
                            Name NVARCHAR(100) NULL,
                            Department NVARCHAR(50) NULL,
                            Position NVARCHAR(50) NULL,
                            CardNumber NVARCHAR(50) NULL,
                            CreatedDate DATETIME NOT NULL,
                            LastModifiedDate DATETIME NULL
                        )");
                    
                    // Create AttendanceRecords table
                    ExecuteNonQuery(connection, @"
                        CREATE TABLE AttendanceRecords (
                            Id INT IDENTITY(1,1) PRIMARY KEY,
                            EmployeeId INT NOT NULL,
                            RecordTime DATETIME NOT NULL,
                            RecordType INT NOT NULL,
                            VerifyMode INT NOT NULL,
                            WorkCode INT NOT NULL,
                            CreatedDate DATETIME NOT NULL,
                            IsProcessed BIT NOT NULL
                        )");
                    
                    // Create indexes for better performance
                    ExecuteNonQuery(connection, @"CREATE INDEX IX_Users_Username ON Users (Username)");
                    ExecuteNonQuery(connection, @"CREATE INDEX IX_Employees_EmployeeId ON Employees (EmployeeId)");
                    ExecuteNonQuery(connection, @"CREATE INDEX IX_AttendanceRecords_EmployeeId ON AttendanceRecords (EmployeeId)");
                    ExecuteNonQuery(connection, @"CREATE INDEX IX_AttendanceRecords_RecordTime ON AttendanceRecords (RecordTime)");
                    
                    // Create default admin user
                    string adminPassword = HashPassword("admin");
                    ExecuteNonQuery(connection, $@"
                        INSERT INTO Users (
                            Username, Password, IsAdmin, CanManageUsers, CanEditTimeSettings,
                            CanManageDevices, CanViewAttendance, CanViewReports, CreatedDate
                        ) VALUES (
                            'admin', '{adminPassword}', 1, 1, 1, 1, 1, 1, GETDATE()
                        )");
                    
                    // Create default time settings
                    ExecuteNonQuery(connection, @"
                        INSERT INTO TimeSettings (
                            MorningShiftStart, MorningShiftEnd, AfternoonShiftStart, AfternoonShiftEnd,
                            LateArrivalThreshold, EarlyDepartureThreshold, OvertimeStart, LastModified
                        ) VALUES (
                            '08:00:00', '12:00:00', '13:00:00', '17:00:00',
                            '00:15:00', '00:15:00', '17:30:00', GETDATE()
                        )");
                    
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing database: {ex.Message}\n\nPlease ensure SQL Server is installed and running.", 
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        
        /// <summary>
        /// Checks if the required database tables exist
        /// </summary>
        /// <param name="connection">An open SQL connection</param>
        /// <returns>True if tables exist, false otherwise</returns>
        private static bool TablesExist(SqlConnection connection)
        {
            try
            {
                string[] tables = { "Users", "ConnectionSettings", "TimeSettings", "Employees", "AttendanceRecords" };
                
                foreach (string table in tables)
                {
                    string query = $@"
                        IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{table}')
                            SELECT 1
                        ELSE
                            SELECT 0";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int exists = (int)command.ExecuteScalar();
                        
                        if (exists == 0)
                        {
                            return false; // At least one table doesn't exist
                        }
                    }
                }
                
                return true; // All tables exist
            }
            catch
            {
                return false;
            }
        }
        
        /// <summary>
        /// Exports database data to SQL script for backup
        /// </summary>
        /// <param name="filePath">Path to save the SQL script</param>
        /// <returns>True if export is successful, false otherwise</returns>
        public static bool ExportDatabaseToSql(string filePath)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    
                    // Tables to export
                    string[] tables = { "Users", "ConnectionSettings", "TimeSettings", "Employees", "AttendanceRecords" };
                    
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        writer.WriteLine("-- ZKTeco Attendance System Database Backup");
                        writer.WriteLine($"-- Generated on {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
                        writer.WriteLine();
                        
                        foreach (string table in tables)
                        {
                            writer.WriteLine($"-- Table: {table}");
                            writer.WriteLine($"DELETE FROM {table};");
                            writer.WriteLine("GO");
                            writer.WriteLine();
                            
                            // Get column names
                            List<string> columns = new List<string>();
                            using (SqlCommand command = new SqlCommand($"SELECT TOP 0 * FROM {table}", connection))
                            {
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    DataTable schema = reader.GetSchemaTable();
                                    foreach (DataRow row in schema.Rows)
                                    {
                                        columns.Add(row["ColumnName"].ToString());
                                    }
                                }
                            }
                            
                            // Export data
                            using (SqlCommand command = new SqlCommand($"SELECT * FROM {table}", connection))
                            {
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        writer.Write($"INSERT INTO {table} (");
                                        writer.Write(string.Join(", ", columns));
                                        writer.Write(") VALUES (");
                                        
                                        for (int i = 0; i < reader.FieldCount; i++)
                                        {
                                            if (i > 0)
                                                writer.Write(", ");
                                            
                                            if (reader.IsDBNull(i))
                                            {
                                                writer.Write("NULL");
                                            }
                                            else
                                            {
                                                string value = reader.GetValue(i).ToString();
                                                Type type = reader.GetFieldType(i);
                                                
                                                if (type == typeof(string) || type == typeof(DateTime) || 
                                                    type == typeof(Guid) || type == typeof(char))
                                                {
                                                    // Escape single quotes
                                                    value = value.Replace("'", "''");
                                                    writer.Write($"'{value}'");
                                                }
                                                else if (type == typeof(bool))
                                                {
                                                    writer.Write(Convert.ToBoolean(value) ? "1" : "0");
                                                }
                                                else
                                                {
                                                    writer.Write(value);
                                                }
                                            }
                                        }
                                        
                                        writer.WriteLine(");");
                                    }
                                }
                            }
                            
                            writer.WriteLine("GO");
                            writer.WriteLine();
                        }
                    }
                    
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting database: {ex.Message}", "Export Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        
        /// <summary>
        /// Imports database data from SQL script for restore
        /// </summary>
        /// <param name="filePath">Path to the SQL script</param>
        /// <returns>True if import is successful, false otherwise</returns>
        public static bool ImportDatabaseFromSql(string filePath)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string line;
                        StringBuilder query = new StringBuilder();
                        
                        while ((line = reader.ReadLine()) != null)
                        {
                            line = line.Trim();
                            
                            // Skip comments and empty lines
                            if (line.StartsWith("--") || string.IsNullOrWhiteSpace(line))
                                continue;
                            
                            // Process GO statements
                            if (line.Equals("GO", StringComparison.OrdinalIgnoreCase))
                            {
                                if (query.Length > 0)
                                {
                                    ExecuteNonQuery(connection, query.ToString());
                                    query.Clear();
                                }
                            }
                            else
                            {
                                query.AppendLine(line);
                            }
                        }
                        
                        // Execute any remaining query
                        if (query.Length > 0)
                        {
                            ExecuteNonQuery(connection, query.ToString());
                        }
                    }
                    
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error importing database: {ex.Message}", "Import Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        
        /// <summary>
        /// Executes a non-query SQL command
        /// </summary>
        /// <param name="connection">An open SQL connection</param>
        /// <param name="commandText">The SQL command to execute</param>
        private static void ExecuteNonQuery(SqlConnection connection, string commandText)
        {
            using (SqlCommand command = new SqlCommand(commandText, connection))
            {
                command.ExecuteNonQuery();
            }
        }
        
        /// <summary>
        /// Hashes a password using SHA-256
        /// </summary>
        /// <param name="password">The password to hash</param>
        /// <returns>The hashed password</returns>
        private static string HashPassword(string password)
        {
            using (System.Security.Cryptography.SHA256 sha256Hash = System.Security.Cryptography.SHA256.Create())
            {
                // Convert the password to a byte array and compute the hash
                byte[] bytes = sha256Hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                
                // Convert byte array to a string
                System.Text.StringBuilder builder = new System.Text.StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}