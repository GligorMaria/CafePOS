using System;
using System.Linq;
using System.Windows;
using CafePOS.Data;
using CafePOS.Models;
using Microsoft.EntityFrameworkCore;

namespace CafePOS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // Apelăm baza pentru a păstra comportamentul standard WPF
            base.OnStartup(e);

            try
            {
                // Inițializăm contextul bazei de date
                using (var db = new CafeDbContext())
                {
                    // Creează fișierul cafe.db dacă nu există. 
                    // Această linie poate eșua dacă pachetele SQLite nu sunt instalate corect.
                    db.Database.EnsureCreated();

                    // Verificăm dacă există angajați în tabelă
                    if (!db.Employees.Any())
                    {
                        // Adăugăm un cont de administrator implicit
                        db.Employees.Add(new Employee("Admin", "1234"));
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                // Dacă apare o eroare la baza de date, o afișăm într-un MessageBox
                // În loc să se închidă aplicația fără nicio explicație
                string errorMessage = $"Eroare critică la inițializarea bazei de date:\n\n{ex.Message}";
                
                if (ex.InnerException != null)
                {
                    errorMessage += $"\n\nDetalii: {ex.InnerException.Message}";
                }

                MessageBox.Show(errorMessage, "Eroare Startup", MessageBoxButton.OK, MessageBoxImage.Error);
                
                // Opriți aplicația dacă baza de date este esențială și a eșuat
                // Application.Current.Shutdown(); 
            }
        }
    }
}