using System;

namespace ImprovedFingerprint.Models
{
    public class AttendanceRecord
    {
        public int RecordId { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeNumber { get; set; }
        public string EmployeeName { get; set; }
        public DateTime AttendanceDateTime { get; set; }
        public AttendanceType Type { get; set; } // دخول أو خروج
        public AttendanceSource Source { get; set; } // جهاز البصمة أو يدوي
        public string DeviceId { get; set; }
        public string Notes { get; set; }
        public bool IsProcessed { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Shift { get; set; } // الوردية
        public TimeSpan? WorkingHours { get; set; } // ساعات العمل المحسوبة
        public bool IsLate { get; set; } // هل تأخر في الحضور
        public bool IsEarlyLeave { get; set; } // هل غادر مبكراً
        public TimeSpan? LateMinutes { get; set; } // دقائق التأخير
        public TimeSpan? EarlyLeaveMinutes { get; set; } // دقائق المغادرة المبكرة
    }

    public enum AttendanceType
    {
        CheckIn = 0,  // دخول
        CheckOut = 1  // خروج
    }

    public enum AttendanceSource
    {
        Device = 0,   // جهاز البصمة
        Manual = 1    // إدخال يدوي
    }
}