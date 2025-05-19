using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZKTecoAttendanceSystem.Models;

namespace ZKTecoAttendanceSystem.Services
{
    /// <summary>
    /// Service for interacting with ZKTeco fingerprint devices
    /// </summary>
    public class DeviceService
    {
        // COM object for communicating with the device
        private readonly object _zkemKeeper;
        
        // Keep track of connection status
        private bool _connected = false;
        private string _currentIPAddress = string.Empty;
        private int _currentPort = 0;
        
        /// <summary>
        /// Gets a value indicating whether the service is connected to a device
        /// </summary>
        public bool IsConnected => _connected;
        
        /// <summary>
        /// Initializes a new instance of the DeviceService class
        /// </summary>
        public DeviceService()
        {
            try
            {
                // Create an instance of the zkemkeeper.CZKEM object
                // This requires the zkemkeeper.dll COM component to be registered
                Type type = Type.GetTypeFromProgID("zkemkeeper.CZKEM");
                _zkemKeeper = Activator.CreateInstance(type);
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to initialize zkemkeeper: " + ex.Message);
            }
        }
        
        /// <summary>
        /// Connects to a device using the specified IP address and port
        /// </summary>
        /// <param name="ipAddress">The IP address of the device</param>
        /// <param name="port">The port number</param>
        /// <param name="password">The password (if required)</param>
        /// <returns>True if connection is successful, false otherwise</returns>
        public bool Connect(string ipAddress, int port, string password = "")
        {
            try
            {
                // Disconnect if already connected
                if (_connected)
                {
                    Disconnect();
                }
                
                // Call the Connect method of the zkemkeeper COM object
                // This connects to the device via TCP/IP
                bool connected = (bool)_zkemKeeper.GetType().InvokeMember(
                    "Connect_Net",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    _zkemKeeper,
                    new object[] { ipAddress, port });
                
                if (connected)
                {
                    _connected = true;
                    _currentIPAddress = ipAddress;
                    _currentPort = port;
                    
                    // If password is provided and connection is successful,
                    // verify the password with the device
                    if (!string.IsNullOrEmpty(password))
                    {
                        // Call the SetCommPassword method to set the password for secure communication
                        bool verifyPassword = (bool)_zkemKeeper.GetType().InvokeMember(
                            "SetCommPassword",
                            System.Reflection.BindingFlags.InvokeMethod,
                            null,
                            _zkemKeeper,
                            new object[] { int.Parse(password) });
                        
                        if (!verifyPassword)
                        {
                            // If password verification fails, disconnect and return false
                            Disconnect();
                            return false;
                        }
                    }
                    
                    // Save the connection settings to the database
                    SaveConnectionSettings(ipAddress, port, password);
                }
                
                return connected;
            }
            catch (Exception ex)
            {
                throw new Exception("Connection error: " + ex.Message);
            }
        }
        
        /// <summary>
        /// Disconnects from the device
        /// </summary>
        /// <returns>True if disconnect is successful, false otherwise</returns>
        public bool Disconnect()
        {
            try
            {
                if (_connected)
                {
                    // Call the Disconnect method of the zkemkeeper COM object
                    bool disconnected = (bool)_zkemKeeper.GetType().InvokeMember(
                        "Disconnect",
                        System.Reflection.BindingFlags.InvokeMethod,
                        null,
                        _zkemKeeper,
                        null);
                    
                    if (disconnected)
                    {
                        _connected = false;
                        _currentIPAddress = string.Empty;
                        _currentPort = 0;
                    }
                    
                    return disconnected;
                }
                
                return true; // Already disconnected
            }
            catch (Exception ex)
            {
                throw new Exception("Disconnection error: " + ex.Message);
            }
        }
        
