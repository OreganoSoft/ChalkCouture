using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChalkCouture.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private bool hasEnabledSounds;

        public bool HasEnabledSounds
        {
            get { return hasEnabledSounds; }
            set
            {
                hasEnabledSounds = value;
                OnPropertyChanged(nameof(HasEnabledSounds));
            }
        }

        private bool hasOrderComplete;

        public bool HasOrderComplete
        {
            get { return hasOrderComplete; }
            set
            {
                hasOrderComplete = value;
                OnPropertyChanged(nameof(HasOrderComplete));
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


    }
}
