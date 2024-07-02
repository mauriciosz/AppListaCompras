using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppListaCompras.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public string QuantityUnitMeasure { get; set; } // trocar para tipo enumerado...
        public decimal Price { get; set; }
        public bool HasCaugth { get; set; } = false; // verifica se o produto da lista já foi pego por algum usuário...
    }
}
