using ChalkCouture.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChalkCouture.ViewModels
{
    public class CustomersViewModel : BaseViewModel
    {
        public ObservableCollection<Customer> Customers { get; set; }

        public ICommand OnMenuSelectedCommand
        {

            get { return new Command<Customer>(OnMenuSelected); }
        }

        public ICommand AddCommand
        {
            get { return new Command(AddCustomer); }
        }

        public ICommand RefreshCommand { get { return new Command(Refresh); } }



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

        public CustomersViewModel()
        {
            this.Customers = new ObservableCollection<Customer>
            {
                new Customer{ FirstName="Raghava",LastName="reddy",Email="raghava@gmail.com",Mobile="9052839350" },
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
        private void AddCustomer(object obj)
        {
            _navigationService.NavigateToAsync<AddCustomerViewModel>();
        }
        private void Refresh(object obj)
        {
        }
    }
}
