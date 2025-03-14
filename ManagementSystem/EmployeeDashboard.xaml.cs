using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace OHSAdminPanel
{
    public class HealthRecord
    {
        public string? BloodPressure { get; set; }
        public string? Vision { get; set; }
        public DateTime LastCheckup { get; set; }
    }
    public partial class EmployeeDashboard : Window
    {
        private DateTime? clockInTime; // Store clock-in time
        private List<string> attendanceLogs = new List<string>(); // Store attendance logs
        private HealthRecord employeeHealthRecord = new HealthRecord();
        private DispatcherTimer breakReminderTimer = new DispatcherTimer(); // Break reminder timer
        private int skippedBreaksCount = 0; // Track skipped breaks

        public EmployeeDashboard()
        {
            InitializeComponent();
            LoadHealthRecord();
            InitializeBreakReminder();
        }

        // Initialize Sample Health Data
        private void LoadHealthRecord()
        {
            employeeHealthRecord = new HealthRecord
            {
                BloodPressure = "120/80 mmHg",
                Vision = "20/20",
                LastCheckup = DateTime.Now.AddMonths(-1)
            };
            DisplayHealthRecord();
        }

        // Display Health Records on UI
        private void DisplayHealthRecord()
        {
            txtBloodPressure.Text = employeeHealthRecord.BloodPressure;
            txtVision.Text = employeeHealthRecord.Vision;
            txtLastCheckup.Text = employeeHealthRecord.LastCheckup.ToShortDateString();
        }

        // Save Health Records
        private void SaveHealthRecords_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateHealthInputs())
            {
                employeeHealthRecord.BloodPressure = txtBloodPressure.Text;
                employeeHealthRecord.Vision = txtVision.Text;
                employeeHealthRecord.LastCheckup = DateTime.Parse(txtLastCheckup.Text);

                MessageBox.Show("Health Records Updated.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                DisplayHealthRecord();
                CheckHealthAlerts();
            }
        }

        // Validate Health Inputs
        private bool ValidateHealthInputs()
        {
            bool isValid = true;

            if (!DateTime.TryParse(txtLastCheckup.Text, out _))
            {
                MessageBox.Show("Invalid date format for Last Checkup.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtBloodPressure.Text) || string.IsNullOrWhiteSpace(txtVision.Text))
            {
                MessageBox.Show("Blood Pressure and Vision cannot be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                isValid = false;
            }

            // Additional validation for Blood Pressure and Vision
            string[] bpValues = txtBloodPressure.Text.Split('/');
            if (bpValues.Length != 2 || !int.TryParse(bpValues[0], out int systolic) || !int.TryParse(bpValues[1].Split(' ')[0], out int diastolic))
            {
                MessageBox.Show("Invalid Blood Pressure format.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                isValid = false;
            }

            if (!txtVision.Text.StartsWith("20/") || !int.TryParse(txtVision.Text.Split('/')[1], out int visionValue))
            {
                MessageBox.Show("Invalid Vision format.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                isValid = false;
            }

            return isValid;
        }

        // Check for Health Alerts
        private void CheckHealthAlerts()
        {
            // Blood Pressure Alert (Systolic/Diastolic Check)
            string[] bpValues = employeeHealthRecord.BloodPressure?.Split('/') ?? Array.Empty<string>();
            if (bpValues.Length == 2 && int.TryParse(bpValues[0], out int systolic) && int.TryParse(bpValues[1].Split(' ')[0], out int diastolic))
            {
                if (systolic > 140 || diastolic > 90)
                {
                    MessageBox.Show("High Blood Pressure Alert!", "Health Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else if (systolic < 90 || diastolic < 60)
                {
                    MessageBox.Show("Low Blood Pressure Alert!", "Health Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

            // Vision Alert (Check if vision is below 20/40)
            if (employeeHealthRecord.Vision != null && employeeHealthRecord.Vision.StartsWith("20/") && int.TryParse(employeeHealthRecord.Vision.Split('/')[1], out int visionValue))
            {
                if (visionValue > 40)
                {
                    MessageBox.Show("Vision Below Normal! Consider an Eye Checkup.", "Health Alert", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        // Mark Attendance (Add to logs)
        private void MarkAttendance_Click(object sender, RoutedEventArgs e)
        {
            string log = $"Attendance marked at {DateTime.Now:hh:mm tt}";
            attendanceLogs.Add(log);
            MessageBox.Show(log, "Attendance", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Clock In - Record clock-in time
        private void ClockIn_Click(object sender, RoutedEventArgs e)
        {
            if (clockInTime == null)
            {
                clockInTime = DateTime.Now;
                string log = $"Clocked In at {clockInTime.Value:hh:mm tt}";
                attendanceLogs.Add(log);
                
                // Show Clock-In message
                lblClockInStatus.Content = log;
                lblClockInStatus.Foreground = Brushes.LightGreen;

                // Clear Clock-Out status when clocking in again
                lblClockOutStatus.Content = "";
            }
            else
            {
                lblClockInStatus.Content = "You are already Clocked-In.";
                lblClockInStatus.Foreground = Brushes.Yellow;
            }
        }

        // Clock Out - Calculate worked time and log it
        private void ClockOut_Click(object sender, RoutedEventArgs e)
        {
            if (clockInTime != null)
            {
                DateTime clockOutTime = DateTime.Now;
                TimeSpan workDuration = clockOutTime - clockInTime.Value;

                string log = $"Clocked Out at {clockOutTime:hh:mm tt}. \n Worked: {workDuration.TotalHours:F2} hours.";
                attendanceLogs.Add(log);

                // Show Clock-Out message separately
                lblClockOutStatus.Content = log;
                lblClockOutStatus.Foreground = Brushes.LightBlue;

                clockInTime = null; // Reset for next session
            }
            else
            {
                lblClockOutStatus.Content = "You must Clock-In first!";
                lblClockOutStatus.Foreground = Brushes.Red;
            }
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