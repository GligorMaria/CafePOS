using System.Windows.Controls; // Change to Controls for UserControl
using CafePOS.Services;
using System.IO;
using System;

namespace CafePOS.Views {
        public partial class DashboardView : UserControl 
    {
        public DashboardView()
        {
            InitializeComponent();
            LoadData();
        }

        private async void LoadData()
        {
            var dashboard = new DashboardService();
            string file = Path.Combine("SalesLogs", $"{DateTime.Now:yyyy-MM-dd}.json");
            var hourlySales = await dashboard.GetHourlySalesAsync(file);
            // Ensure 'ChartContainer' exists in your DashboardView.xaml!
            // ChartContainer.ItemsSource = hourlySales; 
        }
    }
}