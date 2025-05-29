using System;
using System.Configuration;

namespace ImprovedFingerprint.Helpers
{
    public static class AppSettings
    {
        public static string GetConnectionString(string name)
        {
            try
            {
                return ConfigurationManager.ConnectionStrings[name]?.ConnectionString;
            }
            catch (Exception ex)
            {
                throw new Exception($"خطأ في قراءة نص الاتصال بقاعدة البيانات: {ex.Message}");
            }
        }

        public static string GetAppSetting(string key, string defaultValue = "")
        {
            try
            {
                return ConfigurationManager.AppSettings[key] ?? defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }

        public static int GetAppSettingInt(string key, int defaultValue = 0)
        {
            try
            {
                var value = ConfigurationManager.AppSettings[key];
                return int.TryParse(value, out int result) ? result : defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }

        public static bool GetAppSettingBool(string key, bool defaultValue = false)
        {
            try
            {
                var value = ConfigurationManager.AppSettings[key];
                return bool.TryParse(value, out bool result) ? result : defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }
    }
}