using ChalkCouture.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChalkCouture.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        public ObservableCollection<MasterMenuItem> MenuItems { get; set; }

        public ICommand OnMenuSelectedCommand
        {

            get { return new Command<MasterMenuItem>(OnMenuSelected); }
        }


        public MenuViewModel()
        {
            MenuItems = new ObservableCollection<MasterMenuItem>(new[]
            {
                //    new MasterMenuItem { Id = 0, Title = "Home", Icon ="home.png" , MenuItem = MainMenu.Home },
                //    new MasterMenuItem { Id = 1, Title = "Customers", Icon = "news.png" , MenuItem = MainMenu.Customers },
                //    new MasterMenuItem { Id = 2, Title = "Wholesale Inventory", Icon = "directory.png", MenuItem = MainMenu.WholesaleInventory },
                //    new MasterMenuItem { Id = 4, Title = "Personal Inventory",  Icon = "profile.png", MenuItem = MainMenu.PersonalInventory },
                //    new MasterMenuItem { Id = 5, Title = "My Orders",  Icon = "logut.png", MenuItem = MainMenu.Orders },
                //     new MasterMenuItem { Id = 5, Title = "Transfer",  Icon = "logut.png", MenuItem = MainMenu.Transfer },
                //});
                 new MasterMenuItem { Id = 0, Title = "Home", MenuItem = MainMenu.Home },
                    new MasterMenuItem { Id = 1, Title = "Customers", MenuItem = MainMenu.Customers },
                    new MasterMenuItem { Id = 2, Title = "Wholesale Inventory",  MenuItem = MainMenu.WholesaleInventory },
                    new MasterMenuItem { Id = 4, Title = "Personal Inventory",   MenuItem = MainMenu.PersonalInventory },
                    new MasterMenuItem { Id = 5, Title = "My Orders",   MenuItem = MainMenu.Orders },
                     new MasterMenuItem { Id = 5, Title = "Transfer",   MenuItem = MainMenu.Transfer },
                });
        }


        private async void OnMenuSelected(MasterMenuItem obj)
        {
            var selectedMenu = (MasterMenuItem)obj;
            switch (selectedMenu.MenuItem)
            {
                case MainMenu.Home:
                    await _navigationService.NavigateToAsync<RootPageViewModel>();
                    break;
                case MainMenu.Customers:
                    await _navigationService.NavigateToAsync<CustomersViewModel>();
                    break;
                //case MainMenu.WholesaleInventory:
                //    await _navigationService.NavigateToAsync<>();
                //    break;
                //case MainMenu.PersonalInventory:
                //    await _navigationService.NavigateToAsync<>();
                //    break;
                case MainMenu.Orders:
                    await _navigationService.NavigateToAsync<OrdersViewModel>();
                    break;
                case MainMenu.Transfer:
                    await _navigationService.NavigateToAsync<TransferViewModel>();
                    break;
            }
        }
    }
}
