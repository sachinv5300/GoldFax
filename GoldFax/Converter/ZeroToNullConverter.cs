using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace GoldFax.Converter
{
    public partial class ZeroToNullConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var val = 0;
            if (value != null)
            {
                if (value.ToString() == "0")
                {
                    return DependencyProperty.UnsetValue;
                }
                else
                {
                    return value;
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                if (string.IsNullOrEmpty(value.ToString()))

                    return null;
            }

            return value;
        }
        #endregion
    }
}
