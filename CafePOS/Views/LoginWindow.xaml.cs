using System;
using System.Linq;
using System.Windows;
using CafePOS.Data; 
using CafePOS.Models;

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
                MessageBox.Show("Vă rugăm să introduceți PIN-ul.", "Atenție");
                return;
            }

            try
            {
                using (var db = new CafeDbContext())
                {
                    db.Database.EnsureCreated();
                    var employee = db.Employees.FirstOrDefault(u => u.Pin == enteredPin);

                    if (employee != null)
                    {
                        MainWindow main = new MainWindow();
                        main.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("PIN incorect!", "Eroare");
                        PinPasswordBox.Clear();
                        PinPasswordBox.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Eroare bază de date: {ex.Message}");
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is System.Windows.Controls.Button button)
            {
                PinPasswordBox.Password += button.Content.ToString();
            }
        }
    }
}