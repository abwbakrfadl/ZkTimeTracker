using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ImprovedFingerprint.Models;

namespace ImprovedFingerprint.Services
{
    public class DeviceService
    {
        private object _zkemKeeper;
        private bool _isConnected = false;
        private int _machineNumber = 1;
        private string _deviceIP;
        private int _devicePort;

        public bool IsConnected => _isConnected;
        public string DeviceInfo { get; private set; }

        public DeviceService()
        {
            try
            {
                Type type = Type.GetTypeFromProgID("zkemkeeper.ZKEM");
                if (type != null)
                {
                    _zkemKeeper = Activator.CreateInstance(type);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"خطأ في تهيئة خدمة الجهاز. تأكد من تثبيت zkemkeeper.dll: {ex.Message}");
            }
        }

        public bool Connect(string ipAddress, int port)
        {
            try
            {
                if (_zkemKeeper == null)
                    throw new Exception("لم يتم تهيئة خدمة الجهاز بشكل صحيح");

                _deviceIP = ipAddress;
                _devicePort = port;

                bool connected = (bool)_zkemKeeper.GetType().InvokeMember(
                    "Connect_Net",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    _zkemKeeper,
                    new object[] { ipAddress, port });

                if (connected)
                {
                    _isConnected = true;
                    EnableDevice(true);
                    GetDeviceInfo();
                }

                return connected;
            }
            catch (Exception ex)
            {
                throw new Exception($"خطأ في الاتصال بالجهاز: {ex.Message}");
            }
        }

        public void Disconnect()
        {
            try
            {
                if (_zkemKeeper != null && _isConnected)
                {
                    EnableDevice(true);
                    _zkemKeeper.GetType().InvokeMember(
                        "Disconnect",
                        System.Reflection.BindingFlags.InvokeMethod,
                        null,
                        _zkemKeeper,
                        new object[] { });
                    _isConnected = false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"خطأ في قطع الاتصال: {ex.Message}");
            }
        }

        private void EnableDevice(bool enable)
        {
            if (_zkemKeeper != null && _isConnected)
            {
                _zkemKeeper.GetType().InvokeMember(
                    "EnableDevice",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    _zkemKeeper,
                    new object[] { _machineNumber, enable });
            }
        }

        public bool SetTimeZone(int timeZoneId, TimeSpan startTime, TimeSpan endTime)
        {
            try
            {
                if (!_isConnected || _zkemKeeper == null)
                    return false;

                EnableDevice(false);

                bool success = (bool)_zkemKeeper.GetType().InvokeMember(
                    "SetUserTZ",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    _zkemKeeper,
                    new object[] { 
                        _machineNumber,
                        timeZoneId,
                        startTime.Hours,
                        startTime.Minutes,
                        endTime.Hours,
                        endTime.Minutes,
                        1, 1, 1, 1, 1, 1, 1 // جميع أيام الأسبوع
                    });

                EnableDevice(true);
                return success;
            }
            catch
            {
                EnableDevice(true);
                return false;
            }
        }

        public bool RefreshData()
        {
            try
            {
                if (!_isConnected || _zkemKeeper == null)
                    return false;

                bool success = (bool)_zkemKeeper.GetType().InvokeMember(
                    "RefreshData",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    _zkemKeeper,
                    new object[] { _machineNumber });

                return success;
            }
            catch
            {
                return false;
            }
        }

        public List<Employee> GetAllEmployees()
        {
            var employees = new List<Employee>();
            
            try
            {
                if (!_isConnected || _zkemKeeper == null)
                    return employees;

                EnableDevice(false);

                // قراءة جميع المستخدمين من الجهاز
                _zkemKeeper.GetType().InvokeMember(
                    "ReadAllUserID",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    _zkemKeeper,
                    new object[] { _machineNumber });

                string userId = "", name = "", password = "", privilege = "", enabled = "";
                while ((bool)_zkemKeeper.GetType().InvokeMember(
                    "SSR_GetAllUserInfo",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    _zkemKeeper,
                    new object[] { _machineNumber, userId, name, password, privilege, enabled }))
                {
                    var employee = new Employee
                    {
                        DeviceUserId = int.Parse(userId),
                        EmployeeNumber = userId,
                        FullName = name,
                        IsActive = enabled == "1",
                        CreatedDate = DateTime.Now
                    };
                    
                    employees.Add(employee);
                }

                EnableDevice(true);
            }
            catch (Exception ex)
            {
                EnableDevice(true);
                throw new Exception($"خطأ في قراءة بيانات الموظفين: {ex.Message}");
            }

            return employees;
        }

