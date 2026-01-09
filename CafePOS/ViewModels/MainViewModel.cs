using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CafePOS.Services;
using CafePOS.ViewModels;
using CafePOS.Models;

public class MainViewModel : INotifyPropertyChanged
{
    public Employee CurrentEmployee { get; }

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

    public ICommand ShowOrderCommand { get; }
    public ICommand ShowHistoryCommand { get; }

    public MainViewModel(Employee employee)
    {
        CurrentEmployee = employee;

        ShowOrderCommand = new RelayCommand(
            o => CurrentViewModel = new OrderViewModel()
        );

        ShowHistoryCommand = new RelayCommand(
            o =>
            {
                if (employee.Role == "Admin")
                    CurrentViewModel = new DashboardViewModel();
                else
                    System.Windows.MessageBox.Show("Access denied.");
            }
        );

        CurrentViewModel = new OrderViewModel();
    }

    protected void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
