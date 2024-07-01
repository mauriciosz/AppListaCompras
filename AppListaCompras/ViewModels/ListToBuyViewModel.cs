using AppListaCompras.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppListaCompras.ViewModels
{
    public partial class ListToBuyViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<ListToBuy> _listToBuy;

        public ListToBuyViewModel()
        {
            ListToBuy = new ObservableCollection<ListToBuy>()
            {
                new ListToBuy()
                {
                    Name = "Minha Lista",
                    Users = new List<User>()
                    {   // Lista com mais de um usuário = "Lista Comportilhada"
                        new User { Name = "Mauricio Zaccaro", Email = "neto.mauricio@unemat.br" },
                        new User { Name = "Katia Neves", Email = "katianeves@gmail.com"}
                    },
                    Products = new List<Product>()
                    {   // Colocando produtos vazios por enquanto, só para gerar quantidade na lista inicial
                        new Product { },
                        new Product { },
                        new Product { }
                    }
                },
                new ListToBuy()
                {
                    Name = "Minha Lista",
                    Users = new List<User>()
                    {
                        new User { Name = "Mauricio Zaccaro", Email = "neto.mauricio@unemat.br" },
                    },
                    Products = new List<Product>()
                    {   // Colocando produtos vazios por enquanto, só para gerar quantidade na lista inicial
                        new Product { },
                        new Product { },
                        new Product { },
                        new Product { },
                        new Product { }
                    }
                }
            };
        }

    }
}
