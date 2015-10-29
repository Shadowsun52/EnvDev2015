using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Windows.UI;
using Windows.UI.Xaml.Data;

namespace FrigoApp.Converters
{
    public class BackgroundContainerConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            bool isFreezer = (bool)value;

            if(isFreezer)
            {
                return "#006699";
            }
            else
            {
                return "#505050";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
