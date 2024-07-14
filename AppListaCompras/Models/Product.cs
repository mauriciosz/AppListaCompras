using AppListaCompras.Models.Enums;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppListaCompras.Models
{
    public partial class Product : ObservableObject
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public UnitMeasure QuantityUnitMeasure { get; set; } // trocar para tipo enumerado...
        public decimal Price { get; set; }

        [ObservableProperty]
        private bool hasCaugth = false; // verifica se o produto da lista já foi pego por algum usuário...
    }
}
