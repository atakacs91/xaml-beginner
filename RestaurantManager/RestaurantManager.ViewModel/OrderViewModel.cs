using System.Collections.Generic;
using RestaurantManager.Models;
using System.Collections.ObjectModel;
using RestaurantManager.ViewModel;
using System;
using System.Linq;
using Windows.UI.Xaml.Controls;

namespace RestaurantManager.ViewModels
{
    public class OrderViewModel : ViewModel
    {       
        public OrderViewModel()
        {
            AddItem = new DelegateCommand<MenuItem>(AddItemExecute);
            SubmitOrder = new DelegateCommand<object>(SubmitOrderExecute);
        }
        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;

            this.CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>();
            

            this.NotifyPropertyChanged("MenuItems");
            this.NotifyPropertyChanged("CurrentlySelectedMenuItems");
        }

        public ObservableCollection<MenuItem> MenuItems { get; set; }

        public ObservableCollection<MenuItem> CurrentlySelectedMenuItems { get; set; }

        public DelegateCommand<MenuItem> AddItem { get; private set; }

        public DelegateCommand<object> SubmitOrder { get; private set; }

        private void AddItemExecute(MenuItem item)
        {
            this.CurrentlySelectedMenuItems.Add(item);
            this.NotifyPropertyChanged("OrderItems");
        }

        private void SubmitOrderExecute(object parameter)
        {
            ListView listView = parameter as ListView;
            ObservableCollection<MenuItem> ordered = new ObservableCollection<MenuItem>();
            
            foreach (MenuItem item in listView.Items)
            {
                ordered.Add(item);
            }

            Order ToSubmit = new Order
            {
                Complete = false,
                Expedite = false,
                SpecialRequests = String.Empty,
                Table = base.Repository.Tables.Last(),
                Items = ordered
            };
            base.Repository.Orders.Add(ToSubmit);
        }
    }
}
