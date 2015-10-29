using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.ApplicationModel.Background;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace BackgroundAgent
{
    public sealed class Notifications : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            BackgroundTaskDeferral deferral = taskInstance.GetDeferral();

            UpdateTile();

            deferral.Complete();
        }

        public void UpdateTile()
        {
            var loader = new Windows.ApplicationModel.Resources.ResourceLoader();

            XmlDocument messTile = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150Text03);
            var text = (XmlElement)messTile.SelectSingleNode("/tile/visual/binding/text[@id=1]");
            text.InnerText = loader.GetString("connexPerdue");

            var updater = TileUpdateManager.CreateTileUpdaterForApplication();
            updater.Update(new TileNotification(messTile));
        }
    }
}
