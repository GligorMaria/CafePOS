using System.Windows;
using CafePOS.Models;
using CafePOS.Models.Enums;
using CafePOS.Data;
using CafePOS.Services;
using System.ComponentModel.Design;
using System.Net.Mail;

namespace CafePOS
{
    public partial class MainWindow : Window
    {
        private Menu cafeMenu = new Menu();
        private OrderManager orderManager = new OrderManager();
        private EmployeeManager employeeManager = new EmployeeManager();
        private SalesLogService logService = new SalesLogService();

        public MainWindow()
        {
            InitializeComponent();
            LoadMenu();
            AttachEvents();
        }
    }
}