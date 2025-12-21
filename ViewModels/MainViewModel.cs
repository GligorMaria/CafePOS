using System.Diagnostics.Contracts;
using CafePOS.Models;
using CafePOS.Services;

namespace CafePOS.ViewModels
{
    public class MainViewModel
    {
        public OrderManager orderManager { get; set; } = new OrderManager();
        public EmployeeManager employeeManager { get; set; } = new EmployeeManager();
        public SalesLogService LogService { get; set; }
    }
}