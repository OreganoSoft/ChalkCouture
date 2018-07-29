using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChalkCouture.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {

        public ICommand CustomersCommand
        {

            get { return new Command(GetCustomers); }
        }
        public ICommand InventoryCommand
        {

            get { return new Command(GetInventory); }
        }
        public ICommand TransferCommand
        {

            get { return new Command(GetTransferDetails); }
        }
        public ICommand OrdersCommand
        {

            get { return new Command(GetOrders); }
        }

        public ICommand SettingsCommand
        {
            get
            {
                return new Command(() =>
                {
                    _navigationService.NavigateToAsync<SettingsViewModel>();
                });
            }
        }

        public ICommand AccountCommand
        {
            get
            {
                return new Command(() =>
                {
                    _navigationService.NavigateToAsync<CheckoutViewModel>();
                });
            }
        }


        public DashboardViewModel()
        {

        }

        private void GetOrders(object obj)
        {
            _navigationService.NavigateToAsync<OrdersViewModel>();
        }

        private void GetTransferDetails(object obj)
        {
            _navigationService.NavigateToAsync<TransferViewModel>();
        }

        private void GetInventory(object obj)
        {
            _navigationService.NavigateToAsync<InventoryViewModel>();
        }

        private void GetCustomers(object obj)
        {
            _navigationService.NavigateToAsync<CustomersViewModel>();
        }
    }
}
