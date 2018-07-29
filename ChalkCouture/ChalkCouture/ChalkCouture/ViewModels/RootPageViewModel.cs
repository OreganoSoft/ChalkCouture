using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChalkCouture.ViewModels
{
    public class RootPageViewModel : BaseViewModel
    {

        private MenuViewModel _menuViewModel;
        public MenuViewModel MenuViewModel
        {
            get
            {
                return _menuViewModel;
            }
            set
            {
                _menuViewModel = value;
                OnPropertyChanged(nameof(MenuViewModel));
            }
        }

        public RootPageViewModel()
        {
            this.MenuViewModel = new MenuViewModel();
        }

        public override Task InitializeAsync(object parameter)
        {
            return _navigationService.NavigateToAsync<DashboardViewModel>();
        }
    }
}
