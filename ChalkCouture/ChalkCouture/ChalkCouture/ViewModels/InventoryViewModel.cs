using ChalkCouture.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChalkCouture.ViewModels
{
    public class InventoryViewModel : BaseViewModel
    {
        public ObservableCollection<Customer> Customers { get; set; }

        public ICommand OnMenuSelectedCommand
        {

            get { return new Command<Customer>(OnMenuSelected); }
        }

        private int customersCount;

        public int CustomersCount
        {
            get { return customersCount; }
            set
            {
                customersCount = value;
                OnPropertyChanged(nameof(CustomersCount));
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

        public ICommand TransferInventoryCommand
        {
            get
            {
                return new Command(() =>
                {
                    _navigationService.NavigateToAsync<TransferViewModel>();
                });
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


        public InventoryViewModel()
        {
            this.Customers = new ObservableCollection<Customer>
            {
                new Customer{ FirstName="Raghava ",LastName="reddy",Email="raghava@gmail.com",Mobile="9052839350" },
                new Customer{ FirstName="Suresh",LastName="reddy",Email="Suresh@gmail.com",Mobile="9052839350"},
                new Customer{FirstName="XXX",LastName="yy",Email="xy@gmail.com",Mobile="9052839350" },
                new Customer{ FirstName="david",LastName="reddy",Email="xxx@gmail.com",Mobile="9052839350"},
                new Customer{ FirstName="Smith",LastName="yadav",Email="smith@gmail.com",Mobile="9052839350"},
                 new Customer{FirstName="Siva",LastName="yy",Email="Siva@gmail.com",Mobile="9052839350" },
                new Customer{ FirstName="david",LastName="reddy",Email="xxx@gmail.com",Mobile="9052839350"},
            };
            this.CustomersCount = this.Customers.Count;
        }

        private void OnMenuSelected(Customer obj)
        {
        }
    }
}
