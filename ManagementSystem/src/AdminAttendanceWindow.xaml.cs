using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Linq;

namespace Employee_Management_System
{
    public partial class AdminAttendanceWindow : Window
    {
        public AdminAttendanceWindow()
        {
            InitializeComponent();
            LoadAllAttendance();
        }

       private void CloseButton_Click(object sender, RoutedEventArgs e)
{
    this.Close();
}
        private void LoadAllAttendance()
        {
            string attendanceDir = "Attendance";
            List<AttendanceRecord> allRecords = new List<AttendanceRecord>();

            if (!Directory.Exists(attendanceDir))
            {
                Directory.CreateDirectory(attendanceDir);
                MessageBox.Show("Attendance directory was missing and has been created. Please add attendance files.");
                return;
           }

            if (Directory.Exists(attendanceDir))
            {
                foreach (var file in Directory.GetFiles(attendanceDir, "*_AttendanceLogs.json"))
                {
                    string username = Path.GetFileNameWithoutExtension(file).Replace("_AttendanceLogs", "");
                    try
                    {
                        string json = File.ReadAllText(file);
                        var logs = JsonSerializer.Deserialize<Dictionary<string, AttendanceData>>(json);

                        if (logs != null)
                        {
                            foreach (var entry in logs)
                            {
                                foreach (string logLine in entry.Value.Logs)
                                {
                                    allRecords.Add(new AttendanceRecord
                                    {
                                        Username = username,
                                        Date = entry.Key,
                                        Log = logLine
                                    });
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to read {file}:\n{ex.Message}");
                    }
                }

                AttendanceGrid.ItemsSource = allRecords.OrderByDescending(r => r.Date).ToList();
            }
            else
            {
                MessageBox.Show("Attendance directory not found.");
            }
        }
    }
}
