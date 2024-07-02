using AppListaCompras.Views;

namespace AppListaCompras
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("ListToBuy/ListOfItens", typeof(ListOfItensPage));
        }
    }
}
