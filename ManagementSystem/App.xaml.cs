using System.Windows;

namespace OHSAdminPanel
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Directly open MainWindow
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }
    }
}

