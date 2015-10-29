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

        private Container newContainer;
        
        public Container NewContainer
        {
            get { return NewContainer; }
            set
            {
                newContainer = value;
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

            var items = await query.ToListAsync();

            foreach (var item in items)
                Containers.Add(item);
        }
   
        //public ICommand AddContainer
        //{
        //    get
        //    {
        //        return RelayCommand<Container>(
        //            (newContainer) =>
        //            {

        //            });
        //    }
        //}

        private async void ShowMessageBox(string message)
        {
            var dialog = new MessageDialog(message.ToString());
            await dialog.ShowAsync();
        }
    }
}
