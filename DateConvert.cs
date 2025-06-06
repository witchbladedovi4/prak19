using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfApp3
{
    public class DateConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime date)
            {
                var today = DateTime.Today;
                
                if (date.Date < today) return Brushes.Red; 
                if (date.Date == today) return (Brush)new BrushConverter().ConvertFrom("#FFEA6A20"); 
                if (date.Date == today.AddDays(1)) return (Brush)new BrushConverter().ConvertFrom("#DAA520"); 
                return (Brush)new BrushConverter().ConvertFrom("#FF71C52F");
            }

            return Brushes.Black; 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
