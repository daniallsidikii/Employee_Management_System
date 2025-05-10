using System.Windows;
using System.Windows.Controls;
using System.Data.SQLite;
using System.Windows.Media;
using System.Windows.Threading;


namespace Employee_Management_System
{
    public partial class AdminPanel : Window
    {
       

        public AdminPanel()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            ChatClient clientWindow = new ChatClient("Admin");
            clientWindow.Show();
        }
        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            var emailWindow = new SendEmailWindow();
            emailWindow.ShowDialog();
        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
        
      
    }
}