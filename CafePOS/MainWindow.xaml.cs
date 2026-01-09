using CafePOS.Models;
using CafePOS.ViewModels;
using System.Windows;

namespace CafePOS
{
    public partial class MainWindow : Window
    {
        public MainWindow(Employee loggedEmployee)
        {
            InitializeComponent();
            DataContext = new MainViewModel(loggedEmployee);
        }
    }
}
