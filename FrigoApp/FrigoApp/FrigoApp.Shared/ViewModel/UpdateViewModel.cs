using FrigoApp.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FrigoApp.ViewModel
{
    public class UpdateViewModel : ViewModelBase
    {
         private INavigationService _navigationService;

        public ObservableCollection<Item> Items { get; private set; }

        private IMobileServiceTable<Item> itemsTable = App.FappClient.GetTable<Item>();

        private Item item;

        public Item Item
        {
            get { return item; }
            set
            {
                item = value;
                RaisePropertyChanged("name");
            }
        }

        private String selectedItemName;

        public String SelectedItemName
        {
            get { return selectedItemName; }
            set
            {
                selectedItemName = value;
                RaisePropertyChanged("SelectedItemName");
            }
        }

        private String selectedItemType;

        public String SelectedItemType
        {
            get { return selectedItemType; }
            set
            {
                selectedItemType = value;
                RaisePropertyChanged("SelectedItemType");
            }
        }

        private DateTime selectedItemExpirationDate;

        public DateTime SelectedItemExpirationDate
        {
            get { return selectedItemExpirationDate; }
            set
            {
                selectedItemExpirationDate = value;
                RaisePropertyChanged("SelectedItemExpirationDate");
            }
        }

        private int selectedItemQuantity;

        public int SelectedItemQuantity
        {
            get { return selectedItemQuantity; }
            set
            {
                selectedItemQuantity = value;
                RaisePropertyChanged("SelectedItemQuantity");
            }
        }

        private int selectedItemIdContainer;

        public UpdateViewModel(INavigationService navigationService = null)
        {
            _navigationService = navigationService;
        }


    }
}
