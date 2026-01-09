using CafePOS.Data;
using CafePOS.Models;
using System.Windows;

namespace CafePOS.Views
{
    public partial class SignUpWindow : Window
    {
        public SignUpWindow()
        {
            InitializeComponent();
        }

        // Renamed to match XAML Click="SignUpButton_Click"
        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text.Trim();
            string pin = PinPasswordBox.Password.Trim();

            if (string.IsNullOrEmpty(name) || pin.Length < 4)
            {
                MessageBox.Show("Please enter a name and a 4-digit PIN.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                using var db = new CafeDbContext();
                
                // Assuming your Employee model hashes the pin or takes it as is
                var employee = new Employee(name, pin, "Cashier");
                
                db.Employees.Add(employee);
                db.SaveChanges();

                MessageBox.Show($"Account for {name} created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                
                // Return to login after successful signup
                BackToLogin_Click(sender, e);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Error saving to database: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Fixed Error: Added missing BackToLogin_Click
        private void BackToLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.Show();
            this.Close();
        }
    }
}