using AppListaCompras.Models;
using AppListaCompras.Views.Popups;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mopups.Services;
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
                    { 
                        new Product { Name = "Arroz 5kg", Quantity = 3, Price = 25.90m, HasCaugth = true },
                        new Product { Name = "Feijão 1kg", Quantity = 1, Price = 8.49m, HasCaugth = true },
                        new Product { Name = "Carne - Patinho", Quantity = 1, Price = 32.97m },
                        new Product { Name = "Leite", Quantity = 12, Price = 5.99m, HasCaugth = true }
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
                    {
                        new Product { Name = "Arroz 5kg", Quantity = 3, Price = 25.90m, HasCaugth = false },
                        new Product { Name = "Feijão 1kg", Quantity = 1, Price = 8.49m, HasCaugth = true },
                        new Product { Name = "Carne - Patinho", Quantity = 1, Price = 32.97m, HasCaugth = true },
                        new Product { Name = "Leite", Quantity = 12, Price = 5.99m, HasCaugth = false }
                    }
                }
            };
        }

        [RelayCommand]
        private void OpenPopupSharePage(ListToBuy listSelected)
        {
            MopupService.Instance.PushAsync(new ListToBuySharePage(listSelected));
        }

    }
}
