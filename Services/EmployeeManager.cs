using System;
using System.Collections.Generic;
using System.Linq;
using TheCozyCupPOS.Models;

namespace TheCozyCupPOS.Services
{
    public class EmployeeManager
    {
        public event Action<Employee>? LoggedIn;
        public event Action? LoggedOut;

        private List<Employee> employees = new List<Employee>();
        private Employee? currentEmployee;
        public Employee? CurrentEmployee => currentEmployee;

        public bool Login(string pin)
        {
            var emp = employees.FirstOrDefault(e => e.Pin == pin);
            if (emp != null)
            {
                currentEmployee = emp;
                LoggedIn?.Invoke(emp);
                return true;
            }
            return false;
        }

        public void Logout()
        {
            currentEmployee = null;
            LoggedOut?.Invoke();
        }
    }
}