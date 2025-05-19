using System;

namespace ZKTecoAttendanceSystem.Models
{
    /// <summary>
    /// Represents a user of the application with their permissions
    /// </summary>
    public class User
    {
        /// <summary>
        /// Unique identifier for the user
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Username for login
        /// </summary>
        public string Username { get; set; }
        
        /// <summary>
        /// Password (should be stored securely in production)
        /// </summary>
        public string Password { get; set; }
        
        /// <summary>
        /// Indicates if the user is an administrator with all permissions
        /// </summary>
        public bool IsAdmin { get; set; }
        
        /// <summary>
        /// Indicates if the user can manage other users
        /// </summary>
        public bool CanManageUsers { get; set; }
        
        /// <summary>
        /// Indicates if the user can edit time settings
        /// </summary>
        public bool CanEditTimeSettings { get; set; }
        
        /// <summary>
        /// Indicates if the user can manage devices
        /// </summary>
        public bool CanManageDevices { get; set; }
        
        /// <summary>
        /// Indicates if the user can view attendance data
        /// </summary>
        public bool CanViewAttendance { get; set; }
        
        /// <summary>
        /// Indicates if the user can view reports
        /// </summary>
        public bool CanViewReports { get; set; }
        
        /// <summary>
        /// Date the user was created
        /// </summary>
        public DateTime CreatedDate { get; set; }
        
        /// <summary>
        /// Date the user was last modified
        /// </summary>
        public DateTime? LastModifiedDate { get; set; }
        
        /// <summary>
        /// Last login date
        /// </summary>
        public DateTime? LastLoginDate { get; set; }
    }
}