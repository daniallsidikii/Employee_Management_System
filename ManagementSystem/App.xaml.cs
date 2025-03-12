using System.Windows;

namespace OHSAdminPanel
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Directly open MainWindow
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}

