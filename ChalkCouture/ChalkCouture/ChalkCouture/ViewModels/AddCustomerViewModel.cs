using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChalkCouture.ViewModels
{
    public class AddCustomerViewModel : BaseViewModel
    {
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
    }
}
