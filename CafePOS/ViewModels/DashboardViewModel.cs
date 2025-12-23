using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Linq; // Added for .ToArray() and .Select()
using CafePOS.Services;
using LiveChartsCore; // Added for ISeries
using LiveChartsCore.SkiaSharpView; // Added for ColumnSeries and Axis
using SkiaSharp; // Added for colors

namespace CafePOS.ViewModels
{
    public class DashboardViewModel : INotifyPropertyChanged
    {
        private readonly DashboardService _dashboardService;

        // --- NEW PROPERTIES FOR CHARTING ---
        public ISeries[] SalesSeries { get; set; }
        public Axis[] XAxes { get; set; }

        public ObservableCollection<KeyValuePair<int, decimal>> HourlySales { get; set; } = new();

        public DashboardViewModel()
        {
            _dashboardService = new DashboardService();
            LoadDashboardData();
        }

        private async void LoadDashboardData()
        {
            string logFile = Path.Combine("SalesLogs", $"{DateTime.Now:yyyy-MM-dd}.json");
            var salesData = await _dashboardService.GetHourlySalesAsync(logFile);

            HourlySales.Clear();
            foreach (var entry in salesData)
            {
                HourlySales.Add(entry);
            }

            // --- REFRESH CHART DATA ---
            UpdateChart(salesData);
        }

        private void UpdateChart(Dictionary<int, decimal> data)
        {
            // Create the Bar Chart Series
            SalesSeries = new ISeries[]
            {
                new ColumnSeries<decimal>
                {
                    Values = data.Values.ToArray(),
                    Name = "Sales",
                    // Customizing color to match your Cafe Palette
                    Fill = new LiveChartsCore.SkiaSharpView.Painting.SolidColorPaint(SKColors.SaddleBrown),
                    Padding = 10,
                    Rx = 8, // Rounded corners on bars
                    Ry = 8
                }
            };

            // Setup the X-Axis labels (Hours)
            XAxes = new Axis[]
            {
                new Axis
                {
                    Labels = data.Keys.Select(h => $"{h}:00").ToArray(),
                    LabelsRotation = 0,
                    SeparatorsPaint = new LiveChartsCore.SkiaSharpView.Painting.SolidColorPaint(SKColors.LightGray)
                }
            };

            // Notify UI that chart properties have changed
            OnPropertyChanged(nameof(SalesSeries));
            OnPropertyChanged(nameof(XAxes));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}