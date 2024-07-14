using AppListaCompras.Views;

namespace AppListaCompras
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            /* Como isso aqui funciona?
             * Bom, na AppShell.xaml tem uma ToBar com duas telas, sendo a ListToBuy e a Profile. Daí quando criamos uma
             * tela que será aberta dentro de alguma dessas, a gente precisa passar a rota (caminho) para ela.
             * No caso abaixo, por exemplo a segunda linha ela ta na tela Profile e vai para a AccessCode
             */
            Routing.RegisterRoute("ListToBuy/ListOfItens", typeof(ListOfItensPage));
            Routing.RegisterRoute("Profile/AccessCode", typeof(AccessCodePage));
        }
    }
}
