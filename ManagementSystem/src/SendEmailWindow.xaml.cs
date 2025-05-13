using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Configuration;

namespace Employee_Management_System
{
    public partial class SendEmailWindow : Window
    {
        public SendEmailWindow()
        {
            InitializeComponent();
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            string toEmail = ToTextBox.Text.Trim();
            
            // Only add @gmail.com if:
            // 1. The text is not empty
            // 2. There's no @ symbol present
            // 3. There's some text before where @ would be
            if (!string.IsNullOrWhiteSpace(toEmail) && 
                !toEmail.Contains("@") && 
                toEmail.Length > 0)
            {
                toEmail += "@gmail.com";
            }

            if (string.IsNullOrWhiteSpace(toEmail))
            {
                MessageBox.Show("Please enter a recipient email address.", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            string subject = SubjectTextBox.Text;
            string body = BodyTextBox.Text;

            try
            {
                string fromEmail = ConfigurationManager.AppSettings["EmailAddress"];
                string appPassword = ConfigurationManager.AppSettings["EmailPassword"];
                
                if (string.IsNullOrEmpty(fromEmail) || string.IsNullOrEmpty(appPassword))
                {
                    MessageBox.Show("Please set your email and app password in the app settings.", 
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                MailMessage mail = new MailMessage(fromEmail, toEmail, subject, body);

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential(fromEmail, appPassword)
                };

                client.Send(mail);
                MessageBox.Show($"Email sent successfully to {toEmail}!", "Success", 
                    MessageBoxButton.OK, MessageBoxImage.Information);
                
                // Clear fields
                ToTextBox.Text = "";
                SubjectTextBox.Text = "";
                BodyTextBox.Text = "";
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Error sending email:\n{ex.Message}", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}