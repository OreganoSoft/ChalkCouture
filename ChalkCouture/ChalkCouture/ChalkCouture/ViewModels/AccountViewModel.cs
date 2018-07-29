using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChalkCouture.ViewModels
{
    public class AccountViewModel : BaseViewModel
    {
        public ICommand ChangePasswordCommand
        {
            get
            {
                return new Command(() =>
                {

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

        public AccountViewModel()
        {

        }
    }
}
