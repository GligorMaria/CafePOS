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
            // Legăm ViewModel-ul de interfață și îi pasăm angajatul logat
            DataContext = new MainViewModel(loggedEmployee);
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            // Confirmare pentru utilizator
            MessageBoxResult result = MessageBox.Show("Are you sure you want to log out?",
                "Logout", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // 1. Creăm fereastra de Login (asigură-te că namespace-ul este corect)
                CafePOS.Views.LoginWindow loginWindow = new CafePOS.Views.LoginWindow();

                // 2. O afișăm
                loginWindow.Show();

                // 3. Închidem fereastra curentă
                this.Close();
            }
        }
    } // Acolada de închidere a clasei trebuie să fie AICI
}