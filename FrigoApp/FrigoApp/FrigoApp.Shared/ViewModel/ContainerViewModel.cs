using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Windows.UI.Popups;
using FrigoApp.Model;
using Microsoft.WindowsAzure.MobileServices;

namespace FrigoApp.ViewModel
{
    class ContainerViewModel :ViewModelBase
    {
        private INavigationService _navigationService;

        public ObservableCollection<Container> containers { get; private set; }

        private IMobileServiceTable<Container> containerTable = App.FappClient.GetTable<Container>();

        private String name;

        public String Name
        {
            get { return name;  }
            set {
                name = value;
                RaisePropertyChanged("name");
            }
        }

        private String type;

        public String Type
        {
            get { return type; }
            set
            {
                type = value;
                RaisePropertyChanged("type");
            }
        }

        private String proprio;

        public String Proprio
        {
            get { return proprio; }
            set
            {
                proprio = value;
                RaisePropertyChanged("proprio");
            }
        }

        public ObservableCollection<Container> items { get; private set; }

        private IMobileServiceTable<Item> itemTable = App.FappClient.GetTable<Item>();

        private String newItemName;

        public String NewItemName
        {
            get { return newItemName; }
            set
            {
                newItemName = value;
                RaisePropertyChanged("name");
            }
        }

        private String newItemType;

        public String NewItemType
        {
            get { return newItemType; }
            set
            {
                newItemType = value;
                RaisePropertyChanged("type");
            }
        }

        private DateTime newItemExpirationDate;

        public DateTime NewItemExpirationDate
        {
            get { return newItemExpirationDate; }
            set
            {
                newItemExpirationDate = value;
                RaisePropertyChanged("proprio");
            }
        }

        private int newItemQuantity;

        public int NewItemQuantity
        {
            get { return newItemQuantity; }
            set
            {
                newItemQuantity = value;
                RaisePropertyChanged("proprio");
            }
        }

        private int newItemIdContainer;

        public int NewItemIdContainer
        {
            get { return newItemIdContainer; }
            set
            {
                newItemIdContainer = value;
                RaisePropertyChanged("proprio");
            }
        }

        public ContainerViewModel (INavigationService navigationService = null)
        {
            _navigationService = navigationService;
        }

        public ICommand AddContainer
        {

        }

        public ICommand ReadItems
        {

        }

    }
}
