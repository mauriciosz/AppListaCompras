using AppListaCompras.Libraries.Services;
using AppListaCompras.Libraries.Validations;
using AppListaCompras.Models;
using AppListaCompras.Views.Popups;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MongoDB.Bson;
using Mopups.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppListaCompras.Libraries.Validations;
using AppListaCompras.Libraries.Util;
using System.Diagnostics;
using Realms;
using static Realms.ThreadSafeReference;

namespace AppListaCompras.ViewModels
{
    [QueryProperty(nameof(ListToBuy), "ListToBuy")]
    public partial class ListOfItensPageViewModel : ObservableObject
    {
        private AddItemValidator _validator; 

        private bool _isUpdating; // Variável de controle

        [ObservableProperty]
        private string _errorMessage;

        private ListToBuy? _listToBuy;
        public ListToBuy? ListToBuy
        {
            get => _listToBuy;
            set => SetProperty(ref _listToBuy, value);  
        }

        public ListOfItensPageViewModel()
        {
            ListToBuy = new ListToBuy();

            _validator = App.Current!.MainPage!.Handler!.MauiContext!.Services.GetRequiredService<AddItemValidator>();
        }

        [RelayCommand]
        private async Task SaveListToBuy()
        {
            if (string.IsNullOrWhiteSpace(ListToBuy!.Name)) // se a lista estiver nula, vazia ou com espaços em branco, acaba aqui a função
                return;

            var realm = MongoDBAtlasService.GetMainThreadRealm();

            await realm.WriteAsync(() => 
            { // esse () => {} é uma "ação" que está sendo chamanda

                /* o que esse IF compara?  
                 * Ele está comparando se o Id da ListToBuy é igual ao valor default (padrão) de ObjectId, que normalmente é 0000000....00
                 * Se for, então é prq ele não tem um Id válido ainda e aqui faremos a Adição de uma nova lista, mas se houver algum outro
                 * varlo diferente do default, então é uma lista já existente e será atualizada
                 * */
                if (ListToBuy!.Id == default(ObjectId))
                {
                    ListToBuy.Id = ObjectId.GenerateNewId(); // gera um novo Id e passa esse valor para o Id da ListToBuy
                    ListToBuy.CreateAt = DateTime.UtcNow;

                    realm.Add(ListToBuy);
                }
                else
                {
                    realm.Add(ListToBuy, update: true); // Passa o mesmo Add(), mas dizendo que é para fazer uma atualização.
                }
            
            });

        }

        [RelayCommand]
        private async Task UpdateListoToBuy(Product product)
        {
            if (product == null)
            {
                OnPropertyChanged(nameof(ListToBuy));
            }
            else
            {
                ErrorMessage = string.Empty;

                var validateResult = _validator.Validate(product);
                if (!validateResult.IsValid)
                {
                    ErrorMessage = Validator.ShowErrorMessage(validateResult);
                    await App.Current.MainPage.DisplayAlert("Validação!", $"{ErrorMessage}", "Fechar");

                    var realm = MongoDBAtlasService.GetMainThreadRealm();
                    // faz atualização apenas do HasCangth passando de volta para "desmarcado". Não soube como fazer validação e bloqueio antes
                    // então fiz essa marreta para poder voltar para desmarcado caso a validação falhe.
                    // O ruim é que ele vai mandar pro Banco de Dados 2 vezes   :-(
                    using (var transaction = realm.BeginWrite())
                    {
                        product.HasCaugth = false;
                        transaction.Commit();
                    };                    

                    return;
                }
                else
                {
                    OnPropertyChanged(nameof(ListToBuy));
                }
            }
        }

        [RelayCommand]
        private async Task ExcluirProdutoList(Product product)
        {
            var realm = MongoDBAtlasService.GetMainThreadRealm();

            await realm.WriteAsync(() =>
            {
                realm.Remove(product);                
            });
        }

        [RelayCommand]
        private void BackPage()
        {
            Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        private void OnPopupAddNewItemPage()
        {
            MopupService.Instance.PushAsync(new AddNewItemPage(ListToBuy!));
        }

        [RelayCommand]
        private void OnPopupEditNewItemPage(Product product)
        {
            MopupService.Instance.PushAsync(new AddNewItemPage(ListToBuy!, product));
        }

    }
}
