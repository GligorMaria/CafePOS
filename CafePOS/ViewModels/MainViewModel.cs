using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CafePOS.Services;

namespace CafePOS.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private object? _currentViewModel;
        public object? CurrentViewModel
        {
            get => _currentViewModel;
            set 
            { 
                _currentViewModel = value; 
                OnPropertyChanged(); 
            }
        }

        // Commands for the sidebar buttons
        public ICommand ShowOrderCommand { get; }
        public ICommand ShowHistoryCommand { get; }

        public MainViewModel()
        {
            // Initialize the Commands
            ShowOrderCommand = new RelayCommand(o => CurrentViewModel = new OrderViewModel());
            ShowHistoryCommand = new RelayCommand(o => CurrentViewModel = new DashboardViewModel());

            // Set the default screen to Order when the app starts
            CurrentViewModel = new OrderViewModel();
        }

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    // A simple RelayCommand class included here to make your buttons work
    public class RelayCommand : ICommand
    {
        private readonly Action<object?> _execute;
        private readonly Predicate<object?>? _canExecute;

        public RelayCommand(Action<object?> execute, Predicate<object?>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter) => _canExecute == null || _canExecute(parameter);
        public void Execute(object? parameter) => _execute(parameter);
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}