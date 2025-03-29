using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DashBoard.Converter
{
    public class ControlDeviceVisibleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int deviceTypeNumber = System.Convert.ToInt32(value);
            Debug.WriteLine("value: " + value.ToString());

            int deviceType = System.Convert.ToInt32(parameter);
            Debug.WriteLine("parameter: " + parameter.ToString());

            int deviceCheck = 0;
            if (deviceType == 1) deviceCheck = 2001;
            else if (deviceType == 2) deviceCheck = 2002;



            Visibility? deviceVisibility;
            Debug.WriteLine("deviceTypeNumber : " + deviceTypeNumber);
            Debug.WriteLine("deviceCheck : " + deviceCheck);
            if (deviceTypeNumber == deviceCheck) deviceVisibility = Visibility.Visible;
            else deviceVisibility = Visibility.Collapsed;

            Debug.WriteLine("visible : " + deviceVisibility);

            return deviceVisibility;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
