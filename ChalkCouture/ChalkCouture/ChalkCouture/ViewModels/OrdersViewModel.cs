using ChalkCouture.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChalkCouture.ViewModels
{
    public class OrdersViewModel : BaseViewModel
    {
        public ObservableCollection<Order> Orders { get; set; }


        private int ordersCount;

        public int OrdersCount
        {
            get { return ordersCount; }
            set
            {
                ordersCount = value;
                OnPropertyChanged(nameof(OrdersCount));
            }
        }

        private string searchText;

        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                OnPropertyChanged(nameof(SearchText));
            }
        }
        public ICommand HomeCommand
        {
            get
            {
                return new Command(() =>
                {
                    _navigationService.NavigateToAsync<RootPageViewModel>();
                });
            }
        }
        public ICommand AllOrdersCommand
        {
            get
            {
                return new Command(() =>
                {
                });
            }
        }
        
        public ICommand OpenOrdersCommand
        {
            get
            {
                return new Command(() =>
                {
                });
            }
        }
        public ICommand ClosedOrdersCommand
        {
            get
            {
                return new Command(() =>
                {
                });
            }
        }

        public OrdersViewModel()
        {
            this.Orders = new ObservableCollection<Order>
            {
              new Order{ Customer= new Customer{ FirstName="Raghava ",LastName="reddy",Email="raghava@gmail.com",Mobile="9052839350" },CompletedDate=DateTime.Now,Id=45698 },
                new Order{ Customer=new Customer{ FirstName="Suresh",LastName="reddy",Email="Suresh@gmail.com",Mobile="9052839350"},CompletedDate=DateTime.Now,Id=45698 },
                new Order{ Customer=new Customer { FirstName = "XXX", LastName = "yy", Email = "xy@gmail.com", Mobile = "9052839350" },CompletedDate = DateTime.Now,Id = 45698 },
                new Order{ Customer=new Customer{ FirstName="david",LastName="reddy",Email="xxx@gmail.com",Mobile="9052839350"},CompletedDate=DateTime.Now,Id=45698 },
                new Order{ Customer=new Customer{ FirstName="Smith",LastName="yadav",Email="smith@gmail.com",Mobile="9052839350"},CompletedDate=DateTime.Now,Id=45698 },
                new Order{ Customer= new Customer{FirstName="Siva",LastName="yy",Email="Siva@gmail.com",Mobile="9052839350" },CompletedDate=DateTime.Now,Id=45698 },
                new Order{ Customer=new Customer{ FirstName="david",LastName="reddy",Email="xxx@gmail.com",Mobile="9052839350"},CompletedDate=DateTime.Now,Id=45698 },
            };
            this.OrdersCount = this.Orders.Count;

        }
    }
}
