using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CounterApp.ViewModels
{
    public class CounterViewModel : INotifyPropertyChanged
    {
        private int _count = 0;
        private string _message = "Click button to start count";

        public CounterViewModel()
        {
            IncrementCommand = new Command(Increment);
            ResetCommand = new Command(Reset, CanReset);
        }

        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
                OnPropertyChanged();

                // Notify that CanExecute may have changed
                ((Command)ResetCommand).ChangeCanExecute();
            }
        }

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
            }
        }

        public ICommand IncrementCommand { get; }
        public ICommand ResetCommand { get; }

        public void Increment()
        {
            Count++;
        }

        public void Reset()
        {
            Count = 0;
        }

        public bool CanReset()
        {
            return Count > 0;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    } 
}

