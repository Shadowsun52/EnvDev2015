using FrigoApp.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Windows.UI.Popups;

namespace FrigoApp.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        private INavigationService _navigationService;
        
        //public ObservableCollection<User> userFound { get; private set; }

        private IMobileServiceTable<User> userTable = App.FappClient.GetTable<User>();

        private String login;

        public String Login
        {
            get { return login;  }
            set
            {
                login = value;
                RaisePropertyChanged("login");
            }
        }

        private String password;

        public String Password
        {
            get { return password; }
            set
            {
                password = value;
                RaisePropertyChanged("password");
            }
        }

        public MainViewModel(INavigationService navigationService = null)
        {
            _navigationService = navigationService;

            //userFound = new ObservableCollection<User>();

        }

        public ICommand GoToHomePage
        {
            get
            {
                return new RelayCommand(
                    async () =>
                    {
                        IMobileServiceTableQuery<User> query = userTable.Where(user => user.Login == login);

                        //userFound.Clear();

                        var userFound = await query.ToListAsync();
                        //foreach (var item in items)
                        //    userFound.Add(item);

                        if(userFound.Count != 0)
                        {
                            if(userFound[0].Password == password)
                            {
                                var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                                var str = loader.GetString("validConnexion");
                                ShowMessageBox(str);
                                _navigationService.NavigateTo("HomePage");
                            }
                            else
                            {
                                var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                                var str = loader.GetString("errorPassword");
                                ShowMessageBox(str);
                            }                            
                        }
                        else
                        {
                            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                            var str = loader.GetString("errorLogin");
                            ShowMessageBox(str);
                        }
                    });
            }
        }

        public ICommand GoToSignUp
        {
            get
            {
                return new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("SignUpPage");
                    });
            }
        }

        private async void ShowMessageBox(string message)
        {
            var dialog = new MessageDialog(message.ToString());
            await dialog.ShowAsync();
        }
    }
}