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
            if (!System.IO.File.Exists("employees.db"))
            {
                MessageBox.Show("Database file not found. Please run the application from the Employee_Management_System directory.", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            InitializeDatabase();
            LoadEmployees();  // Load employees when the app starts
            EmployeeListView.ItemsSource = Employees;
            this.DataContext = this;

        }

        private void InitializeDatabase()
        {
            try
            {
                using (var connection = new SQLiteConnection(dbPath))
                {
                    connection.Open();

                    // Create the table only if it does not exist
                    string createTableQuery = @"
                        CREATE TABLE IF NOT EXISTS Employees (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            EmployeeId TEXT NOT NULL,
                            Name TEXT NOT NULL,
                            Email TEXT NOT NULL,
                            Salary TEXT NOT NULL,
                            Designation TEXT NOT NULL
                        );";
                    using (var createCommand = new SQLiteCommand(createTableQuery, connection))
                    {
                        createCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing database: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void LoadEmployees()
        {
            try
            {
                Employees.Clear();
                using (var connection = new SQLiteConnection(dbPath))
                {
                    connection.Open();
                    string selectQuery = "SELECT Id, EmployeeId, Name, Email, Salary, Designation FROM Employees";
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employees: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // For Employee ID text box
        private void EmployeeIdTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (EmployeeIdTextBox.Text == "Enter Employee ID")
            {
                EmployeeIdTextBox.Text = "";
                EmployeeIdTextBox.Foreground = Brushes.Black;
            }
        }

        private void EmployeeIdTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmployeeIdTextBox.Text))
            {
                EmployeeIdTextBox.Text = "Enter Employee ID";
                EmployeeIdTextBox.Foreground = Brushes.Gray;
            }
        }

        // For Name text box
        private void NameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text == "Enter Name")
            {
                NameTextBox.Text = "";
                NameTextBox.Foreground = Brushes.Black;
            }
        }

        private void NameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                NameTextBox.Text = "Enter Name";
                NameTextBox.Foreground = Brushes.Gray;
            }
        }

        // For Salary text box
        private void SalaryTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SalaryTextBox.Text == "Enter Salary")
            {
                SalaryTextBox.Text = "";
                SalaryTextBox.Foreground = Brushes.Black;
            }
        }

        private void SalaryTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SalaryTextBox.Text))
            {
                SalaryTextBox.Text = "Enter Salary";
                SalaryTextBox.Foreground = Brushes.Gray;
            }
        }

        // For Email text box
        private void EmailTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (EmailTextBox.Text == "Enter Email")
            {
                EmailTextBox.Text = "";
                EmailTextBox.Foreground = Brushes.Black;
            }
        }

        private void EmailTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                EmailTextBox.Text = "Enter Email";
                EmailTextBox.Foreground = Brushes.Gray;
            }
        }

        // For Designation text box
        private void DesignationTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (DesignationTextBox.Text == "Enter Designation")
            {
                DesignationTextBox.Text = "";
                DesignationTextBox.Foreground = Brushes.Black;
            }
        }

        private void DesignationTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DesignationTextBox.Text))
            {
                DesignationTextBox.Text = "Enter Designation";
                DesignationTextBox.Foreground = Brushes.Gray;
            }
        }

        // Add Employee Button Click
        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                NameTextBox.Text == "Enter Name" ||
                string.IsNullOrWhiteSpace(EmployeeIdTextBox.Text) ||
                EmployeeIdTextBox.Text == "Enter Employee ID" ||
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

            try
            {
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

                // Reset text boxes
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding employee: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Delete Employee Button Click
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeListView.SelectedItem is Employee selectedEmployee)
            {
                try
                {
                    using (var connection = new SQLiteConnection(dbPath))
                    {
                        connection.Open();

                        // Delete the selected employee
                        string deleteQuery = "DELETE FROM Employees WHERE Id = @Id";
                        using (var command = new SQLiteCommand(deleteQuery, connection))
                        {
                            command.Parameters.AddWithValue("@Id", selectedEmployee.Id);
                            command.ExecuteNonQuery();
                        }

                        // Reset ID sequence ONLY if table is empty
                        string checkQuery = "SELECT COUNT(*) FROM Employees";
                        using (var checkCommand = new SQLiteCommand(checkQuery, connection))
                        {
                            long count = (long)checkCommand.ExecuteScalar();
                            if (count == 0) // Only reset if the table is empty
                            {
                                string resetQuery = "DELETE FROM SQLITE_SEQUENCE WHERE name='Employees'";
                                using (var resetCommand = new SQLiteCommand(resetQuery, connection))
                                {
                                    resetCommand.ExecuteNonQuery();
                                }
                            }
                        }
                    }

                    LoadEmployees(); // Refresh the list after deletion
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting employee: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an employee to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        // Edit Employee Button Click
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeListView.SelectedItem is Employee selectedEmployee)
            {
                try
                {
                    // Populate text boxes with selected employee's data
                    EmployeeIdTextBox.Text = selectedEmployee.EmployeeId;
                    NameTextBox.Text = selectedEmployee.Name;
                    EmailTextBox.Text = selectedEmployee.Email;
                    SalaryTextBox.Text = selectedEmployee.Salary;
                    DesignationTextBox.Text = selectedEmployee.Designation;

                    // Remove the selected employee from the list
                    Employees.Remove(selectedEmployee);

                    // Delete the employee from the database
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
                catch (Exception ex)
                {
                    MessageBox.Show($"Error editing employee: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select an employee to edit.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Logout Button Click
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
