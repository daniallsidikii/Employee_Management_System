namespace Employee_Management_System
{
    // This class represents a single attendance record.
    public class AttendanceRecord
    {
        public string? Username { get; set; } // The username of the employee
        public string? Date { get; set; } // The date of the attendance record
        public string? Log { get; set; } // The log details of the attendance
    }
}