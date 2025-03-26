using System;
using System.IO;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using Newtonsoft.Json;

namespace Employee_Management_System
{
    public partial class EmployeeDashboard : Window
    {
        // Fields and Properties
        private DateTime? clockInTime; // Store clock-in time
        private bool hasClockedOut = false; // Prevent multiple Clock-Outs
        private bool hasMarkedAttendance = false; // Prevent multiple Mark Attendances
        private List<string> attendanceLogs = new List<string>(); // Store session-specific logs
        private DispatcherTimer breakReminderTimer = new DispatcherTimer(); // Break reminder timer
        private int skippedBreaksCount = 0; // Track skipped breaks
        private readonly string attendanceFile = "AttendanceLogs.txt"; // File path for attendance logs
        private readonly string todoFile = "ToDoList.json"; // File for storing tasks
        private List<string> toDoTasks = new List<string>(); // Task list

        // Constructor
        public EmployeeDashboard()
        {
            InitializeComponent();
            ResetSessionLogs(); // Clear logs for a new session
            InitializeBreakReminder(); // Initialize break reminder timer
            StartClock(); // Start the digital clock
            LoadToDoList(); // Load tasks from file
        }

        // Clock and Session Management
        private void StartClock()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (sender, e) => { txtClock.Text = DateTime.Now.ToString("hh:mm:ss tt"); };
            timer.Start();
        }

        private void ResetSessionLogs()
        {
            attendanceLogs.Clear(); // Clear session-specific logs
            hasClockedOut = false;
            hasMarkedAttendance = false;
        }

        private void SaveAttendanceLogs()
        {
            File.AppendAllLines(attendanceFile, attendanceLogs); // Append session logs to the file
        }

        // Attendance Management
        private void ClockIn_Click(object sender, RoutedEventArgs e)
        {
            if (clockInTime == null)
            {
                clockInTime = DateTime.Now;
                string log = $"Clocked In at {clockInTime.Value:hh:mm tt} on {DateTime.Now:MM/dd/yyyy}";
                attendanceLogs.Add(log);

                lblClockInStatus.Content = log;
                lblClockInStatus.Foreground = Brushes.LightGreen;
                lblClockOutStatus.Content = "";

                SaveAttendanceLogs();
            }
            else
            {
                lblClockInStatus.Content = "You have already Clocked-In today.";
                lblClockInStatus.Foreground = Brushes.Yellow;
            }
        }

        private void ClockOut_Click(object sender, RoutedEventArgs e)
        {
            if (clockInTime != null && !hasClockedOut)
            {
                DateTime clockOutTime = DateTime.Now;
                TimeSpan workDuration = clockOutTime - clockInTime.Value;

                string log = $"Clocked Out at {clockOutTime:hh:mm tt}. Worked: {workDuration.TotalHours:F2} hours.";
                attendanceLogs.Add(log);

                lblClockOutStatus.Content = log;
                lblClockOutStatus.Foreground = Brushes.LightBlue;
                clockInTime = null;
                hasClockedOut = true; // Prevent multiple Clock-Outs

                SaveAttendanceLogs();
            }
            else
            {
                lblClockOutStatus.Content = "You must Clock-In first or have already Clocked-Out.";
                lblClockOutStatus.Foreground = Brushes.Red;
            }
        }

        private void MarkAttendance_Click(object sender, RoutedEventArgs e)
        {
            if (!hasMarkedAttendance)
            {
                string log = $"Attendance marked at {DateTime.Now:hh:mm tt} on {DateTime.Now:MM/dd/yyyy}";
                attendanceLogs.Add(log);

                MessageBox.Show("Attendance marked successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                hasMarkedAttendance = true; // Prevent multiple Mark Attendances

                SaveAttendanceLogs();
            }
            else
            {
                MessageBox.Show("Attendance has already been marked today.", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ViewAttendanceLogs_Click(object sender, RoutedEventArgs e)
        {
            if (attendanceLogs.Count > 0)
            {
                string logs = string.Join("\n", attendanceLogs);
                MessageBox.Show(logs, "Attendance Logs (Current Session)", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No attendance logs available for this session.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Health Records
        private void OpenHealthRecords_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HealthRecordsWindow healthWindow = new HealthRecordsWindow();
                healthWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Health Records: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Break Reminder
        private void InitializeBreakReminder()
        {
            breakReminderTimer.Interval = TimeSpan.FromMinutes(3); // Set interval to 3 minutes
            breakReminderTimer.Tick += BreakReminderTimer_Tick;
            breakReminderTimer.Start();
        }

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

        // To-Do List Management
        private void LoadToDoList()
        {
            if (File.Exists(todoFile))
            {
                string json = File.ReadAllText(todoFile);
                toDoTasks = JsonConvert.DeserializeObject<List<string>>(json) ?? new List<string>();
                RefreshToDoList();
            }
        }

        private void SaveToDoList()
        {
            File.WriteAllText(todoFile, JsonConvert.SerializeObject(toDoTasks, Formatting.Indented));
        }

        private void RefreshToDoList()
        {
            lstToDo.Items.Clear();
            foreach (var task in toDoTasks)
            {
                lstToDo.Items.Add(task);
            }
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNewTask.Text))
            {
                toDoTasks.Add(txtNewTask.Text.Trim());
                txtNewTask.Clear();
                SaveToDoList();
                RefreshToDoList();
            }
            else
            {
                MessageBox.Show("Please enter a task.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void RemoveTask_Click(object sender, RoutedEventArgs e)
        {
            if (lstToDo.SelectedItem != null)
            {
                string? selectedTask = lstToDo.SelectedItem.ToString();
                if (!string.IsNullOrEmpty(selectedTask))
                {
                    toDoTasks.Remove(selectedTask);
                    SaveToDoList();
                    RefreshToDoList();
                }
            }
            else
            {
                MessageBox.Show("Please select a task to remove.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ClearTasks_Click(object sender, RoutedEventArgs e)
        {
            if (toDoTasks.Count > 0)
            {
                toDoTasks.Clear();
                SaveToDoList();
                RefreshToDoList();
                MessageBox.Show("To-Do List Cleared!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No tasks to clear.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // OHS Survey
        private void OpenOHSSurvey_Click(object sender, RoutedEventArgs e)
        {
            OhsSurveyWindow surveyWindow = new OhsSurveyWindow();
            surveyWindow.ShowDialog();
        }

        // Logout
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Save logs before logout
                SaveAttendanceLogs();

                // Open the login window
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();

                // Close the current dashboard window
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Logout Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}