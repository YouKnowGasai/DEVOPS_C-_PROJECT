using System.Windows;


namespace Projet_val_c_
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Views.MainWindow mainWindow = new();
            mainWindow.Show();
        }
    }
}
