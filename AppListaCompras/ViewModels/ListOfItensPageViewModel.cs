﻿using AppListaCompras.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppListaCompras.ViewModels
{
    [QueryProperty(nameof(ListToBuy), "ListToBuy")]
    public partial class ListOfItensPageViewModel : ObservableObject
    {
        private ListToBuy? _listToBuy;
        public ListToBuy? ListToBuy
        {
            get => _listToBuy;
            set => SetProperty(ref _listToBuy, value);  
        }

    }
}