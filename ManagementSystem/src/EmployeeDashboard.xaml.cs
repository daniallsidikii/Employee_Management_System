using System;
using System.IO;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using Newtonsoft.Json;

namespace Employee_Management_System
{
    /// <summary>
    /// Interaction logic for EmployeeDashboard.xaml
    /// </summary>
    public partial class EmployeeDashboard : Window
    {
        // -------------------- Fields and Properties --------------------
        private DateTime? clockInTime; // Stores the clock-in time
        private bool hasClockedOut = false; // Ensures a user cannot clock out multiple times
        private bool hasMarkedAttendance = false; // Ensures attendance is marked only once per day
       private Dictionary<string, AttendanceData> attendanceLogs = new();
        private DispatcherTimer breakReminderTimer = new DispatcherTimer(); // Timer for break reminders
        private int skippedBreaksCount = 0; // Tracks the number of skipped breaks
        private List<TaskItem> toDoTasks = new List<TaskItem>(); // List of to-do tasks

        public string userName;

        // -------------------- Constructor --------------------
        public EmployeeDashboard(string username)
        {
            InitializeComponent();
           
            userName = username;
            lblUserName.Text = $"Logged in as: {userName}";
            LoadAttendanceLogs(); // Load existing attendance logs
            InitializeBreakReminder(); // Set up the break reminder timer
            StartClock(); // Start the digital clock display
            LoadToDoList(); // Load tasks from the to-do list file
        }

        private void message_Click(object sender, RoutedEventArgs e) // This is for message
        {
            ChatClient clientWindow = new ChatClient(userName);
            clientWindow.Show();
        }

        // -------------------- Navigation --------------------

        /// <summary>
        /// Opens the Health Records window.
        /// </summary>
        private void OpenHealthRecords_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HealthRecordsWindow healthWindow = new HealthRecordsWindow(userName);
                healthWindow.ShowDialog(); // Open as a modal dialog
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening Health Records: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Opens the OHS Survey window.
        /// </summary>
        private void OpenOHSSurvey_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OhsSurveyWindow surveyWindow = new OhsSurveyWindow(userName);
                surveyWindow.ShowDialog(); // Open as a modal dialog
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening OHS Survey: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // -------------------- Clock and Session Management --------------------

        /// <summary>
        /// Starts the digital clock on the dashboard.
        /// </summary>
        private void StartClock()
        {
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += (sender, e) => { txtClock.Text = DateTime.Now.ToString("hh:mm:ss tt"); };
            timer.Start();
        }

        /// <summary>
        /// Loads attendance logs from a JSON file.
        /// </summary>
         private void LoadAttendanceLogs()
{
    string userAttendanceFile = $"{userName}_AttendanceLogs.json";
    if (File.Exists(userAttendanceFile))
    {
        string json = File.ReadAllText(userAttendanceFile);
        attendanceLogs = JsonConvert.DeserializeObject<Dictionary<string, AttendanceData>>(json)
                         ?? new Dictionary<string, AttendanceData>();

        string currentDate = DateTime.Now.ToString("MM/dd/yyyy");

        if (attendanceLogs.ContainsKey(currentDate))
        {
            var todayLog = attendanceLogs[currentDate];
            hasMarkedAttendance = todayLog.HasMarkedAttendance;
            hasClockedOut = todayLog.HasClockedOut;
            clockInTime = todayLog.ClockInTime;
        }
    }
    else
    {
        attendanceLogs = new Dictionary<string, AttendanceData>();
    }
}


        /// <summary>
        /// Saves attendance logs to a JSON file.
        /// </summary>
        private void SaveAttendanceLogs()
{
    try
    {
        string userAttendanceFile = $"{userName}_AttendanceLogs.json";

        // Load the existing logs before saving (preserves old data)
        Dictionary<string, AttendanceData> currentLogs = new Dictionary<string, AttendanceData>(attendanceLogs);

        // Save the updated attendance logs
        File.WriteAllText(userAttendanceFile, JsonConvert.SerializeObject(currentLogs, Formatting.Indented));
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Failed to save attendance logs: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }
}


