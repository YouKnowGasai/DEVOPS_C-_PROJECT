using System.ComponentModel;

namespace Projet_val_c_.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        public MainViewModel()
        {
            Message = "Hello, MVVM!";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