        /// <summary>
        /// Tests connection to a device without saving connection settings
        /// </summary>
        /// <param name="ipAddress">The IP address of the device</param>
        /// <param name="port">The port number</param>
        /// <param name="password">The password (if required)</param>
        /// <returns>True if connection test is successful, false otherwise</returns>
        public bool TestConnection(string ipAddress, int port, string password = "")
        {
            bool wasConnected = _connected;
            string previousIP = _currentIPAddress;
            int previousPort = _currentPort;
            
            try
            {
                // Try to connect
                bool connected = Connect(ipAddress, port, password);
                
                // If connection successful, disconnect (this is just a test)
                if (connected)
                {
                    Disconnect();
                    
                    // If previously connected, reconnect to previous device
                    if (wasConnected)
                    {
                        Connect(previousIP, previousPort);
                    }
                }
                
                return connected;
            }
            catch (Exception)
            {
                // If previously connected, reconnect to previous device
                if (wasConnected)
                {
                    try
                    {
                        Connect(previousIP, previousPort);
                    }
                    catch { }
                }
                
                return false;
            }
        }
        
        /// <summary>
        /// Scans the network for ZKTeco devices
        /// </summary>
        /// <returns>A list of device information found on the network</returns>
        public List<DeviceInfo> ScanNetwork()
        {
            List<DeviceInfo> devices = new List<DeviceInfo>();
            
            try
            {
                // Simplified network scan simulation for now
                // In a real implementation, this would use broadcast or range scanning
                
                // For now, just return an empty list as the actual implementation
                // would require specific network scanning code
                
                return devices;
            }
            catch (Exception ex)
            {
                throw new Exception("Network scan error: " + ex.Message);
            }
        }
        
        /// <summary>
        /// Gets information about the connected device
        /// </summary>
        /// <returns>Device information</returns>
        public DeviceInfo GetDeviceInfo()
        {
            if (!_connected)
            {
                throw new Exception("Device not connected");
            }
            
            try
            {
                DeviceInfo deviceInfo = new DeviceInfo();
                deviceInfo.IPAddress = _currentIPAddress;
                deviceInfo.Port = _currentPort;
                
                // Get firmware version
                string firmwareVersion = string.Empty;
                _zkemKeeper.GetType().InvokeMember(
                    "GetFirmwareVersion",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    _zkemKeeper,
                    new object[] { 1, ref firmwareVersion });
                deviceInfo.FirmwareVersion = firmwareVersion;
                
                // Get device ID
                int deviceId = 0;
                _zkemKeeper.GetType().InvokeMember(
                    "GetDeviceID",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    _zkemKeeper,
                    new object[] { 1, ref deviceId });
                deviceInfo.DeviceID = deviceId;
                
                // Get MAC address
                string macAddress = string.Empty;
                _zkemKeeper.GetType().InvokeMember(
                    "GetDeviceMAC",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    _zkemKeeper,
                    new object[] { 1, ref macAddress });
                deviceInfo.MACAddress = macAddress;
                
                // Get product code (device name)
                string productCode = string.Empty;
                _zkemKeeper.GetType().InvokeMember(
                    "GetProductCode",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    _zkemKeeper,
                    new object[] { 1, ref productCode });
                deviceInfo.DeviceName = productCode;
                
                // Get serial number
                string serialNumber = string.Empty;
                _zkemKeeper.GetType().InvokeMember(
                    "GetSerialNumber",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    _zkemKeeper,
                    new object[] { 1, ref serialNumber });
                deviceInfo.SerialNumber = serialNumber;
                
                // Get device time
                int year = 0, month = 0, day = 0, hour = 0, minute = 0, second = 0;
                _zkemKeeper.GetType().InvokeMember(
                    "GetDeviceTime",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    _zkemKeeper,
                    new object[] { 1, ref year, ref month, ref day, ref hour, ref minute, ref second });
                deviceInfo.DeviceTime = new DateTime(year, month, day, hour, minute, second);
                
                // Get language
                int language = 0;
                _zkemKeeper.GetType().InvokeMember(
                    "GetDeviceLanguage",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    _zkemKeeper,
                    new object[] { 1, ref language });
                deviceInfo.Language = language;
                
                // Get sound settings
                bool soundEnabled = false;
                _zkemKeeper.GetType().InvokeMember(
                    "GetSoundMode",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    _zkemKeeper,
                    new object[] { 1, ref soundEnabled });
                deviceInfo.SoundEnabled = soundEnabled;
                
                // Get user and fingerprint info
                int userCount = 0, fpCount = 0, recordCount = 0;
                _zkemKeeper.GetType().InvokeMember(
                    "GetDeviceStatus",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    _zkemKeeper,
                    new object[] { 1, 1, ref userCount }); // 1 = user count
                
                _zkemKeeper.GetType().InvokeMember(
                    "GetDeviceStatus",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    _zkemKeeper,
                    new object[] { 1, 2, ref fpCount }); // 2 = fingerprint count
                
                _zkemKeeper.GetType().InvokeMember(
                    "GetDeviceStatus",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    _zkemKeeper,
                    new object[] { 1, 6, ref recordCount }); // 6 = attendance record count
                
                deviceInfo.UserCount = userCount;
                deviceInfo.FingerprintCount = fpCount;
                deviceInfo.AttendanceCount = recordCount;
                
                return deviceInfo;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving device information: " + ex.Message);
            }
        }
        