        public List<AttendanceRecord> GetAttendanceRecords()
        {
            var records = new List<AttendanceRecord>();
            
            try
            {
                if (!_isConnected || _zkemKeeper == null)
                    return records;

                EnableDevice(false);

                // قراءة سجلات الحضور
                _zkemKeeper.GetType().InvokeMember(
                    "ReadGeneralLogData",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    _zkemKeeper,
                    new object[] { _machineNumber });

                string userId = "", verifyMode = "", inOutMode = "", year = "", 
                       month = "", day = "", hour = "", minute = "", second = "", workCode = "";

                while ((bool)_zkemKeeper.GetType().InvokeMember(
                    "SSR_GetGeneralLogData",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    _zkemKeeper,
                    new object[] { _machineNumber, userId, verifyMode, inOutMode, 
                                 year, month, day, hour, minute, second, workCode }))
                {
                    var attendanceDate = new DateTime(
                        int.Parse(year), 
                        int.Parse(month), 
                        int.Parse(day),
                        int.Parse(hour), 
                        int.Parse(minute), 
                        int.Parse(second));

                    var record = new AttendanceRecord
                    {
                        EmployeeNumber = userId,
                        AttendanceDateTime = attendanceDate,
                        Type = inOutMode == "0" ? AttendanceType.CheckIn : AttendanceType.CheckOut,
                        Source = AttendanceSource.Device,
                        DeviceId = _deviceIP,
                        CreatedDate = DateTime.Now,
                        IsProcessed = false
                    };
                    
                    records.Add(record);
                }

                EnableDevice(true);
            }
            catch (Exception ex)
            {
                EnableDevice(true);
                throw new Exception($"خطأ في قراءة سجلات الحضور: {ex.Message}");
            }

            return records;
        }

        public bool ClearAttendanceRecords()
        {
            try
            {
                if (!_isConnected || _zkemKeeper == null)
                    return false;

                EnableDevice(false);

                bool success = (bool)_zkemKeeper.GetType().InvokeMember(
                    "ClearGLog",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    _zkemKeeper,
                    new object[] { _machineNumber });

                EnableDevice(true);
                return success;
            }
            catch
            {
                EnableDevice(true);
                return false;
            }
        }

        private void GetDeviceInfo()
        {
            try
            {
                string firmwareVersion = "";
                string serialNumber = "";
                string deviceName = "";

                object[] args1 = new object[] { _machineNumber, firmwareVersion };
                _zkemKeeper.GetType().InvokeMember(
                    "GetFirmwareVersion",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    _zkemKeeper,
                    args1);
                firmwareVersion = args1[1].ToString();

                object[] args2 = new object[] { _machineNumber, serialNumber };
                _zkemKeeper.GetType().InvokeMember(
                    "GetSerialNumber",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    _zkemKeeper,
                    args2);
                serialNumber = args2[1].ToString();

                object[] args3 = new object[] { _machineNumber, deviceName };
                _zkemKeeper.GetType().InvokeMember(
                    "GetDeviceInfo",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    _zkemKeeper,
                    args3);
                deviceName = args3[1].ToString();

                DeviceInfo = $"اسم الجهاز: {deviceName}\nإصدار البرنامج الثابت: {firmwareVersion}\nالرقم التسلسلي: {serialNumber}";
            }
            catch
            {
                DeviceInfo = "متصل - لا يمكن الحصول على تفاصيل إضافية";
            }
        }

        public void Dispose()
        {
            if (_isConnected)
            {
                Disconnect();
            }

            if (_zkemKeeper != null)
            {
                Marshal.ReleaseComObject(_zkemKeeper);
                _zkemKeeper = null;
            }
        }
    }
}