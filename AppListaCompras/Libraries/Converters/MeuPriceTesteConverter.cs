using AppListaCompras.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppListaCompras.Libraries.Converters
{
    public class MeuPriceTesteConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var prod = values[0] as Product;

            if (prod == null)
                return "R$ 0,00";

            if (prod.HasCaugth)
            {
                return (prod.Price * prod.Quantity).ToString("C");
            }
            else
            {
                if (prod.Price > 0)
                {
                    return prod.Price.ToString("C") + " " + prod.QuantityUnitMeasure;
                }

                return prod.Price.ToString("C");
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
