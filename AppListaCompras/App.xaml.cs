using AppListaCompras.Views;

namespace AppListaCompras
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            /* o VersionTrancking traz algumas funções que verificam se é o primeiro acesso daquele aplicativo ou daquela versão,
               dentre outras funcionalidades. Aqui estou usando o IsFirstLaunchEver verificar se é o primeiro acesso.
               Caso seja, abre a primeira tela de acesso e boas vindas, se não for, ai vai direto para a AppShell que é a página 
               principal da aplicação */
            MainPage = VersionTracking.IsFirstLaunchEver ? new FirstPage() : new AppShell();
        }
    }
}
