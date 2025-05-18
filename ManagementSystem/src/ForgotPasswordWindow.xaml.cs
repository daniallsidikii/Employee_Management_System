using System;
using System.Data.SQLite;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Employee_Management_System
{
    public partial class ForgotPasswordWindow : Window
    {
        private string dbPath = "Data Source=employees.db;Version=3;";
        private string currentEmployeeEmail = "";

        public ForgotPasswordWindow()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text.Trim();

            lblMessage.Visibility = Visibility.Collapsed;
            resultPanel.Visibility = Visibility.Collapsed;

            if (string.IsNullOrEmpty(email))
            {
                ShowMessage("Please enter your email address.");
                return;
            }

            if (!IsValidEmail(email))
            {
                ShowMessage("Please enter a valid email address.");
                return;
            }

            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(dbPath))
                {
                    conn.Open();
                    string query = "SELECT EmployeeId, Name, Email FROM Employees WHERE Email = @Email COLLATE NOCASE LIMIT 1";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtEmployeeId.Text = reader["EmployeeId"].ToString();
                                txtEmployeeName.Text = reader["Name"].ToString();
                                txtEmployeeEmail.Text = reader["Email"].ToString();
                                currentEmployeeEmail = reader["Email"].ToString();

                                resultPanel.Visibility = Visibility.Visible;
                                lblMessage.Visibility = Visibility.Collapsed;
                            }
                            else
                            {
                                ShowMessage("Email not found in our system.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Error accessing database. Try again later.");
                // log ex.Message if needed
            }
        }

        private void btnResetPassword_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(currentEmployeeEmail))
            {
                ShowMessage("No account selected to reset password.");
                return;
            }

            try
            {
                string tempPassword = GenerateTemporaryPassword(8);
                string hashedPassword = HashPassword(tempPassword);

                using (SQLiteConnection conn = new SQLiteConnection(dbPath))
                {
                    conn.Open();
                    string query = "UPDATE Employees SET Password = @Password WHERE Email = @Email";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Password", hashedPassword);
                        cmd.Parameters.AddWithValue("@Email", currentEmployeeEmail);

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show($"Temporary password: {tempPassword}\nPlease change it after login.", "Password Reset", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            ShowMessage("Failed to reset password.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Error resetting password. Try again.");
                // log ex.Message if needed
            }
        }

        private void ShowMessage(string message)
        {
            lblMessage.Text = message;
            lblMessage.Visibility = Visibility.Visible;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private string GenerateTemporaryPassword(int length)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                res.Append(validChars[rnd.Next(validChars.Length)]);
            }
            return res.ToString();
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                    builder.Append(b.ToString("x2"));
                return builder.ToString();
            }
        }
        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnSubmit_Click(sender, e);
            }
        }
        private void btnBackToLogin_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
