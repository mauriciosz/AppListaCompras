using AppListaCompras.Libraries.Services;
using AppListaCompras.Models;
using AppListaCompras.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppListaCompras.ViewModels
{
    public partial class ProfilePageViewModel : ObservableObject
    {
        [ObservableProperty]
        private User user;

        public ProfilePageViewModel()
        {
            user = new User();
        }

        [RelayCommand]
        private async void  NavigateToAccessCodePage()
        {
            var realm = MongoDBAtlasService.GetMainThreadRealm();
            var userDB = realm.All<User>().FirstOrDefault(a => a.Email == User.Email.Trim().ToLower());



            if (userDB == null)
            {
                // TODO - Gerar AccesCode
                User.AccessCodeTemp = "teste1";
                User.AccessCodeTempCreateAt = DateTime.UtcNow;

                // TODO - Criar a lógica para enviar o e-mail com o código de confirmação

                //TODO -- Salva no Banco
                await realm.WriteAsync(() => {
                    realm.Add(User);
                });
            }
            else
            {
                
                // TODO - Gerar AccesCode
                User.AccessCodeTemp = "teste1";
                User.AccessCodeTempCreateAt = DateTime.UtcNow;

                // TODO - Criar a lógica para enviar o e-mail com o código de confirmação

                await realm.WriteAsync(() => {
                    realm.Add(User, update: true);                
                });
            }

            var parameters = new Dictionary<string, Object>();
            parameters.Add("usuario", User);
            
            await Shell.Current.GoToAsync("//Profile/AccessCode");
        }
    }
}
