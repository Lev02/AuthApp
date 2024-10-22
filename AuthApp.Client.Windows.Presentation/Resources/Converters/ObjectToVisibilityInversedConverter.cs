using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace AuthApp.Client.Windows.Presentation.Resources.Converters
{
    public class ObjectToVisibilityInversedConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b)
            {
                if (b)
                    return Visibility.Collapsed;
                return Visibility.Visible;
            }

            if (value is int intVal)
            {
                if (intVal > 0)
                    return Visibility.Collapsed;
                return Visibility.Visible;
            }

            if (value != null)
                return Visibility.Collapsed;

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
