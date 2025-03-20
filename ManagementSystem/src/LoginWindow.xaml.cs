using System.Windows;
using System.Windows.Controls;
using System.Data.SQLite;
using System.Windows.Media;

namespace Employee_Management_System
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();

            // Admin hardcoded login
            if (username == "admin" && password == "password")
            {
                MainWindow mainWindow = new MainWindow(); // Admin Dashboard
                mainWindow.Show();
                this.Close();
                return;
            }

            // Check employee credentials from database
            if (IsValidEmployee(username, password))
            {
                EmployeeDashboard employeeDashboard = new EmployeeDashboard(); // Employee Dashboard
                employeeDashboard.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Email ID or Employee ID", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private bool IsValidEmployee(string email, string employeeId)
        {
            string dbPath = "Data Source=employees.db"; // Database path

            try
            {
                using (var connection = new SQLiteConnection(dbPath))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM Employees WHERE Email = @Email AND EmployeeId = @EmployeeId";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@EmployeeId", employeeId);

                        int count = Convert.ToInt32(command.ExecuteScalar());
                        return count > 0; // If count > 0, credentials exist in database
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        
        // Handle TextBox (Username) Placeholder
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = "";
                // textBox.Foreground = Brushes.White;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox.Name == "UsernameTextBox")
                {
                    textBox.Text = "Enter Email ID";
                    // textBox.Foreground = Brushes.Gray;
                }
            }
        }

        private void PasswordTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                textBox.Text = "";
                // textBox.Foreground = Brushes.White;
            }
        }

        private void PasswordTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox.Name == "PasswordTextBox")
                {
                    textBox.Text = "Enter ID";
                    // textBox.Foreground = Brushes.Gray;
                }
            }
        }
    }
}