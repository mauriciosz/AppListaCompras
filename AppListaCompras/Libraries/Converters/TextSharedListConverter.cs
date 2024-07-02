using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppListaCompras.Libraries.Converters
{
    public class TextSharedListConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            int? userCount = (int?)value;

            // se for nulo, acaba aqui..
            if (!userCount.HasValue)
                return null;

            return (userCount >= 2) ? "(Lista Compartilhada)" : string.Empty;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
