using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using ZKTecoAttendanceSystem.Models;

namespace ZKTecoAttendanceSystem.Services
{
    /// <summary>
    /// Service for managing users and authentication
    /// </summary>
    public class UserService
    {
        private readonly string _connectionString;
        
        /// <summary>
        /// The currently logged in user
        /// </summary>
        public User CurrentUser { get; private set; }
        
        /// <summary>
        /// Initializes a new instance of the UserService class
        /// </summary>
        public UserService()
        {
            // Get connection string from app.config or default to local database
            _connectionString = ConfigurationManager.ConnectionStrings["ZKTecoAttendanceDB"]?.ConnectionString
                ?? @"Data Source=.\SQLEXPRESS;Initial Catalog=ZKTecoAttendanceDB;Integrated Security=True";
        }
        
        /// <summary>
        /// Gets all users from the database
        /// </summary>
        /// <returns>A list of all users</returns>
        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    
                    string query = "SELECT * FROM Users ORDER BY Username";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                users.Add(new User
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Username = reader["Username"].ToString(),
                                    Password = reader["Password"].ToString(), // In a real app, passwords should not be returned
                                    IsAdmin = Convert.ToBoolean(reader["IsAdmin"]),
                                    CanManageUsers = Convert.ToBoolean(reader["CanManageUsers"]),
                                    CanEditTimeSettings = Convert.ToBoolean(reader["CanEditTimeSettings"]),
                                    CanManageDevices = Convert.ToBoolean(reader["CanManageDevices"]),
                                    CanViewAttendance = Convert.ToBoolean(reader["CanViewAttendance"]),
                                    CanViewReports = Convert.ToBoolean(reader["CanViewReports"]),
                                    CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                                    LastModifiedDate = reader["LastModifiedDate"] != DBNull.Value 
                                        ? Convert.ToDateTime(reader["LastModifiedDate"]) 
                                        : (DateTime?)null,
                                    LastLoginDate = reader["LastLoginDate"] != DBNull.Value 
                                        ? Convert.ToDateTime(reader["LastLoginDate"]) 
                                        : (DateTime?)null
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Return an empty list if database is not accessible
                // This allows the application to at least show a blank user list
            }
            
            return users;
        }
        
        /// <summary>
        /// Gets a user by ID
        /// </summary>
        /// <param name="id">The user ID</param>
        /// <returns>The user or null if not found</returns>
        public User GetUserById(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    
                    string query = "SELECT * FROM Users WHERE Id = @Id";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new User
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Username = reader["Username"].ToString(),
                                    Password = reader["Password"].ToString(), // In a real app, passwords should not be returned
                                    IsAdmin = Convert.ToBoolean(reader["IsAdmin"]),
                                    CanManageUsers = Convert.ToBoolean(reader["CanManageUsers"]),
                                    CanEditTimeSettings = Convert.ToBoolean(reader["CanEditTimeSettings"]),
                                    CanManageDevices = Convert.ToBoolean(reader["CanManageDevices"]),
                                    CanViewAttendance = Convert.ToBoolean(reader["CanViewAttendance"]),
                                    CanViewReports = Convert.ToBoolean(reader["CanViewReports"]),
                                    CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                                    LastModifiedDate = reader["LastModifiedDate"] != DBNull.Value 
                                        ? Convert.ToDateTime(reader["LastModifiedDate"]) 
                                        : (DateTime?)null,
                                    LastLoginDate = reader["LastLoginDate"] != DBNull.Value 
                                        ? Convert.ToDateTime(reader["LastLoginDate"]) 
                                        : (DateTime?)null
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Return null if database is not accessible
            }
            
