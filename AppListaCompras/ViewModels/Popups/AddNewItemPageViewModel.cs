using AppListaCompras.Libraries.Services;
using AppListaCompras.Libraries.Util;
using AppListaCompras.Libraries.Validations;
using AppListaCompras.Models;
using AppListaCompras.Models.Enums;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MongoDB.Bson;
using Mopups.Services;

namespace AppListaCompras.ViewModels.Popups
{
    public partial class AddNewItemPageViewModel : ObservableObject
    {
        

        [ObservableProperty]
        private Product? productForm;

        [ObservableProperty]
        private String[] unitsMeasure;

        [ObservableProperty]
        private ListToBuy _list;

        [ObservableProperty]
        private string _errorMessage;

        private AddItemValidator _validator;

        private Product? _product;
        public Product? Product 
        {
            get { return _product; }
            set {
                    _product = value;
                    ProductForm = new Product()
                    {
                        Id = value.Id,
                        Name = value.Name,
                        Price = value.Price,
                        Quantity = value.Quantity,
                        QuantityUnitMeasure = value.QuantityUnitMeasure,
                        HasCaugth = value.HasCaugth,
                        CreateAt = value.CreateAt
                    };
                }
        }

        public AddNewItemPageViewModel() // construtor;;
        {
            unitsMeasure =  Enum.GetNames(typeof(UnitMeasure));
            Product = new Product();

            ProductForm = new Product();

            // Não tenho a menor ideia do que foi feito abaixo!!! Só sei que passa o AddItemValidator para o _validator para utilizar no Save
            _validator = App.Current!.MainPage!.Handler!.MauiContext!.Services.GetRequiredService<AddItemValidator>();
        }

        [RelayCommand]
        private void Close()
        {
            MopupService.Instance.PopAsync();
        }

        [RelayCommand]
        private async Task Save()
        {
            ErrorMessage = string.Empty;

            var validateResult = _validator.Validate(ProductForm!); // Chama o AddItemValidator que faz as validações do Product antes de salvar
            if (!validateResult.IsValid)
            {
                ErrorMessage = Validator.ShowErrorMessage(validateResult);
                await App.Current.MainPage.DisplayAlert("Validação!", $"{ErrorMessage}", "Fechar");
                return; // se a validação não for concluída, ai sai fora e não salva nada
            }    

            var realm = MongoDBAtlasService.GetMainThreadRealm();
            await realm.WriteAsync(() => {
                if (Product!.Id == default(ObjectId))
                {
                    ProductForm.Id = ObjectId.GenerateNewId();
                    ProductForm.CreateAt = DateTime.UtcNow;

                    List.Products.Add(ProductForm);  // adiciona o Produto à Lista
                    realm.Add(List, update: true); // Adiciona a Lista ao banco do Realm 
                }
                else 
                {
                    Product.Id = ProductForm.Id;
                    Product.Name = ProductForm.Name;                    
                    Product.Price = ProductForm.Price;                    
                    Product.Quantity = ProductForm.Quantity;                    
                    Product.QuantityUnitMeasure = ProductForm.QuantityUnitMeasure;                    
                    Product.HasCaugth = ProductForm.HasCaugth;
                    Product.CreateAt = ProductForm.CreateAt;

                    //realm.Add(List, update: true);
                }
            });
            await MopupService.Instance.PopAsync();            
        }
    }
}
