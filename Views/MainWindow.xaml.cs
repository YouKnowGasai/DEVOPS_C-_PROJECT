using System.Windows;

namespace Projet_val_c_.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new ViewModels.MainViewModel();
        }
    }
}
