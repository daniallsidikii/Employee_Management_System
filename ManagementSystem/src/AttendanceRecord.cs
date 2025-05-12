public class AttendanceRecord
{
    public string? Username { get; set; }
    public string? Date { get; set; } // still useful for display
    public string? Log { get; set; }
    // New property: LogType (e.g., "Clock In", "Clock Out", "Other")
    public string? LogType { get; set; }

    // New property: LogMessage (e.g., the detailed log message)
    public string? LogMessage { get; set;}

    // Safe date parsing using the correct format
    public DateTime ParsedDate
{
    get
    {
        DateTime.TryParseExact(
            Date,
            "MM/dd/yyyy",
            System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.None,
            out DateTime parsed);
        return parsed;
    }
}

}
