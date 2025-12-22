using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CafePOS.Models;
using CafePOS.Models.Enums;
using CafePOS.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CafePOS.Data;


namespace CafePOS.ViewModels
{
    public class OrderViewModel : INotifyPropertyChanged
    {
        private readonly OrderManager _orderManager;
        private readonly SalesLogService _logService;

        public ObservableCollection<MenuItem> MenuItems { get; set; } = new();
        public ObservableCollection<MenuItem> CurrentOrderItems { get; set; } = new();
        
        public decimal Total => _orderManager.CurrentOrder.CalculateTotal();

        public ICommand AddToOrderCommand { get; }
        public ICommand RemoveFromOrderCommand { get; }
        public ICommand PayCashCommand { get; }
        public ICommand PayCardCommand { get; }

        public OrderViewModel()
        {
            _orderManager = new OrderManager();
            _logService = new SalesLogService();

            // Commands
            AddToOrderCommand = new RelayCommand(item => AddToOrder((MenuItem)item!));
            RemoveFromOrderCommand = new RelayCommand(item => RemoveFromOrder((MenuItem)item!));
            PayCashCommand = new RelayCommand(_ => CompleteSale(PaymentType.Cash));
            PayCardCommand = new RelayCommand(_ => CompleteSale(PaymentType.Card));

            // Load Menu items from Menu.cs
            Menu cafeMenu = new Menu();
            foreach (var item in cafeMenu.GetAllItems())
            {
                MenuItems.Add(item);
            }
        }

        public void AddToOrder(MenuItem item)
        {
            if (item == null) return;
            _orderManager.addItem(item);
            CurrentOrderItems.Add(item);
            OnPropertyChanged(nameof(Total));
        }

        public void RemoveFromOrder(MenuItem item)
        {
            if (item == null) return;
            _orderManager.RemoveItem(item);
            CurrentOrderItems.Remove(item);
            OnPropertyChanged(nameof(Total));
        }

        public void CompleteSale(PaymentType type)
        {
            if (CurrentOrderItems.Count == 0) return;
            var transaction = _orderManager.CompleteSale(type);
            _logService.LogSale(transaction);
            CurrentOrderItems.Clear();
            OnPropertyChanged(nameof(Total));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}