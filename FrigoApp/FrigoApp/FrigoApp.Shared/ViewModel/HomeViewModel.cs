using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;

namespace FrigoApp.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public HomeViewModel(INavigationService navigationService = null)
        {
            _navigationService = navigationService;

        }
    }
}
