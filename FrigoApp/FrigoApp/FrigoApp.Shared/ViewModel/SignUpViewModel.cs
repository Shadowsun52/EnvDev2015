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
    public class SignUpViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public ObservableCollection<User> userAlreadySignUp { get; private set;  }

        private IMobileServiceTable<User> userTable = App.FappClient.GetTable<User>();

        private String login;

        public String Login
        {
            get { return login; }
            set {
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

        private String confirmPassword;

        public String ConfirmPassword
        {
            get { return confirmPassword; }
            set
            {
                confirmPassword = value;
                RaisePropertyChanged("confirmPassword");
            }
        }

        private String email;

        public String Email
        {
            get { return email; }
            set
            {
                email = value;
                RaisePropertyChanged("email");
            }
        }

        public SignUpViewModel(INavigationService navigationService = null)
        {
            _navigationService = navigationService;
        }

        public ICommand SignUpUser
        {
            get
            {
                return new RelayCommand(
                    async () =>
                    {
                        if(checkAllFieldIsFull())
                        {
                            if (checkLoginIsFree())
                            {
                                if(String.Equals(password, confirmPassword))
                                {
                                    if (checkFormatEmail())
                                    {
                                        User newUser = new User(login, password, email);
                                        await userTable.InsertAsync(newUser);
                                        var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                                        var str = loader.GetString("signUpSuccess");
                                        ShowMessageBox(str);
                                        _navigationService.GoBack();
                                    }
                                    else
                                    {
                                        var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                                        var str = loader.GetString("badFormatEmail");
                                        ShowMessageBox(str);
                                    }
                                }
                                else
                                {
                                    var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                                    var str = loader.GetString("notSameConfirmPassword");
                                    ShowMessageBox(str);
                                }
                            }
                            else
                            {
                                var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                                var str = loader.GetString("errorLoginExist");
                                ShowMessageBox(str);
                            }
                        }
                        else
                        {
                            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                            var str = loader.GetString("errorEmptyField");
                            ShowMessageBox(str);
                        }
                    });
            }
        }

        private bool checkLoginIsFree()
        {
            return true;
        }

        private bool checkAllFieldIsFull()
        {
            return !String.IsNullOrEmpty(login) && !String.IsNullOrEmpty(password) && !String.IsNullOrEmpty(confirmPassword) && !String.IsNullOrEmpty(email);
        }

        private bool checkFormatEmail()
        {
            Regex regex = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
            Match match = regex.Match(email);

            return match.Success;
        }

        private async void ShowMessageBox(string message)
        {
            var dialog = new MessageDialog(message.ToString());
            await dialog.ShowAsync();
        }
    }
}
