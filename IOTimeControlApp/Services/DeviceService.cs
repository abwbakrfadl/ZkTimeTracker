using System;
using System.Runtime.InteropServices;

namespace IOTimeControlApp.Services
{
    public class DeviceService
    {
        private object _zkemKeeper;
        private bool _isConnected = false;
        private int _machineNumber = 1;

        public bool IsConnected => _isConnected;

        public DeviceService()
        {
            try
            {
                // إنشاء COM object لـ ZKemKeeper
                Type type = Type.GetTypeFromProgID("zkemkeeper.ZKEM");
                if (type != null)
                {
                    _zkemKeeper = Activator.CreateInstance(type);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"خطأ في تهيئة خدمة الجهاز: {ex.Message}");
            }
        }

        public bool Connect(string ipAddress, int port)
        {
            try
            {
                if (_zkemKeeper == null)
                {
                    throw new Exception("لم يتم تهيئة خدمة الجهاز بشكل صحيح");
                }

                // محاولة الاتصال بالجهاز
                bool connected = (bool)_zkemKeeper.GetType().InvokeMember(
                    "Connect_Net",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    _zkemKeeper,
                    new object[] { ipAddress, port });

                if (connected)
                {
                    _isConnected = true;
                    
                    // تمكين الجهاز
                    _zkemKeeper.GetType().InvokeMember(
                        "EnableDevice",
                        System.Reflection.BindingFlags.InvokeMethod,
                        null,
                        _zkemKeeper,
                        new object[] { _machineNumber, true });
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
                    // قطع الاتصال بالجهاز
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

        public bool SetTimeZone(int timeZoneId, TimeSpan startTime, TimeSpan endTime, params int[] weekDays)
        {
            try
            {
                if (!_isConnected || _zkemKeeper == null)
                {
                    return false;
                }

                // ضبط المنطقة الزمنية
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
                        weekDays.Length > 0 ? weekDays[0] : 1, // الأحد
                        weekDays.Length > 1 ? weekDays[1] : 1, // الاثنين
                        weekDays.Length > 2 ? weekDays[2] : 1, // الثلاثاء
                        weekDays.Length > 3 ? weekDays[3] : 1, // الأربعاء
                        weekDays.Length > 4 ? weekDays[4] : 1, // الخميس
                        weekDays.Length > 5 ? weekDays[5] : 1, // الجمعة
                        weekDays.Length > 6 ? weekDays[6] : 1  // السبت
                    });

                return success;
            }
            catch
            {
                return false;
            }
        }

        public bool RefreshData()
        {
            try
            {
                if (!_isConnected || _zkemKeeper == null)
                {
                    return false;
                }

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

        public string GetDeviceInfo()
        {
            try
            {
                if (!_isConnected || _zkemKeeper == null)
                {
                    return "غير متصل";
                }

                // الحصول على معلومات الجهاز
                string firmwareVersion = "";
                string serialNumber = "";

                // محاولة الحصول على رقم الإصدار
                object[] args = new object[] { _machineNumber, firmwareVersion };
                _zkemKeeper.GetType().InvokeMember(
                    "GetFirmwareVersion",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    _zkemKeeper,
                    args);
                firmwareVersion = args[1].ToString();

                // محاولة الحصول على الرقم التسلسلي
                args = new object[] { _machineNumber, serialNumber };
                _zkemKeeper.GetType().InvokeMember(
                    "GetSerialNumber",
                    System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    _zkemKeeper,
                    args);
                serialNumber = args[1].ToString();

                return $"إصدار البرنامج الثابت: {firmwareVersion}\nالرقم التسلسلي: {serialNumber}";
            }
            catch
            {
                return "متصل - لا يمكن الحصول على تفاصيل إضافية";
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