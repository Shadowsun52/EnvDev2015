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
    public class ContainerViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public ObservableCollection<Item> Items { get; private set; }

        private IMobileServiceTable<Item> itemsTable = App.FappClient.GetTable<Item>();

        private Container container;

        public Container Container
        {
            get { return container; }
            set
            {
                container = value;
                RaisePropertyChanged("name");
            }
        }

        public ObservableCollection<Type> Types { get; private set; }

        private IMobileServiceTable<Type> typesTable = App.FappClient.GetTable<Type>();

        private String newItemName;

        public String NewItemName
        {
            get { return newItemName; }
            set
            {
                newItemName = value;
                RaisePropertyChanged("NewItemName");
            }
        }

        private String newItemType;

        public String NewItemType
        {
            get { return newItemType; }
            set
            {
                newItemType = value;
                RaisePropertyChanged("NewItemType");
            }
        }

        private DateTime newItemExpirationDate;

        public DateTime NewItemExpirationDate
        {
            get { return newItemExpirationDate; }
            set
            {
                newItemExpirationDate = value;
                RaisePropertyChanged("NewItemExpirationDate");
            }
        }

        private int newItemQuantity;

        public int NewItemQuantity
        {
            get { return newItemQuantity; }
            set
            {
                newItemQuantity = value;
                RaisePropertyChanged("NewItemQuantity");
            }
        }

        private int newItemIdContainer;

        public ContainerViewModel(INavigationService navigationService = null)
        {
            _navigationService = navigationService;
        }

    //    private async void findItemByIdContainer()
    //    {
    //        IMobileServiceTableQuery<Item> query = itemsTable.Where(Item => Item.Idcontainer == Container.id);
    //        Items.Clear();

    //        IEnumerable<Item> items = await query.ToListAsync();

    //        items = items.OrderBy(c => c.Name);

    //        foreach (var item in items)
    //            Containers.Add(item);
    //    }

    }
}
