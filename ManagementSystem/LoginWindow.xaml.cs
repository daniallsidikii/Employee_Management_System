using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace OHSAdminPanel
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
            string password = PasswordBox.Password.Trim();

            // Input validation check
            if (string.IsNullOrWhiteSpace(username) || username == "Enter Username" || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Perform login logic
            if (username == "admin" && password == "password")
            {
                MainWindow adminPanel = new MainWindow(); // Admin Dashboard
                adminPanel.Show();
                this.Close();
            }
            else if (username == "employee" && password == "emp123")
            {
                EmployeeDashboard employeeDashboard = new EmployeeDashboard(); // Employee Dashboard
                employeeDashboard.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        // Handle TextBox (Username) Placeholder
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Foreground == Brushes.Gray)
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.White;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox.Name == "UsernameTextBox")
                {
                    textBox.Text = "Enter Username";
                    textBox.Foreground = Brushes.Gray;
                }
            }
        }
    }
}