        /// <summary>
        /// Sets basic information for the connected device
        /// </summary>
        /// <param name="deviceId">The device ID to set</param>
        /// <param name="soundEnabled">Whether sound is enabled</param>
        /// <param name="language">The language setting</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool SetDeviceInfo(int deviceId, bool soundEnabled, string language)
        {
            if (!_connected)
            {
                throw new Exception("Device not connected");
            }
            
            try
            {
                // Set device ID
                bool success = (bool)_zkemKeeper.GetType().InvokeMember(
                    "SetDeviceID",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    _zkemKeeper,
                    new object[] { 1, deviceId });
                
                if (!success)
                    return false;
                
                // Set sound mode
                success = (bool)_zkemKeeper.GetType().InvokeMember(
                    "SetSoundMode",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    _zkemKeeper,
                    new object[] { 1, soundEnabled });
                
                if (!success)
                    return false;
                
                // Set language
                if (!string.IsNullOrEmpty(language) && int.TryParse(language, out int languageCode))
                {
                    success = (bool)_zkemKeeper.GetType().InvokeMember(
                        "SetDeviceLanguage",
                        System.Reflection.BindingFlags.InvokeMethod,
                        null,
                        _zkemKeeper,
                        new object[] { 1, languageCode });
                    
                    if (!success)
                        return false;
                }
                
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error setting device information: " + ex.Message);
            }
        }
        
        /// <summary>
        /// Sets the date and time on the connected device
        /// </summary>
        /// <param name="dateTime">The date and time to set</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool SetDeviceTime(DateTime dateTime)
        {
            if (!_connected)
            {
                throw new Exception("Device not connected");
            }
            
            try
            {
                // Set device time
                bool success = (bool)_zkemKeeper.GetType().InvokeMember(
                    "SetDeviceTime2",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    _zkemKeeper,
                    new object[] { 1, dateTime.Year, dateTime.Month, dateTime.Day, 
                        dateTime.Hour, dateTime.Minute, dateTime.Second });
                
                if (success)
                {
                    // Refresh device time after setting
                    _zkemKeeper.GetType().InvokeMember(
                        "RefreshData",
                        System.Reflection.BindingFlags.InvokeMethod,
                        null,
                        _zkemKeeper,
                        new object[] { 1 });
                }
                
                return success;
            }
            catch (Exception ex)
            {
                throw new Exception("Error setting device time: " + ex.Message);
            }
        }
        
        /// <summary>
        /// Enables or disables the connected device
        /// </summary>
        /// <param name="enable">True to enable, false to disable</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool EnableDevice(bool enable)
        {
            if (!_connected)
            {
                throw new Exception("Device not connected");
            }
            
            try
            {
                // Enable or disable the device
                bool success = (bool)_zkemKeeper.GetType().InvokeMember(
                    enable ? "EnableDevice" : "DisableDevice",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    _zkemKeeper,
                    new object[] { 1, enable });
                
                return success;
            }
            catch (Exception ex)
            {
                throw new Exception("Error " + (enable ? "enabling" : "disabling") + " device: " + ex.Message);
            }
        }
        
