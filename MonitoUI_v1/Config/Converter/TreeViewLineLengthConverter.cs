using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Config.Converter
{
    public class TreeViewLineLengthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int length = System.Convert.ToInt32(value);
            Debug.WriteLine(length);
            if(length > 13)
            {
                length -= 17;
            }
            return length.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //int ret = 0;
            //return int.TryParse((string)value, out ret) ? ret : 0;
            return "0";
        }
    }
}
