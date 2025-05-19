using System;

namespace ZKTecoAttendanceSystem.Models
{
    /// <summary>
    /// Represents information about a ZKTeco device
    /// </summary>
    public class DeviceInfo
    {
        /// <summary>
        /// Device ID assigned by system
        /// </summary>
        public int DeviceID { get; set; }
        
        /// <summary>
        /// IP address of the device
        /// </summary>
        public string IPAddress { get; set; }
        
        /// <summary>
        /// Port number for connection
        /// </summary>
        public int Port { get; set; }
        
        /// <summary>
        /// Device name or model
        /// </summary>
        public string DeviceName { get; set; }
        
        /// <summary>
        /// Serial number of the device
        /// </summary>
        public string SerialNumber { get; set; }
        
        /// <summary>
        /// Firmware version of the device
        /// </summary>
        public string FirmwareVersion { get; set; }
        
        /// <summary>
        /// MAC address of the device
        /// </summary>
        public string MACAddress { get; set; }
        
        /// <summary>
        /// Current device time
        /// </summary>
        public DateTime DeviceTime { get; set; }
        
        /// <summary>
        /// Flag to indicate if device has sound enabled
        /// </summary>
        public bool SoundEnabled { get; set; }
        
        /// <summary>
        /// Language setting of the device
        /// </summary>
        public int Language { get; set; }
        
        /// <summary>
        /// Total user capacity of the device
        /// </summary>
        public int UserCapacity { get; set; }
        
        /// <summary>
        /// Current user count on the device
        /// </summary>
        public int UserCount { get; set; }
        
        /// <summary>
        /// Total fingerprint capacity of the device
        /// </summary>
        public int FingerprintCapacity { get; set; }
        
        /// <summary>
        /// Current fingerprint count on the device
        /// </summary>
        public int FingerprintCount { get; set; }
        
        /// <summary>
        /// Total attendance record capacity of the device
        /// </summary>
        public int AttendanceCapacity { get; set; }
        
        /// <summary>
        /// Current attendance record count on the device
        /// </summary>
        public int AttendanceCount { get; set; }
    }
}