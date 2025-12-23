using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using LiveChartsCore.SkiaSharpView.WPF;

namespace CafePOS.Views
{
    public partial class DashboardView : UserControl
    {
        public DashboardView()
        {
            InitializeComponent();

            // We use 'FindName' to get the control even if the compiler is stuck
            var host = this.FindName("ChartHost") as ContentControl;

            if (host != null)
            {
                var chart = new CartesianChart();

                // Set up the bindings manually
                chart.SetBinding(CartesianChart.SeriesProperty, new Binding("SalesSeries"));
                chart.SetBinding(CartesianChart.XAxesProperty, new Binding("XAxes"));

                host.Content = chart;
            }
        }
    }
}