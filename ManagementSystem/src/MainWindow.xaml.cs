using System;
using System.Data.SQLite;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Employee_Management_System
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Salary { get; set; } = string.Empty;
        public string Designation { get; set; } = string.Empty;
    }

    public partial class MainWindow : Window
    {
        public ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();

        private string dbPath = "Data Source=employees.db"; // SQLite Database file

        public MainWindow()
        {
            InitializeComponent();
            InitializeDatabase();
            LoadEmployees();  // Load employees when the app starts
            EmployeeListView.ItemsSource = Employees;
            DataContext = this;
            StartClock(); // Start the digital clock
        }

        private void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                string createTableQuery = @"CREATE TABLE IF NOT EXISTS Employees (
                                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                            EmployeeId TEXT NOT NULL,
                                            Name TEXT NOT NULL,
                                            Email TEXT NOT NULL,
                                            Salary TEXT NOT NULL,   
                                            Designation TEXT NOT NULL
                                        );";
                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        private void LoadEmployees()
        {
            Employees.Clear();
            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM Employees";
                using (var command = new SQLiteCommand(selectQuery, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employees.Add(new Employee
                        {
                            Id = reader.GetInt32(0),
                            EmployeeId = reader.GetString(1),
                            Name = reader.GetString(2),
                            Email = reader.GetString(3),
                            Salary = reader.GetString(4),
                            Designation = reader.GetString(5)
                        });
                    }
                }
            }
        }

        // For id text box
        private void EmployeeIdTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (EmployeeIdTextBox.Text == "Enter EmployeeId")
            {
                EmployeeIdTextBox.Text = "";
                EmployeeIdTextBox.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        private void EmployeeIdTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmployeeIdTextBox.Text))
            {
                EmployeeIdTextBox.Text = "Enter EmployeeId";
                EmployeeIdTextBox.Foreground = System.Windows.Media.Brushes.Gray;
            }
        }

        // for name text box
        private void NameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text == "Enter Name")
            {
                NameTextBox.Text = "";
                NameTextBox.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        private void NameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                NameTextBox.Text = "Enter Name";
                NameTextBox.Foreground = System.Windows.Media.Brushes.Gray;
            }
        }

        // for salary text box
        private void SalaryTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SalaryTextBox.Text == "Enter Salary")
            {
                SalaryTextBox.Text = "";
                SalaryTextBox.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        private void SalaryTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SalaryTextBox.Text))
            {
                SalaryTextBox.Text = "Enter Salary";
                SalaryTextBox.Foreground = System.Windows.Media.Brushes.Gray;
            }
        }

        // for email text box
        private void EmailTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (EmailTextBox.Text == "Enter Email")
            {
                EmailTextBox.Text = "";
                EmailTextBox.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        private void EmailTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                EmailTextBox.Text = "Enter Email";
                EmailTextBox.Foreground = System.Windows.Media.Brushes.Gray;
            }
        }


        private void DesignationTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (DesignationTextBox.Text == "Enter Designation")
            {
                DesignationTextBox.Text = "";
                DesignationTextBox.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        private void DesignationTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DesignationTextBox.Text))
            {
                DesignationTextBox.Text = "Enter Designation";
                DesignationTextBox.Foreground = System.Windows.Media.Brushes.Gray;
            }
        }


        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) || 
                NameTextBox.Text == "Enter Name" ||
                string.IsNullOrWhiteSpace(EmployeeIdTextBox.Text) || 
                EmployeeIdTextBox.Text == "Enter EmployeeId" ||
                string.IsNullOrWhiteSpace(EmailTextBox.Text) || 
                EmailTextBox.Text == "Enter Email" || 
                string.IsNullOrWhiteSpace(SalaryTextBox.Text) || 
                SalaryTextBox.Text == "Enter Salary" || 
                string.IsNullOrWhiteSpace(DesignationTextBox.Text) || 
                DesignationTextBox.Text == "Enter Designation")
            {
                MessageBox.Show("Please enter valid employee details.", "Validation Error");
                return;
            }

            using (var connection = new SQLiteConnection(dbPath))
            {
                connection.Open();
                string insertQuery = "INSERT INTO Employees (EmployeeId, Name, Email, Salary, Designation) VALUES (@EmployeeId, @Name, @Email, @Salary, @Designation)";
                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", EmployeeIdTextBox.Text);
                    command.Parameters.AddWithValue("@Name", NameTextBox.Text);
                    command.Parameters.AddWithValue("@Email", EmailTextBox.Text);
                    command.Parameters.AddWithValue("@Salary", SalaryTextBox.Text);
                    command.Parameters.AddWithValue("@Designation", DesignationTextBox.Text);
                    command.ExecuteNonQuery();
                }
            }

            LoadEmployees(); // Refresh the list after adding an employee

            EmployeeIdTextBox.Text = "Enter Employee ID";
            NameTextBox.Text = "Enter Name";
            EmailTextBox.Text = "Enter Email";
            SalaryTextBox.Text = "Enter Salary";
            DesignationTextBox.Text = "Enter Designation";

            EmployeeIdTextBox.Foreground = Brushes.Gray;
            NameTextBox.Foreground = Brushes.Gray;
            EmailTextBox.Foreground = Brushes.Gray;
            SalaryTextBox.Foreground = Brushes.Gray;
            DesignationTextBox.Foreground = Brushes.Gray;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeListView.SelectedItem is Employee selectedEmployee)
            {
                using (var connection = new SQLiteConnection(dbPath))
                {
                    connection.Open();
                    string deleteQuery = "DELETE FROM Employees WHERE Id = @Id";
                    using (var command = new SQLiteCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", selectedEmployee.Id);
                        command.ExecuteNonQuery();
                    }
                }

                LoadEmployees(); // Refresh list after deletion
            }
            else
            {
                MessageBox.Show("Please select an employee to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeListView.SelectedItem is Employee selectedEmployee)
            {
                EmployeeIdTextBox.Text = selectedEmployee.EmployeeId;
                NameTextBox.Text = selectedEmployee.Name;
                EmailTextBox.Text = selectedEmployee.Email;
                SalaryTextBox.Text = selectedEmployee.Salary;
                DesignationTextBox.Text = selectedEmployee.Designation;
                Employees.Remove(selectedEmployee);

                using (var connection = new SQLiteConnection(dbPath))
                {
                    connection.Open();
                    string deleteQuery = "DELETE FROM Employees WHERE Id = @Id";
                    using (var command = new SQLiteCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", selectedEmployee.Id);
                        command.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an employee to edit.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void StartClock()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (sender, e) => { txtClock.Text = DateTime.Now.ToString("hh:mm:ss tt"); };
            timer.Start();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}
