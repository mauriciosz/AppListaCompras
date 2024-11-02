using AppListaCompras.Libraries.Validations;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Mopups.Hosting;

namespace AppListaCompras
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureMopups()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Poppins-Light.ttf", "PoppinsLigth"); 
                    fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular"); //OpenSansRegular
                    fonts.AddFont("Poppins-ExtraBold.ttf", "PoppinsExtraBold"); //OpenSansSemibold
                });

            builder.Services.AddScoped<AddItemValidator>(); // Faz a injeção do AddItemValidator

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
