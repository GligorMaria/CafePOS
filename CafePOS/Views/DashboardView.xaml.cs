using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using LiveChartsCore.SkiaSharpView.WPF;
using CafePOS.Models;

namespace CafePOS.Views
{
    public partial class DashboardView : UserControl
    {
        public DashboardView()
        {
            InitializeComponent();
        }

        public void InitializeForUser(Employee user)
        {
            // If the user is NOT an Admin, hide the chart and title
            if (user.Role != "Admin")
            {
                AnalyticsTitle.Visibility = Visibility.Collapsed;
                ChartBorder.Visibility = Visibility.Collapsed;
            }
            else
            {
                // Only setup charts if the user is an Admin (saves resources)
                SetupChart();
            }
        }

        private void SetupChart()
        {
            if (ChartHost != null)
            {
                var chart = new CartesianChart();
                chart.SetBinding(CartesianChart.SeriesProperty, new Binding("SalesSeries"));
                chart.SetBinding(CartesianChart.XAxesProperty, new Binding("XAxes"));
                ChartHost.Content = chart;
            }
        }
    }
}