using AppListaCompras.Libraries.Services;
using AppListaCompras.Models;
using AppListaCompras.Models.Enums;
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
        private IQueryable<ListToBuy> _listsOflistToBuy; // listas de 'Lista de Compra'

        public ListToBuyViewModel()
        {
            // Esse código foi comentado prq não tem mais uso. Mas ele era uma forma de criar as Listas de Compras e seus Produtos de forma "mocada"
            // Mas agora não tem mais utilidade, pois os dados virão diretamente do que estiver cadastrado no MongoDBAtlas (API/Nuvem)
          /*  ListToBuy = new ObservableCollection<ListToBuy>()
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
                        new Product { Name = "Arroz 5kg", Quantity = 3, QuantityUnitMeasure = UnitMeasure.Un, Price = 25.90m, HasCaugth = true },
                        new Product { Name = "Feijão 1kg", Quantity = 1, QuantityUnitMeasure = UnitMeasure.Un, Price = 8.49m, HasCaugth = true },
                        new Product { Name = "Carne - Alcatra", Quantity = 1, QuantityUnitMeasure = UnitMeasure.Kg,  Price = 32.97m },
                        new Product { Name = "Leite", Quantity = 12, QuantityUnitMeasure = UnitMeasure.Un, Price = 5.99m, HasCaugth = true }
                    }
                },
                new ListToBuy()
                {
                    Name = "Minha Lista 2",
                    Users = new List<User>()
                    {
                        new User { Name = "Mauricio Zaccaro", Email = "neto.mauricio@unemat.br" },
                    },
                    Products = new List<Product>()
                    {
                        new Product { Name = "Arroz 5kg", Quantity = 3, QuantityUnitMeasure = UnitMeasure.Un, Price = 25.90m, HasCaugth = false } 
                        new Product { Name = "Feijão 1kg", Quantity = 1, QuantityUnitMeasure = UnitMeasure.Un, Price = 8.49m, HasCaugth = true },
                        new Product { Name = "Carne - Patinho", Quantity = 1.5m, QuantityUnitMeasure = UnitMeasure.Kg, Price = 32.97m, HasCaugth = true },
                        new Product { Name = "Leite", Quantity = 12, QuantityUnitMeasure = UnitMeasure.Un, Price = 5.99m, HasCaugth = false },
                        new Product { Name = "Cebola Roxa", Quantity = 1.35m, QuantityUnitMeasure = UnitMeasure.Kg, Price = 2.32m, HasCaugth = false } 
                    }
                }
            }; */
        }

        [RelayCommand]
        private async Task OnAppearing()
        {
            await MongoDBAtlasService.Init();
            await MongoDBAtlasService.LoginAsync();

            // TODO .. Carregar os dados
            var realm = MongoDBAtlasService.GetMainThreadRealm();
            ListsOflistToBuy = realm.All<ListToBuy>();
        }

        [RelayCommand]
        private void OpenPopupSharePage(ListToBuy listSelected)
        {
            MopupService.Instance.PushAsync(new ListToBuySharePage(listSelected));
        }

        [RelayCommand]
        private void OpenListOfItensToEdit(ListToBuy listSelected)
        {
            // Cria um dicionário com chave "ListToBuy" e passa no valor a lista selecionada
            var pageParameter = new Dictionary<string, object>
            {
                { "ListToBuy", listSelected}
            };
            Shell.Current.GoToAsync("//ListToBuy/ListOfItens", pageParameter);
        }

        [RelayCommand]
        private void OpenListOfItensToAdd(ListToBuy listSelected)
        {
            Shell.Current.GoToAsync("//ListToBuy/ListOfItens");
        }

        [RelayCommand]
        private async Task DeleteListToBuy(ListToBuy listSelected)
        {
            var realm = MongoDBAtlasService.GetMainThreadRealm();

            var resposta = await App.Current.MainPage.DisplayAlert("Excluir Lista", $"Tem certeza que deseja excluir a Lista '{listSelected.Name}' ?", "Sim", "Não");

            if (resposta)
            {
                var listSelectedCount = listSelected.Products.Count();
                if (listSelectedCount > 0)
                {
                    await App.Current.MainPage.DisplayAlert("Exclusão não permitida!", "Lista possui itens lançados!", "Fechar");
                }
                else
                {
                    await realm.WriteAsync(() =>
                    {
                        realm.Remove(listSelected);
                    });                    
                }
            }
        }

    }
}
