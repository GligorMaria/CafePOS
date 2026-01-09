namespace CafePOS.Models
{
    public class Employee
    {
        // Primary Key
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        // PIN hashuit (NU pinul real)
        public string Pin { get; set; } = string.Empty;

        // Rolul angajatului
        public string Role { get; set; } = "Cashier";

        // Constructor obligatoriu EF
        public Employee() { }

        // Constructor pentru aplicație
        public Employee(string name, string pin, string role = "Cashier")
        {
            Name = name;
            Role = role;
            Pin = BCrypt.Net.BCrypt.HashPassword(pin);
        }
    }
}
