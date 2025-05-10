namespace Employee_Management_System
{
    // This class represents an attendance record for an employee.
    // It contains properties for the username, date, and log of the attendance.
    public class AttendanceData
    {
        public List<string> Logs { get; set; } = new List<string>();
        public bool HasMarkedAttendance { get; set; }
        public bool HasClockedOut { get; set; }
        public DateTime? ClockInTime { get; set; } // Persist clock-in time
        public TimeSpan? WorkDuration { get; set; } // Optional: Track worked hours
    }
}