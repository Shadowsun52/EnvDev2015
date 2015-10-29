using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System.Collections.ObjectModel;
using FrigoApp.Model;
using Windows.UI.Popups;
using Microsoft.WindowsAzure.MobileServices;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace FrigoApp.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        private IMobileServiceTable<Container> containerTable = App.FappClient.GetTable<Container>();

        public ObservableCollection<Container> Containers { get; private set; }

        private string idUser;

        public String IdUser
        {
            get { return idUser; }
            set
            {
                idUser = value;
                findContainerOfUser();
            }
        }

        private Container selectedContainer;

        public Container SelectedContainer
        {
            get { return selectedContainer; }
            set
            {
                selectedContainer = value;
                //allers sur la page containers
            }
        }

        private string newContainerName;

        public String NewContainerName
        {
            get { return newContainerName; }
            set
            {
                newContainerName = value;
                RaisePropertyChanged("NewContainerName");
            }
        }

        private bool newContainerIsFreezer;

        public Boolean NewContainerIsFreezer
        {
            get { return newContainerIsFreezer; }
            set
            {
                newContainerIsFreezer = value;
                RaisePropertyChanged("NewContainerIsFreezer");
            }
        }

        public HomeViewModel(INavigationService navigationService = null)
        {
            _navigationService = navigationService;
            Containers = new ObservableCollection<Container>();
        }

        private async void findContainerOfUser()
        {
            IMobileServiceTableQuery<Container> query = containerTable.Where(Container => Container.Proprio == IdUser);

            Containers.Clear();

            var items = await query.ToListAsync();

            foreach (var item in items)
                Containers.Add(item);
        }

        public ICommand AddContainer
        {
            get
            {
                return new RelayCommand<Container>(
                    async (selectedContainer) =>
                    {
                        if (CheckAllFieldIsFilled())
                        {
                            Container newContainer = new Container(newContainerName, idUser, newContainerIsFreezer);
                            await containerTable.InsertAsync(newContainer);

                            RefreshView();

                            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                            var str = "";
                            if (newContainerIsFreezer)
                                str = loader.GetString("addFreezerSuccess");
                            else
                                str = loader.GetString("addFridgeSuccess");
                            ShowMessageBox(str);
                        }
                        else
                        {
                            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                            var str = loader.GetString("errorEmptyNameContainer");
                            ShowMessageBox(str);
                        }
                    });
            }
        }

        private bool CheckAllFieldIsFilled()
        {
            return !String.IsNullOrEmpty(NewContainerName);
        }

        private void RefreshView()
        {
            findContainerOfUser();
            NewContainerName = String.Empty;
            NewContainerIsFreezer = false;
        }

        private async void ShowMessageBox(string message)
        {
            var dialog = new MessageDialog(message.ToString());
            await dialog.ShowAsync();
        }
    }
}
