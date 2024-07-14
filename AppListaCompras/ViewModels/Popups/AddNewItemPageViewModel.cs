using AppListaCompras.Models;
using AppListaCompras.Models.Enums;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mopups.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppListaCompras.ViewModels.Popups
{
    public partial class AddNewItemPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private Product? product;

        [ObservableProperty]
        private String[] unitsMeasure;

        public AddNewItemPageViewModel()
        {
            unitsMeasure =  Enum.GetNames(typeof(UnitMeasure));
        }

        [RelayCommand]
        private void Close()
        {
            MopupService.Instance.PopAsync();
        }

        [RelayCommand]
        private void Save()
        { 
            
        }

    }
}