            return null;
        }
        
        /// <summary>
        /// Gets a user by username
        /// </summary>
        /// <param name="username">The username</param>
        /// <returns>The user or null if not found</returns>
        public User GetUserByUsername(string username)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    
                    string query = "SELECT * FROM Users WHERE Username = @Username";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new User
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Username = reader["Username"].ToString(),
                                    Password = reader["Password"].ToString(), // In a real app, passwords should not be returned
                                    IsAdmin = Convert.ToBoolean(reader["IsAdmin"]),
                                    CanManageUsers = Convert.ToBoolean(reader["CanManageUsers"]),
                                    CanEditTimeSettings = Convert.ToBoolean(reader["CanEditTimeSettings"]),
                                    CanManageDevices = Convert.ToBoolean(reader["CanManageDevices"]),
                                    CanViewAttendance = Convert.ToBoolean(reader["CanViewAttendance"]),
                                    CanViewReports = Convert.ToBoolean(reader["CanViewReports"]),
                                    CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                                    LastModifiedDate = reader["LastModifiedDate"] != DBNull.Value 
                                        ? Convert.ToDateTime(reader["LastModifiedDate"]) 
                                        : (DateTime?)null,
                                    LastLoginDate = reader["LastLoginDate"] != DBNull.Value 
                                        ? Convert.ToDateTime(reader["LastLoginDate"]) 
                                        : (DateTime?)null
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Return null if database is not accessible
            }
            
            return null;
        }
        
        /// <summary>
        /// Adds a new user to the database
        /// </summary>
        /// <param name="user">The user to add</param>
        public void AddUser(User user)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    
                    // Check if user with same username already exists
                    if (UserExists(user.Username))
                    {
                        throw new Exception("A user with this username already exists.");
                    }
                    
                    string query = @"
                        INSERT INTO Users (
                            Username, Password, IsAdmin, CanManageUsers, CanEditTimeSettings,
                            CanManageDevices, CanViewAttendance, CanViewReports, CreatedDate
                        ) VALUES (
                            @Username, @Password, @IsAdmin, @CanManageUsers, @CanEditTimeSettings,
                            @CanManageDevices, @CanViewAttendance, @CanViewReports, @CreatedDate
                        );
                        SELECT SCOPE_IDENTITY();";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Hash the password before storing
                        string hashedPassword = HashPassword(user.Password);
                        
                        command.Parameters.AddWithValue("@Username", user.Username);
                        command.Parameters.AddWithValue("@Password", hashedPassword);
                        command.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);
                        command.Parameters.AddWithValue("@CanManageUsers", user.CanManageUsers);
                        command.Parameters.AddWithValue("@CanEditTimeSettings", user.CanEditTimeSettings);
                        command.Parameters.AddWithValue("@CanManageDevices", user.CanManageDevices);
                        command.Parameters.AddWithValue("@CanViewAttendance", user.CanViewAttendance);
                        command.Parameters.AddWithValue("@CanViewReports", user.CanViewReports);
                        command.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                        
                        user.Id = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding user: " + ex.Message);
            }
        }
        
        /// <summary>
        /// Updates an existing user in the database
        /// </summary>
        /// <param name="user">The user to update</param>
        public void UpdateUser(User user)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    
                    // Check if user exists
                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Id = @Id";
                    
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@Id", user.Id);
                        
                        int count = (int)checkCommand.ExecuteScalar();
                        
                        if (count == 0)
                        {
                            throw new Exception("User not found.");
                        }
                    }
                    
                    // Perform the update
                    string query;
                    
                    // If password is provided, update it too
                    if (!string.IsNullOrEmpty(user.Password))
                    {
                        query = @"
                            UPDATE Users SET 
                                Username = @Username,
                                Password = @Password,
                                IsAdmin = @IsAdmin,
                                CanManageUsers = @CanManageUsers,
                                CanEditTimeSettings = @CanEditTimeSettings,
                                CanManageDevices = @CanManageDevices,
                                CanViewAttendance = @CanViewAttendance,
                                CanViewReports = @CanViewReports,
                                LastModifiedDate = @LastModifiedDate
                            WHERE Id = @Id";
                    }
                    else
                    {
                        // Don't update password if not provided
                        query = @"
                            UPDATE Users SET 
                                Username = @Username,
                                IsAdmin = @IsAdmin,
                                CanManageUsers = @CanManageUsers,
                                CanEditTimeSettings = @CanEditTimeSettings,
                                CanManageDevices = @CanManageDevices,
                                CanViewAttendance = @CanViewAttendance,
                                CanViewReports = @CanViewReports,
                                LastModifiedDate = @LastModifiedDate
                            WHERE Id = @Id";
                    }
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", user.Id);
                        command.Parameters.AddWithValue("@Username", user.Username);
                        command.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);
                        command.Parameters.AddWithValue("@CanManageUsers", user.CanManageUsers);
                        command.Parameters.AddWithValue("@CanEditTimeSettings", user.CanEditTimeSettings);
                        command.Parameters.AddWithValue("@CanManageDevices", user.CanManageDevices);
                        command.Parameters.AddWithValue("@CanViewAttendance", user.CanViewAttendance);
                        command.Parameters.AddWithValue("@CanViewReports", user.CanViewReports);
                        command.Parameters.AddWithValue("@LastModifiedDate", DateTime.Now);
                        
                        if (!string.IsNullOrEmpty(user.Password))
                        {
                            // Hash the password before storing
                            string hashedPassword = HashPassword(user.Password);
                            command.Parameters.AddWithValue("@Password", hashedPassword);
                        }
                        
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating user: " + ex.Message);
            }
        }
        
        /// <summary>
        /// Deletes a user from the database
        /// </summary>
        /// <param name="id">The ID of the user to delete</param>
        public void DeleteUser(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    
                    // Check if user exists
                    string checkQuery = "SELECT COUNT(*) FROM Users WHERE Id = @Id";
                    
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@Id", id);
                        
                        int count = (int)checkCommand.ExecuteScalar();
                        
                        if (count == 0)
                        {
                            throw new Exception("User not found.");
                        }
                    }
                    
                    // Perform the delete
                    string query = "DELETE FROM Users WHERE Id = @Id";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting user: " + ex.Message);
            }
        }
        
        /// <summary>
        /// Checks if a user with the given username exists
        /// </summary>
        /// <param name="username">The username to check</param>
        /// <returns>True if the user exists, false otherwise</returns>
        public bool UserExists(string username)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    
                    string query = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        
                        int count = (int)command.ExecuteScalar();
                        
                        return count > 0;
                    }
                }
            }
            catch
            {
                // If database is not accessible, assume user does not exist
                return false;
            }
        }
        
        /// <summary>
        /// Checks if there are any users in the database
        /// </summary>
        /// <returns>True if users exist, false otherwise</returns>
        public bool HasAnyUsers()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    
                    string query = "SELECT COUNT(*) FROM Users";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int count = (int)command.ExecuteScalar();
                        
                        return count > 0;
                    }
                }
            }
            catch
            {
                // If database is not accessible, assume no users exist
                return false;
            }
        }
        
        /// <summary>
        /// Authenticates a user and sets the CurrentUser property
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="password">The password</param>
        /// <returns>True if authentication is successful, false otherwise</returns>
        public bool Login(string username, string password)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    
                    string query = "SELECT * FROM Users WHERE Username = @Username";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedHash = reader["Password"].ToString();
                                
                                // Verify the password
                                if (VerifyPassword(password, storedHash))
                                {
                                    // Create the user object
                                    CurrentUser = new User
                                    {
                                        Id = Convert.ToInt32(reader["Id"]),
                                        Username = reader["Username"].ToString(),
                                        Password = string.Empty, // Don't store password in memory
                                        IsAdmin = Convert.ToBoolean(reader["IsAdmin"]),
                                        CanManageUsers = Convert.ToBoolean(reader["CanManageUsers"]),
                                        CanEditTimeSettings = Convert.ToBoolean(reader["CanEditTimeSettings"]),
                                        CanManageDevices = Convert.ToBoolean(reader["CanManageDevices"]),
                                        CanViewAttendance = Convert.ToBoolean(reader["CanViewAttendance"]),
                                        CanViewReports = Convert.ToBoolean(reader["CanViewReports"]),
                                        CreatedDate = Convert.ToDateTime(reader["CreatedDate"]),
                                        LastModifiedDate = reader["LastModifiedDate"] != DBNull.Value 
                                            ? Convert.ToDateTime(reader["LastModifiedDate"]) 
                                            : (DateTime?)null,
                                        LastLoginDate = reader["LastLoginDate"] != DBNull.Value 
                                            ? Convert.ToDateTime(reader["LastLoginDate"]) 
                                            : (DateTime?)null
                                    };
                                    
                                    // Update the last login date
                                    UpdateLastLoginDate(CurrentUser.Id);
                                    
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                // If database is not accessible, return default admin user (for demonstration only)
                // In a real app, this would not be allowed
                if (username.ToLower() == "admin" && password == "admin")
                {
                    CurrentUser = new User
                    {
                        Id = 1,
                        Username = "admin",
                        Password = string.Empty,
                        IsAdmin = true,
                        CanManageUsers = true,
                        CanEditTimeSettings = true,
                        CanManageDevices = true,
                        CanViewAttendance = true,
                        CanViewReports = true,
                        CreatedDate = DateTime.Now,
                        LastLoginDate = DateTime.Now
                    };
                    
                    return true;
                }
            }
            
            return false;
        }
        
        /// <summary>
        /// Logs out the current user
        /// </summary>
        public void Logout()
        {
            CurrentUser = null;
        }
        
        /// <summary>
        /// Updates the last login date for a user
        /// </summary>
        /// <param name="id">The user ID</param>
        private void UpdateLastLoginDate(int id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    
                    string query = "UPDATE Users SET LastLoginDate = @LastLoginDate WHERE Id = @Id";
                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.Parameters.AddWithValue("@LastLoginDate", DateTime.Now);
                        
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                // Ignore errors when updating last login date
                // This is not critical to the authentication process
            }
        }
        
        /// <summary>
        /// Hashes a password
        /// </summary>
        /// <param name="password">The password to hash</param>
        /// <returns>The hashed password</returns>
        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convert the password to a byte array and compute the hash
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                
                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        
        /// <summary>
        /// Verifies a password against a hash
        /// </summary>
        /// <param name="password">The password to verify</param>
        /// <param name="hash">The hash to verify against</param>
        /// <returns>True if the password matches the hash, false otherwise</returns>
        private bool VerifyPassword(string password, string hash)
        {
            // For simplicity, we're assuming the passwords are hashed with SHA-256
            // In a real app, a more secure method like BCrypt should be used
            string passwordHash = HashPassword(password);
            
            return passwordHash.Equals(hash, StringComparison.OrdinalIgnoreCase);
        }
    }
}