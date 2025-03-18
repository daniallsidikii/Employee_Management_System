using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace Employee_Management_System
{
    public partial class EmployeeDashboard : Window
    {
        private DateTime? clockInTime; // Store clock-in time
        private List<string> attendanceLogs = new List<string>(); // Store attendance logs
        private DispatcherTimer breakReminderTimer = new DispatcherTimer(); // Break reminder timer
        private int skippedBreaksCount = 0; // Track skipped breaks

        public EmployeeDashboard()
        {
            InitializeComponent();
            InitializeBreakReminder(); // Initialize the break reminder timer
            StartClock(); // Start the digital clock
        }

        // Start the digital clock
        private void StartClock()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // Update every second
            timer.Tick += (sender, e) => { txtClock.Text = DateTime.Now.ToString("hh:mm:ss tt"); };
            timer.Start();
        }

        // Clock In - Record clock-in time
        private void ClockIn_Click(object sender, RoutedEventArgs e)
        {
            if (clockInTime != null)
            {
                ShowMessage("You are already Clocked-In.", "Warning", MessageBoxImage.Warning);
                return;
            }
            clockInTime = DateTime.Now;
            string log = $"Clocked In at {clockInTime.Value:hh:mm tt}";
            attendanceLogs.Add(log);

            ShowMessage(log, "Clock-In", MessageBoxImage.Information);
        }

        // Clock Out - Calculate worked time and log it
        private void ClockOut_Click(object sender, RoutedEventArgs e)
        {
            if (clockInTime == null)
            {
                ShowMessage("You must Clock-In first!", "Error", MessageBoxImage.Error);
                return;
            }
            DateTime clockOutTime = DateTime.Now;
            TimeSpan workDuration = clockOutTime - clockInTime.Value;

            string log = $"Clocked Out at {clockOutTime:hh:mm tt}. | Worked: {workDuration.TotalHours:F2} hours.";
            attendanceLogs.Add(log);

            ShowMessage(log, "Clock-Out", MessageBoxImage.Information);
        }

        // View Attendance Logs
        private void ViewAttendanceLogs_Click(object sender, RoutedEventArgs e)
        {
            string records = string.Join("\n", attendanceLogs);
            if (records == string.Empty)
            {
                records = "No attendance records available.";
            }
            MessageBox.Show(records, "Attendance Records", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Health Records - Open Health Records Window
        private void HealthRecords_Click(object sender, RoutedEventArgs e)
        {
            HealthRecordsWindow healthRecordsWindow = new HealthRecordsWindow();
            healthRecordsWindow.Show();
        }

        // Helper Method: Show a message box
        private void ShowMessage(string message, string title, MessageBoxImage icon)
        {
            MessageBox.Show(message, title, MessageBoxButton.OK, icon);
        }

        // Logout - Redirect to Login Window
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        // Initialize and start the break reminder timer
        private void InitializeBreakReminder()
        {
            breakReminderTimer = new DispatcherTimer();
            breakReminderTimer.Interval = TimeSpan.FromMinutes(3); // Set interval to 3 minutes
            breakReminderTimer.Tick += BreakReminderTimer_Tick;
            breakReminderTimer.Start();
        }

        // Event handler for break reminder timer
        private void BreakReminderTimer_Tick(object? sender, EventArgs e)
        {
            var result = MessageBox.Show("Time to take a break!", "Break Reminder", MessageBoxButton.OKCancel, MessageBoxImage.Information);

            if (result == MessageBoxResult.Cancel)
            {
                skippedBreaksCount++;
                if (skippedBreaksCount >= 3)
                {
                    MessageBox.Show("You have skipped three breaks. The system will now shut down.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Application.Current.Shutdown();
                }
            }
            else
            {
                skippedBreaksCount = 0; // Reset the count if the break is taken
            }
        }
    }
}