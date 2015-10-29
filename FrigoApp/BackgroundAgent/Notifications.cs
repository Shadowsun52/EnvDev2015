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
            XmlDocument tileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileSquare150x150Text03);
            //tileXml.GetElementsByTagName(textElementName)[0].InnerText = "coucou";
            var text = (XmlElement)tileXml.SelectSingleNode("/tile/visual/binding/text[@id=1]");
            text.InnerText = "Chouette appli quizz " + DateTime.Now.Minute;

            var updater = TileUpdateManager.CreateTileUpdaterForApplication();
            updater.Update(new TileNotification(tileXml));
        }
    }
}
