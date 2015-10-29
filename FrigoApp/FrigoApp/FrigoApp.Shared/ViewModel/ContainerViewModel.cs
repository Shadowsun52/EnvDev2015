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
using System.Linq;

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
                FindItemByIdContainer();
            }
        }

        public ObservableCollection<TypeItem> Types { get; private set; }

        private IMobileServiceTable<TypeItem> typesTable = App.FappClient.GetTable<TypeItem>();

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

        private TypeItem newItemType;

        public TypeItem NewItemType
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

        private int newItemQuantity = 1;

        public int NewItemQuantity
        {
            get { return newItemQuantity; }
            set
            {
                newItemQuantity = value;
                RaisePropertyChanged("NewItemQuantity");
            }
        }

        public ContainerViewModel(INavigationService navigationService = null)
        {
            _navigationService = navigationService;
            Items = new ObservableCollection<Item>();
            Types = new ObservableCollection<TypeItem>();
            LoadType();
        }

        private async void FindItemByIdContainer()
        {
            IMobileServiceTableQuery<Item> query = itemsTable.Where(Item => Item.Idcontainer == Container.id);
            Items.Clear();

            IEnumerable<Item> list = await query.ToListAsync();

            list = list.OrderBy(i => i.Name);

            foreach (var item in list)
                Items.Add(item);
        }

        private async void LoadType()
        {

            IMobileServiceTableQuery<TypeItem> query = typesTable.OrderBy(type => type.Name);
            Items.Clear();

            IEnumerable<TypeItem> list = await query.ToListAsync();

            foreach (var item in list)
            {
                Types.Add(item);
            }
                
        }

        public ICommand AddNewItem
        {
            get
            {
                return new RelayCommand(
                    async () =>
                    {
                        if (CheckAllFieldIsFilled())
                        {

                            Item newItem = new Item(NewItemName, newItemType.id, newItemExpirationDate, newItemQuantity, Container.id);
                            await itemsTable.InsertAsync(newItem);

                            RefreshView();

                            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                            var str = loader.GetString("addItemSuccess");
                            ShowMessageBox(str);
                        }
                        else
                        {
                            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                            var str = loader.GetString("errorEmptyItem");
                            ShowMessageBox(str);
                        }
                    });
            }
        }

        private bool CheckAllFieldIsFilled()
        {
            return !String.IsNullOrEmpty(NewItemName);
        }

        private void RefreshView()
        {
            FindItemByIdContainer();
            NewItemName = String.Empty;
            NewItemQuantity = 1;
        }

        private async void ShowMessageBox(string message)
        {
            var dialog = new MessageDialog(message.ToString());
            await dialog.ShowAsync();
        }
    }
}
