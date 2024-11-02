using AppListaCompras.Models;
using AppListaCompras.ViewModels.Popups;
using Mopups.Pages;

namespace AppListaCompras.Views.Popups;

public partial class AddNewItemPage : PopupPage
{
	public AddNewItemPage(ListToBuy listToBuy)
	{
		InitializeComponent();

		var vm = (AddNewItemPageViewModel)BindingContext;
		vm.List = listToBuy;
	}

    public AddNewItemPage(ListToBuy listToBuy, Product product)
    {
        InitializeComponent();

        var vm = (AddNewItemPageViewModel)BindingContext;
        vm.List = listToBuy;
        vm.Product = product;
    }

}