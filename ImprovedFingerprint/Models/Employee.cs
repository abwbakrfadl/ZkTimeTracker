using System;

namespace ImprovedFingerprint.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeNumber { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public DateTime HireDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public int DeviceUserId { get; set; } // معرف المستخدم في جهاز البصمة
        public byte[] FingerprintTemplate { get; set; } // قالب البصمة
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Notes { get; set; }
        public string Shift { get; set; } // الوردية (صباحي، مسائي، ليلي)
    }
}