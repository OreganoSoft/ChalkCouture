using ChalkCouture.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChalkCouture.ViewModels
{
    public class TransferViewModel : BaseViewModel
    {

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

        public ICommand SearchCommand { get { return new Command(Search); } }
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

        public ICommand IncrementCommand { get { return new Command<Item>(obj => { AddOrDecreaseCount(obj, true); }); } }

        public ICommand DecrementCount { get { return new Command<Item>(obj => { AddOrDecreaseCount(obj, false); }); } }



        private ObservableCollection<Item> items;

        public ObservableCollection<Item> Items
        {
            get { return items; }
            set
            {
                items = value;
                OnPropertyChanged(nameof(Items));
            }
        }
        public ICommand CheckedCheangedCommand { get { return new Command(Checked); } }

        private void Checked(object obj)
        {

        }

        private void Search(object obj)
        {
        }

        public TransferViewModel()
        {
            this.Items = new ObservableCollection<Item>
            {
                new Item{Name="Chalkology Paste Magenta Blush",Count=2},
                 new Item{Name="Chalkology Paste Magenta Blush",Count=2},
            };
        }

        private void AddOrDecreaseCount(Item item, bool increment)
        {
            if (increment)
            {
                item.Count++;
            }
            else if (item.Count > 0)
            {
                item.Count--;
            }
        }
    }
}
