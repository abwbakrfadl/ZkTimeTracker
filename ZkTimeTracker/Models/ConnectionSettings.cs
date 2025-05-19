using System;

namespace ZKTecoAttendanceSystem.Models
{
    /// <summary>
    /// Represents connection settings for ZKTeco devices
    /// </summary>
    public class ConnectionSettings
    {
        /// <summary>
        /// Unique identifier for the connection settings
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// IP address of the device
        /// </summary>
        public string IPAddress { get; set; }
        
        /// <summary>
        /// Port number for connection
        /// </summary>
        public int Port { get; set; }
        
        /// <summary>
        /// Password for device communication (if any)
        /// </summary>
        public string Password { get; set; }
        
        /// <summary>
        /// Flag to indicate if auto-connect is enabled
        /// </summary>
        public bool AutoConnect { get; set; }
        
        /// <summary>
        /// Last successful connection time
        /// </summary>
        public DateTime? LastConnected { get; set; }
        
        /// <summary>
        /// Last modified date
        /// </summary>
        public DateTime LastModified { get; set; }
    }
}