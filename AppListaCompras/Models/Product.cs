using AppListaCompras.Models.Enums;
using CommunityToolkit.Mvvm.ComponentModel;
using MongoDB.Bson;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppListaCompras.Models
{
    // O ObservableObject que faz a notificação para a IU foi trocada pelo IRealmObject que tbm faz isso..
    public partial class Product : IRealmObject
    {
        [PrimaryKey]
        [MapTo("_id")]
        public ObjectId Id { get; set; }

        [MapTo("name")]
        public string Name { get; set; } = string.Empty;

        [MapTo("quantity")]
        public decimal Quantity { get; set; }

        [MapTo("quantity_unit_measure")]
        public string QuantityUnitMeasure { get; set; } = (string)Enum.GetName(UnitMeasure.Un)!;

        [MapTo("price")]
        public decimal Price { get; set; }

        [MapTo("has_caugth")]
        public bool HasCaugth { get; set; }

        [MapTo("create_at")]
        public DateTimeOffset CreateAt { get; set; }
    }
}
