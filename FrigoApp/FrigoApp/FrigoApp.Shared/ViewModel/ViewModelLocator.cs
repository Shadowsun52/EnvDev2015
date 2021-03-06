/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:FrigoApp"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace FrigoApp.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            NavigationService navigation = new NavigationService();

            navigation.Configure("MainPage", typeof(MainPage));
            navigation.Configure("HomePage", typeof(HomePage));
            navigation.Configure("SignUpPage", typeof(SignUpPage));
            navigation.Configure("ContainerPage", typeof(ContainerPage));
            navigation.Configure("UpdatePage", typeof(UpdatePage));


            SimpleIoc.Default.Register<INavigationService>(() => navigation);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<SignUpViewModel>();
            SimpleIoc.Default.Register<ContainerViewModel>();
            SimpleIoc.Default.Register<UpdateViewModel>();

        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public HomeViewModel Home
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HomeViewModel>();
            }
        }

        public SignUpViewModel SignUp
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SignUpViewModel>();
            }
        }

        public ContainerViewModel Container
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ContainerViewModel>();
            }
        }

        public UpdateViewModel Update
        {
            get
            {
                return ServiceLocator.Current.GetInstance<UpdateViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}