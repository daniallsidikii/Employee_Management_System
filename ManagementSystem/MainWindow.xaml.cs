using System;
using System.Windows.Media;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace OHSAdminPanel
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();

        public MainWindow()
        {
            InitializeComponent();
            Employees = new ObservableCollection<Employee>();
            EmployeeListView.ItemsSource = Employees;
            DataContext = this;
            if (EmployeeListView != null)
            {
                EmployeeListView.ItemsSource = Employees;
            }
        }
         private void Logout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTextBox.Text) || NameTextBox.Text == "Enter Name" ||
                string.IsNullOrWhiteSpace(RoleTextBox.Text) || RoleTextBox.Text == "Enter Role" ||
                string.IsNullOrWhiteSpace(EmailTextBox.Text) || EmailTextBox.Text == "Enter Email")
            {
                MessageBox.Show("Please enter valid employee details.", "Validation Error");
                return;
            }

            Employee newEmployee = new Employee
            {
                Id = Employees.Count + 1,
                Name = NameTextBox.Text,
                Role = RoleTextBox.Text,
                Email = EmailTextBox.Text
            };

            Employees.Add(newEmployee);

            NameTextBox.Text = "Enter Name";
            RoleTextBox.Text = "Enter Role";
            EmailTextBox.Text = "Enter Email";
            NameTextBox.Foreground = Brushes.Gray;
            RoleTextBox.Foreground = Brushes.Gray;
            EmailTextBox.Foreground = Brushes.Gray;
        }

       
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
           TextBox textBox = sender as TextBox;
           if (textBox != null && textBox.Foreground == Brushes.Gray)
           {
               textBox.Text = "";
               textBox.Foreground = Brushes.Black;
           }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                if (textBox.Name == "NameTextBox") textBox.Text = "Enter Name";
                else if (textBox.Name == "RoleTextBox") textBox.Text = "Enter Role";
                else if (textBox.Name == "EmailTextBox") textBox.Text = "Enter Email";
                else if (textBox.Name == "UsernameTextBox") textBox.Text = "Enter Username";

                textBox.Foreground = Brushes.Gray;
            }
        }
        
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeListView.SelectedItem is Employee selectedEmployee)
            {
                NameTextBox.Text = selectedEmployee.Name;
                RoleTextBox.Text = selectedEmployee.Role;
                EmailTextBox.Text = selectedEmployee.Email;

                Employees.Remove(selectedEmployee);
            }
            else
            {
                MessageBox.Show("Please select an employee to edit.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeeListView.SelectedItem is Employee selectedEmployee)
            {
                Employees.Remove(selectedEmployee);
            }
            else
            {
                MessageBox.Show("Please select an employee to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }

   
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Role { get; set; }
        public string? Email { get; set; }
    }
}


