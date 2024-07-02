using AppListaCompras.Models;
using AppListaCompras.ViewModels.Popups;

//using AppListaCompras.ViewModels.Popups;
using Mopups.Pages;

namespace AppListaCompras.Views.Popups;

public partial class ListToBuySharePage : PopupPage
{
	public ListToBuySharePage(ListToBuy list)
	{
		InitializeComponent();

		var vm = (ListToBuySharePageViewModel)BindingContext;
		vm.List = list;
	}
}