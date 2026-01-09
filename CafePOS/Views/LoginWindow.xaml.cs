using CafePOS.Data;
using CafePOS.Services;
using CafePOS.Models;       // Added for Employee
using CafePOS.ViewModels;   // Added for MainViewModel
using System.Linq;
using System.Windows;

namespace CafePOS.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string enteredPin = PinPasswordBox.Password;

            if (string.IsNullOrWhiteSpace(enteredPin))
            {
                MessageBox.Show("Please enter your PIN.", "Input Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try 
            {
                using var db = new CafeDbContext();

                // 1. FIXED: Changed 'e.PinHash' to 'e.Pin' to match your Employee model
                var employee = db.Employees
                                 .AsEnumerable() 
                                 .FirstOrDefault(emp => PasswordHasher.Verify(enteredPin, emp.Pin));

                if (employee == null)
                {
                    MessageBox.Show("Incorrect PIN!", "Access Denied", MessageBoxButton.OK, MessageBoxImage.Error);
                    PinPasswordBox.Clear();
                    return;
                }

                // 2. FIXED: Connection to MainWindow via ViewModel
                // Since your MainWindow uses DataBinding, we pass the employee to the ViewModel
                MainWindow mainWindow = new MainWindow(employee);
                MainViewModel mainVM = new MainViewModel(employee);
                
                mainWindow.DataContext = mainVM; // This connects the UI to the Logic
                mainWindow.Show();
                this.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}");
            }
        }

        private void SignupButton_Click(object sender, RoutedEventArgs e)
        {
            // Fixed name to match your file: SignUpWindow
            new SignUpWindow().Show();
            this.Close();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
