using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
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

        }

        public ICommand GoToHomePage
        {
            get
            {
                return new RelayCommand(
                    () =>
                    {
                        if(login == "test")
                        {
                            if(password == "test")
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

        private async void ShowMessageBox(string message)
        {
            var dialog = new MessageDialog(message.ToString());
            await dialog.ShowAsync();
        }
    }
}