using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChalkCouture.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand SignInCommand
        {
            get { return new Command(Login); }
        }


        public ICommand ForgotPasswordCommand
        {
            get
            {
                return new Command(ForgotPassword);
            }
        }

        public ICommand AutofillCommand
        {
            get { return new Command(AutoFillWithLastPass); }
        }


        public LoginViewModel()
        {
        }

        private void Login()
        {
            _navigationService.NavigateToAsync<RootPageViewModel>();
        }
        private void ForgotPassword(object obj)
        {
            // code to be implement
        }
        private void AutoFillWithLastPass(object obj)
        {
            // code to be implement
        }

    }
}
