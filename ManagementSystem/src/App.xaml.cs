using System.Windows;

namespace Employee_Management_System
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Directly open LoginWindow
            LoginWindow LoginWindow = new LoginWindow();
            LoginWindow.Show();
        }
    }
}

