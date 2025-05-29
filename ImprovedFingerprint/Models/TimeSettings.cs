using System;

namespace ImprovedFingerprint.Models
{
    public class TimeSettings
    {
        public int SettingId { get; set; }
        public string ShiftName { get; set; } // اسم الوردية
        public TimeSpan CheckInStartTime { get; set; } // بداية وقت الدخول
        public TimeSpan CheckInEndTime { get; set; } // نهاية وقت الدخول
        public TimeSpan CheckOutStartTime { get; set; } // بداية وقت الخروج
        public TimeSpan CheckOutEndTime { get; set; } // نهاية وقت الخروج
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Notes { get; set; }
    }

    public static class DefaultTimeSettings
    {
        public static TimeSettings MorningShift => new TimeSettings
        {
            ShiftName = "الوردية الصباحية",
            CheckInStartTime = new TimeSpan(6, 0, 0),   // 6:00 صباحاً
            CheckInEndTime = new TimeSpan(10, 59, 0),   // 10:59 صباحاً
            CheckOutStartTime = new TimeSpan(11, 0, 0), // 11:00 صباحاً
            CheckOutEndTime = new TimeSpan(13, 0, 0),   // 13:00 ظهراً
            IsActive = true
        };

        public static TimeSettings EveningShift => new TimeSettings
        {
            ShiftName = "الوردية المسائية",
            CheckInStartTime = new TimeSpan(14, 0, 0),  // 14:00 ظهراً
            CheckInEndTime = new TimeSpan(18, 59, 0),   // 18:59 مساءً
            CheckOutStartTime = new TimeSpan(19, 0, 0), // 19:00 مساءً
            CheckOutEndTime = new TimeSpan(21, 0, 0),   // 21:00 ليلاً
            IsActive = true
        };

        public static TimeSettings NightShift => new TimeSettings
        {
            ShiftName = "الوردية الليلية",
            CheckInStartTime = new TimeSpan(22, 0, 0),  // 22:00 ليلاً
            CheckInEndTime = new TimeSpan(2, 59, 0),    // 02:59 فجراً
            CheckOutStartTime = new TimeSpan(3, 0, 0),  // 03:00 فجراً
            CheckOutEndTime = new TimeSpan(5, 0, 0),    // 05:00 فجراً
            IsActive = true
        };
    }
}