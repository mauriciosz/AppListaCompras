using AppListaCompras.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppListaCompras.Libraries.Converters
{
    public class TextTotalPriceItensInCarConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            ListToBuy? listToBuy = value as ListToBuy;
            if (listToBuy == null)
                return "R$ 0,00";

            if (listToBuy.Products.Count == 0)
                return "R$ 0,00";

            decimal totalPrice = 0;
            foreach (var product in listToBuy.Products)
            {
                if (product.HasCaugth)
                {
                    totalPrice += product.Price * product.Quantity;
                }
            }
            return totalPrice.ToString("C"); // esse "C" no ToString() faz a corversão em string seja do tipo moeda "R$ 0,00"
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
