using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Background;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour en savoir plus sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace FrigoApp
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoqué lorsque cette page est sur le point d'être affichée dans un frame.
        /// </summary>
        /// <param name="e">Données d'événement décrivant la manière dont l'utilisateur a accédé à cette page.
        /// Ce paramètre est généralement utilisé pour configurer la page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: préparer la page pour affichage ici.

            // TODO: si votre application comporte plusieurs pages, assurez-vous que vous
            // gérez le bouton Retour physique en vous inscrivant à l’événement
            // Événement Windows.Phone.UI.Input.HardwareButtons.BackPressed.
            // Si vous utilisez le NavigationHelper fourni par certains modèles,
            // cet événement est géré automatiquement.

            this.SetBackgroundAgentOn();
        }

        public void SetBackgroundAgentOn()
        {
            var taskRegistered = false;
            var taskName = "BackgroundTasks";

            foreach (var task in BackgroundTaskRegistration.AllTasks)
            {
                if (task.Value.Name == taskName)
                {
                    taskRegistered = true;
                    break;
                }
            }
            if (taskRegistered == false)
            {
                var taskBuilder = new BackgroundTaskBuilder();
                taskBuilder.Name = taskName;
                taskBuilder.TaskEntryPoint = typeof(BackgroundAgent.Notifications).FullName;
                taskBuilder.SetTrigger(new SystemTrigger(SystemTriggerType.InternetAvailable, false));
                //taskBuilder.SetTrigger(new MaintenanceTrigger(15, false));


                var registration = taskBuilder.Register();
            }
            
        }
    }
}
