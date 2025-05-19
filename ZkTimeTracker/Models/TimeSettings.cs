using System;

namespace ZKTecoAttendanceSystem.Models
{
    /// <summary>
    /// Represents time settings for attendance tracking
    /// </summary>
    public class TimeSettings
    {
        /// <summary>
        /// Unique identifier for the time settings
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Start time for morning shift
        /// </summary>
        public TimeSpan MorningShiftStart { get; set; }
        
        /// <summary>
        /// End time for morning shift
        /// </summary>
        public TimeSpan MorningShiftEnd { get; set; }
        
        /// <summary>
        /// Start time for afternoon shift
        /// </summary>
        public TimeSpan AfternoonShiftStart { get; set; }
        
        /// <summary>
        /// End time for afternoon shift
        /// </summary>
        public TimeSpan AfternoonShiftEnd { get; set; }
        
        /// <summary>
        /// Threshold for late arrival
        /// </summary>
        public TimeSpan LateArrivalThreshold { get; set; }
        
        /// <summary>
        /// Threshold for early departure
        /// </summary>
        public TimeSpan EarlyDepartureThreshold { get; set; }
        
        /// <summary>
        /// Start time for overtime
        /// </summary>
        public TimeSpan OvertimeStart { get; set; }
        
        /// <summary>
        /// Last modified date
        /// </summary>
        public DateTime LastModified { get; set; }
    }
}