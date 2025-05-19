using System;

namespace ZKTecoAttendanceSystem.Models
{
    /// <summary>
    /// Represents an attendance record from the fingerprint device
    /// </summary>
    public class AttendanceRecord
    {
        /// <summary>
        /// Unique identifier for the attendance record
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Employee ID from the fingerprint device
        /// </summary>
        public int EmployeeId { get; set; }
        
        /// <summary>
        /// Time the attendance was recorded
        /// </summary>
        public DateTime RecordTime { get; set; }
        
        /// <summary>
        /// Type of attendance record (check-in, check-out, etc.)
        /// </summary>
        public AttendanceType RecordType { get; set; }
        
        /// <summary>
        /// Verification mode (fingerprint, card, password, etc.)
        /// </summary>
        public int VerifyMode { get; set; }
        
        /// <summary>
        /// Work code if any
        /// </summary>
        public int WorkCode { get; set; }
        
        /// <summary>
        /// Date the record was created in the database
        /// </summary>
        public DateTime CreatedDate { get; set; }
        
        /// <summary>
        /// Flag to indicate if record has been processed
        /// </summary>
        public bool IsProcessed { get; set; }
    }
    
    /// <summary>
    /// Types of attendance records
    /// </summary>
    public enum AttendanceType
    {
        /// <summary>
        /// Check-in record
        /// </summary>
        CheckIn = 0,
        
        /// <summary>
        /// Check-out record
        /// </summary>
        CheckOut = 1,
        
        /// <summary>
        /// Break start record
        /// </summary>
        BreakStart = 2,
        
        /// <summary>
        /// Break end record
        /// </summary>
        BreakEnd = 3,
        
        /// <summary>
        /// Overtime start record
        /// </summary>
        OvertimeStart = 4,
        
        /// <summary>
        /// Overtime end record
        /// </summary>
        OvertimeEnd = 5,
        
        /// <summary>
        /// Unknown or unclassified record
        /// </summary>
        Unknown = 99
    }
}