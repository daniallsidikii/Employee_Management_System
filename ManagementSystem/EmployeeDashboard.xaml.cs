using System;
using System.Windows;

namespace OHSAdminPanel
{
    public partial class EmployeeDashboard : Window
    {
        private DateTime? clockInTime; // Store clock-in time

        public EmployeeDashboard()
        {
            InitializeComponent();
        }

        // Mark Attendance (You could expand this later to log time)
        private void MarkAttendance_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Attendance Marked Successfully!", "Attendance", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Clock In - Record clock-in time
        private void ClockIn_Click(object sender, RoutedEventArgs e)
        {
            if (clockInTime == null)
            {
                clockInTime = DateTime.Now;
                MessageBox.Show($"Clocked In Successfully at {clockInTime.Value.ToShortTimeString()}", "Attendance", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("You are already Clocked-In.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Clock Out - Calculate worked time
        private void ClockOut_Click(object sender, RoutedEventArgs e)
        {
            if (clockInTime != null)
            {
                DateTime clockOutTime = DateTime.Now;
                TimeSpan workDuration = clockOutTime - clockInTime.Value;
                MessageBox.Show($"Clocked Out at {clockOutTime.ToShortTimeString()}\nTotal Worked: {workDuration.TotalHours:F2} hours.", "Attendance", MessageBoxButton.OK, MessageBoxImage.Information);
                clockInTime = null; // Reset for next session
            }
            else
            {
                MessageBox.Show("You must Clock-In first!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // View Health Records (Static Information for Now)
        private void ViewHealthRecords_Click(object sender, RoutedEventArgs e)
        {
            ShowHealthDetails();
        }

        // Consolidated Health Information Display
        private void ViewHealth_Click(object sender, RoutedEventArgs e)
        {
            ShowHealthDetails();
        }

        // Helper Method for Health Records
        private void ShowHealthDetails()
        {
            string healthInfo = "Blood Pressure: Normal\nVision: 20/20\nLast Checkup: 2024-03-01";
            MessageBox.Show(healthInfo, "Health Records", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Logout - Redirect to Login Window
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
