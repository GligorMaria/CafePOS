using System.Windows.Controls;
using CafePOS.ViewModels;

namespace CafePOS.Views
{
    public partial class OrderView : UserControl
    {
        public OrderView()
        {
            InitializeComponent();
            DataContext = new OrderViewModel();
        }
    }
}
