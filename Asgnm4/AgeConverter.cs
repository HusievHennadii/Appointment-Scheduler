using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Asgnm4
{
    [ValueConversion(typeof(int),typeof(Brush))]
    class AgeConverter:IValueConverter
    {
        public object Convert(object value, Type targetType,object parameter, CultureInfo culture)
        {
            int i = int.Parse(value.ToString());
            if(i<50)
            {
                return Brushes.Transparent;
            }
            else
            {
                return Brushes.Red;
            }
        }
        public object ConvertBack(object value,Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
