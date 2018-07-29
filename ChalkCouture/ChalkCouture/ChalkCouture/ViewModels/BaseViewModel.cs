using ChalkCouture.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace ChalkCouture.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected INavigationService _navigationService;

        private bool _isBusy;

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        private bool hasItems;

        public bool HasItems
        {
            get
            {
                return hasItems;
            }

            set
            {
                hasItems = value;
                OnPropertyChanged(nameof(HasItems));
            }
        }

        public BaseViewModel()
        {
            this._navigationService = ViewModelLocator.Resolve<INavigationService>();
        }

        public virtual Task InitializeAsync(object parameter)
        {
            return Task.FromResult(false);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
