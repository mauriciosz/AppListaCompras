using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppListaCompras.Models
{
    public class ListToBuy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public List<User> Users { get; set; } = new List<User>(); 
        public DateTimeOffset CreateAt { get; set; } 
    }
}
