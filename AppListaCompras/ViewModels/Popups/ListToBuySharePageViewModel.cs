using AppListaCompras.Models;
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
    public partial class ListToBuySharePageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ListToBuy _list = new ListToBuy() { /* Users = new List<User>() */ };
        //private ListToBuySharePageViewModel? _list;

        [RelayCommand]
        private void Close()
        { 
            MopupService.Instance.PopAsync();
        }
    }
}