        /// <summary>
        /// Clears all attendance data from the connected device
        /// </summary>
        /// <returns>True if successful, false otherwise</returns>
        public bool ClearData()
        {
            if (!_connected)
            {
                throw new Exception("Device not connected");
            }
            
            try
            {
                // Clear all attendance logs
                bool success = (bool)_zkemKeeper.GetType().InvokeMember(
                    "ClearGLog",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    _zkemKeeper,
                    new object[] { 1 });
                
                if (success)
                {
                    // Refresh device data after clearing
                    _zkemKeeper.GetType().InvokeMember(
                        "RefreshData",
                        System.Reflection.BindingFlags.InvokeMethod,
                        null,
                        _zkemKeeper,
                        new object[] { 1 });
                }
                
                return success;
            }
            catch (Exception ex)
            {
                throw new Exception("Error clearing device data: " + ex.Message);
            }
        }
        
        /// <summary>
        /// Gets attendance records from the connected device
        /// </summary>
        /// <returns>A list of attendance records</returns>
        public List<AttendanceRecord> GetAttendanceRecords()
        {
            if (!_connected)
            {
                throw new Exception("Device not connected");
            }
            
            List<AttendanceRecord> records = new List<AttendanceRecord>();
            
            try
            {
                // Read all attendance logs
                bool success = (bool)_zkemKeeper.GetType().InvokeMember(
                    "ReadGeneralLogData",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    _zkemKeeper,
                    new object[] { 1 });
                
                if (success)
                {
                    // Declare variables to receive log data
                    int enrollNumber = 0;
                    int verifyMode = 0;
                    int inOutMode = 0;
                    int year = 0, month = 0, day = 0, hour = 0, minute = 0, second = 0;
                    int workCode = 0;
                    
                    // Get each record one by one
                    while ((bool)_zkemKeeper.GetType().InvokeMember(
                        "SSR_GetGeneralLogData",
                        System.Reflection.BindingFlags.InvokeMethod,
                        null,
                        _zkemKeeper,
                        new object[] { 1, ref enrollNumber, ref verifyMode, ref inOutMode, 
                            ref year, ref month, ref day, ref hour, ref minute, ref second, ref workCode }))
                    {
                        try
                        {
                            // Create a new attendance record
                            var record = new AttendanceRecord
                            {
                                EmployeeId = enrollNumber,
                                RecordTime = new DateTime(year, month, day, hour, minute, second),
                                VerifyMode = verifyMode,
                                WorkCode = workCode,
                                CreatedDate = DateTime.Now,
                                IsProcessed = false
                            };
                            
                            // Determine record type based on inOutMode
                            // This may depend on the specific device model and settings
                            switch (inOutMode)
                            {
                                case 0:
                                    record.RecordType = AttendanceType.CheckIn;
                                    break;
                                case 1:
                                    record.RecordType = AttendanceType.CheckOut;
                                    break;
                                case 2:
                                    record.RecordType = AttendanceType.BreakStart;
                                    break;
                                case 3:
                                    record.RecordType = AttendanceType.BreakEnd;
                                    break;
                                case 4:
                                    record.RecordType = AttendanceType.OvertimeStart;
                                    break;
                                case 5:
                                    record.RecordType = AttendanceType.OvertimeEnd;
                                    break;
                                default:
                                    record.RecordType = AttendanceType.Unknown;
                                    break;
                            }
                            
                            records.Add(record);
                        }
                        catch
                        {
                            // Skip records with invalid dates or other errors
                            continue;
                        }
                    }
                }
                
                return records;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving attendance records: " + ex.Message);
            }
        }
        
        /// <summary>
        /// Saves the connection settings to the database
        /// </summary>
        /// <param name="ipAddress">The IP address</param>
        /// <param name="port">The port number</param>
        /// <param name="password">The password (if any)</param>
        private void SaveConnectionSettings(string ipAddress, int port, string password)
        {
            try
            {
                // Use the settings service to save the connection settings
                var settingsService = new SettingsService();
                var settings = settingsService.GetConnectionSettings() ?? new ConnectionSettings();
                
                settings.IPAddress = ipAddress;
                settings.Port = port;
                settings.Password = password;
                settings.LastConnected = DateTime.Now;
                settings.LastModified = DateTime.Now;
                
                settingsService.SaveConnectionSettings(settings);
            }
            catch
            {
                // Ignore errors when saving connection settings
                // This is not critical to device operation
            }
        }
    }
}