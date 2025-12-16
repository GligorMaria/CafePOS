using System.IO;
using System.Security.Principal;
using System.Windows;
using Microsoft.VisualBasic;
using TheCozyCupPOS.Services;

namespace TheCozyCupPOS
{
    public partial class DashboardWindow : Window
    {
        public DashboardWindow()
        {
            InitializeComponent();
            LoadData();
        }    

        private async void LoadData()
        {
            
                var dashboard = new DashboardService();
                string file = Path.Combine("SalesLogs", $"{DateTime.Now:yyyy-MM-dd}.json");
                var hourlySales = await dashboard.GetHourlySalesAsync(file);
                ChartContainer.ItemsSource = hourlySales;
        }
    }

}