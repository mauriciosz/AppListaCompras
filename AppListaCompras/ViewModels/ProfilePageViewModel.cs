﻿using AppListaCompras.Models;
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
           await Shell.Current.GoToAsync("//Profile/AccessCode");
        }
    }
}
