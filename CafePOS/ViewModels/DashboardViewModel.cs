using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;           
using System.IO;
using System.Runtime.CompilerServices; 
using System.Threading.Tasks;
using CafePOS.Services;

namespace CafePOS.ViewModels
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        private readonly DashboardService _dashboardService;
        
        // This collection will hold the data for your UI (e.g., a chart or list)
        public ObservableCollection<KeyValuePair<int, decimal>> HourlySales { get; set; } = new();

        public DashboardViewModel()
        {
            _dashboardService = new DashboardService();
            LoadDashboardData();
        }

        private async void LoadDashboardData()
        {
            // Generates the filename for today's sales log
            string logFile = Path.Combine("SalesLogs", $"{DateTime.Now:yyyy-MM-dd}.json");
            
            var salesData = await _dashboardService.GetHourlySalesAsync(logFile);
            
            HourlySales.Clear();
            foreach (var entry in salesData)
            {
                HourlySales.Add(entry);
            }
        }

        // Standard Boilerplate for UI updates
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}