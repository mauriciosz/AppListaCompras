using AppListaCompras.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppListaCompras.Libraries.Converters
{
    public class TextItensAdicionadosNaLista : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            List<Product> listProducts = (List<Product>)value!;

            int CaugthProducts = listProducts.Where(a => a.HasCaugth == true).Count();
            return (CaugthProducts > 1) ? $"{CaugthProducts} Itens" : $"{CaugthProducts} Item";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
