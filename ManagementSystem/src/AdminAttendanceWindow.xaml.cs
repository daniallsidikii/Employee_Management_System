using System;
using System.Windows.Controls;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Linq;

namespace Employee_Management_System
{
    public partial class AdminAttendanceWindow : Window
    {
        private List<AttendanceRecord> allRecords = new List<AttendanceRecord>();
        private DateTime? selectedDate = null; // Default to no date filter
        private string selectedLogType = "All Logs"; // Default to "All Logs"

        public AdminAttendanceWindow()
        {
            InitializeComponent();
            LoadAllAttendance();
        }

        /// <summary>
        /// Closes the window.
        /// </summary>
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Loads all attendance records from the Attendance directory.
        /// </summary>
       private void LoadAllAttendance()
{
    allRecords.Clear();
    string attendanceDir = "Attendance";

    if (!Directory.Exists(attendanceDir))
    {
        Directory.CreateDirectory(attendanceDir);
        MessageBox.Show("Attendance directory was missing and has been created. Please add attendance files.");
        return;
    }

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
                        // Determine the log type
                        string logType = logLine.Contains("Clocked in", StringComparison.OrdinalIgnoreCase) ? "Clock In" :
                                         logLine.Contains("Clocked out", StringComparison.OrdinalIgnoreCase) ? "Clock Out" :
                                         "Attendance"; // Default to "Attendance" for unmatched logs

                        allRecords.Add(new AttendanceRecord
                        {
                            Username = username,
                            Date = entry.Key,
                            LogType = logType,
                            LogMessage = logLine
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

    // Bind all records to the DataGrid
    AttendanceGrid.ItemsSource = allRecords
        .OrderByDescending(r => DateTime.TryParse(r.Date, out var dt) ? dt : DateTime.MinValue)
        .ToList();
}

        /// <summary>
        /// Applies filters to attendance records based on the selected date and log type.
        /// </summary>
        private void ApplyFilters()
        {
            var filteredRecords = allRecords.AsEnumerable();

            // Filter by selected date
            if (selectedDate.HasValue)
            {
                filteredRecords = filteredRecords.Where(r => r.ParsedDate == selectedDate.Value);
            }

            // Filter by selected log type
            if (selectedLogType != "All Logs")
            {
                filteredRecords = filteredRecords.Where(r => r.LogType == selectedLogType);
            }

            // Update the DataGrid with filtered results
            AttendanceGrid.ItemsSource = filteredRecords.OrderBy(r => r.ParsedDate).ToList();
        }

        /// <summary>
        /// Filters attendance records when the log type is selected in the TreeView.
        /// </summary>
        private void LogTypeTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (LogTypeTreeView.SelectedItem is TreeViewItem selectedItem)
            {
                // Update the selected log type
                selectedLogType = selectedItem.Header?.ToString() ?? "All Logs";
                ApplyFilters();
            }
        }

        /// <summary>
        /// Filters attendance records when the date is selected in the DatePicker.
        /// </summary>
        private void DateFilterPicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DateFilterPicker.SelectedDate.HasValue)
            {
                selectedDate = DateFilterPicker.SelectedDate.Value.Date;
            }
            else
            {
                selectedDate = null; // If no date is selected, show all records
            }

            ApplyFilters();
        }

        /// <summary>
        /// Clears the date and log type filter and reloads all attendance records.
        /// </summary>
        private void ClearFilter_Click(object sender, RoutedEventArgs e)
        {
            DateFilterPicker.SelectedDate = null; // Clear the date filter
            selectedDate = null; // Reset the date filter

            // Reset the log type filter to "All Logs"
            selectedLogType = "All Logs";

            ApplyFilters(); // Apply the reset filters and refresh the DataGrid
        }
    }
}