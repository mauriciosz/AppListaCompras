using AppListaCompras.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppListaCompras.Libraries.Converters
{
    public class TextItensFaltantesNaLista : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            List<Product> listProducts = (List<Product>)value!;

            int HasCaugthCount = listProducts.Where(a => a.HasCaugth == false).Count();  // SE 'a' (produto) tiver marcado a propriedade HasCount, adiciona na contagem...

            return (HasCaugthCount > 1) ? $"Faltam {HasCaugthCount} itens": $"Falta {HasCaugthCount} item";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