        // -------------------- Attendance Management --------------------
        //public class
        public class AttendanceData
{
    public List<string> Logs { get; set; } = new List<string>();
    public bool HasMarkedAttendance { get; set; }
    public bool HasClockedOut { get; set; }
    public DateTime? ClockInTime { get; set; } // Persist clock-in time
    public TimeSpan? WorkDuration { get; set; } // Optional: Track worked hours
}

    private AttendanceData GetOrCreateTodayLog()
{
    string currentDate = DateTime.Now.ToString("MM/dd/yyyy");
    if (!attendanceLogs.ContainsKey(currentDate))
        attendanceLogs[currentDate] = new AttendanceData();
    return attendanceLogs[currentDate];
}

        /// <summary>
        /// Handles the Clock-In button click event.
        /// </summary>
       private void ClockIn_Click(object sender, RoutedEventArgs e)
{
    try
    {
        string currentDate = DateTime.Now.ToString("MM/dd/yyyy");
        var todayLog = GetOrCreateTodayLog();

        if (clockInTime == null && todayLog.ClockInTime == null)
        {
            clockInTime = DateTime.Now;
            todayLog.ClockInTime = clockInTime;

            string log = $"Clocked In at {clockInTime.Value:hh:mm tt} on {currentDate}";
            todayLog.Logs.Add(log);

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
    catch (Exception ex)
    {
        MessageBox.Show($"An error occurred while clocking in: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }
}


        /// <summary>
        /// Handles the Clock-Out button click event.
        /// </summary>
        private void ClockOut_Click(object sender, RoutedEventArgs e)
{
    try
    {
        string currentDate = DateTime.Now.ToString("MM/dd/yyyy");
        var todayLog = GetOrCreateTodayLog();

        if (clockInTime != null && !hasClockedOut)
        {
            DateTime clockOutTime = DateTime.Now;
            TimeSpan workDuration = clockOutTime - clockInTime.Value;

            string log = $"Clocked Out at {clockOutTime:hh:mm tt}. Worked: {workDuration.TotalHours:F2} hours.";
            todayLog.Logs.Add(log);

            lblClockOutStatus.Content = log;
            lblClockOutStatus.Foreground = Brushes.LightBlue;

            // Reset clock-in and mark as clocked out
            clockInTime = null;
            todayLog.ClockInTime = null;
            hasClockedOut = true;
            todayLog.HasClockedOut = true;
            todayLog.WorkDuration = workDuration;

            SaveAttendanceLogs();
        }
        else
        {
            lblClockOutStatus.Content = "You must Clock-In first or have already Clocked-Out.";
            lblClockOutStatus.Foreground = Brushes.Red;
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"An error occurred while clocking out: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }
}



        /// <summary>
        /// Handles the Mark Attendance button click event.
        /// </summary>
        private void MarkAttendance_Click(object sender, RoutedEventArgs e)
{
    try
    {
        string currentDate = DateTime.Now.ToString("MM/dd/yyyy");
        var todayLog = GetOrCreateTodayLog();

        if (!todayLog.HasMarkedAttendance)
        {
            breakReminderTimer.Stop();

            string log = $"Attendance marked at {DateTime.Now:hh:mm tt} on {currentDate}";
            todayLog.Logs.Add(log);
            todayLog.HasMarkedAttendance = true;
            hasMarkedAttendance = true;

            SaveAttendanceLogs();

            MessageBox.Show("Attendance marked successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        else
        {
            MessageBox.Show("Attendance has already been marked today.", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show($"An error occurred while marking attendance: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }
    finally
    {
        breakReminderTimer.Start();
    }
}

        /// <summary>
        /// Displays attendance logs for the current date.
        /// </summary>
        private void ViewAttendanceLogs_Click(object sender, RoutedEventArgs e)
        {
            string currentDate = DateTime.Now.ToString("MM/dd/yyyy");

            if (attendanceLogs.ContainsKey(currentDate))
            {
                string logs = string.Join("\n", attendanceLogs[currentDate].Logs);
                MessageBox.Show(logs, $"Attendance Logs for {currentDate}", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No attendance logs available for this date.", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        
        // -------------------- Break Reminder --------------------

        /// <summary>
        /// Initializes the break reminder timer.
        /// </summary>
        private void InitializeBreakReminder()
        {
            breakReminderTimer.Interval = TimeSpan.FromMinutes(3);
            breakReminderTimer.Tick += BreakReminderTimer_Tick;
            breakReminderTimer.Start();
        }

        /// <summary>
        /// Handles the break reminder timer tick event.
        /// </summary>
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
                skippedBreaksCount = 0;
            }
        }

        // -------------------- To-Do List Management --------------------

        /// <summary>
        /// Loads the to-do list from a JSON file.
        /// </summary>
        private void LoadToDoList()
        {
            string  userToDoFile = $"{userName}_ToDoList.json";
            if (File.Exists(userToDoFile))
            {
                string json = File.ReadAllText(userToDoFile);
                toDoTasks = JsonConvert.DeserializeObject<List<TaskItem>>(json) ?? new List<TaskItem>();
                RefreshToDoList();
            }
            else
            {
                toDoTasks = new List<TaskItem>();
            }
        }

        /// <summary>
        /// Saves the to-do list to a JSON file.
        /// </summary>
        private void SaveToDoList()
        {
            string userToDoFile = $"{userName}_ToDoList.json";
            File.WriteAllText(userToDoFile, JsonConvert.SerializeObject(toDoTasks, Formatting.Indented));
        }

        /// <summary>
        /// Refreshes the to-do list display.
        /// </summary>
        private void RefreshToDoList()
        {
            lstToDo.Items.Clear();
            foreach (var task in toDoTasks)
            {
                string taskInfo = task.TaskDescription;

                if (task.DueDate.HasValue)
                    taskInfo += $" (Due: {task.DueDate.Value:MM/dd/yyyy})";

                taskInfo += $" - Priority: {task.Priority}";

                lstToDo.Items.Add(taskInfo);
            }
        }

        /// <summary>
        /// Adds a new task to the to-do list.
        /// </summary>
        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNewTask.Text))
            {
                DateTime? dueDate = txtDueDate.SelectedDate;
                string priority = txtPriority.Text.Trim();

                TaskItem newTask = new TaskItem(txtNewTask.Text.Trim(), dueDate, priority);
                toDoTasks.Add(newTask);

                txtNewTask.Clear();
                txtDueDate.SelectedDate = null;
                txtPriority.SelectedIndex = -1;

                SaveToDoList();
                RefreshToDoList();
            }
            else
            {
                MessageBox.Show("Please enter a task.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Removes the selected task from the to-do list.
        /// </summary>
        private void RemoveTask_Click(object sender, RoutedEventArgs e)
        {
            if (lstToDo.SelectedItem != null)
            {
                string? selectedTask = lstToDo.SelectedItem.ToString();
                if (!string.IsNullOrEmpty(selectedTask))
                {
                    TaskItem? taskToRemove = toDoTasks.Find(task => task.TaskDescription == selectedTask);
                    if (taskToRemove != null)
                    {
                        toDoTasks.Remove(taskToRemove);
                        SaveToDoList();
                        RefreshToDoList();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid task selected.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a task to remove.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Clears all tasks from the to-do list.
        /// </summary>
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

        // -------------------- Logout --------------------

        /// <summary>
        /// Handles the Logout button click event.
        /// </summary>
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveAttendanceLogs();

                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Logout Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    /// <summary>
    /// Represents a task item in the to-do list.
    /// </summary>
    public class TaskItem
    {
        public string TaskDescription { get; set; }
        public DateTime? DueDate { get; set; }
        public string Priority { get; set; }

        public TaskItem(string taskDescription, DateTime? dueDate, string priority)
        {
            TaskDescription = taskDescription;
            DueDate = dueDate;
            Priority = priority;
        }
    }
}