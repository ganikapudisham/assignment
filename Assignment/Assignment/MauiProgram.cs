using Assignment.Business;
using Assignment.Business.Impl;
using Assignment.Data;
using Assignment.Data.Impl;
using Matri.ViewModel;
using Microsoft.Extensions.Logging;

namespace Assignment
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<IServiceManager, ServiceManager>();
            builder.Services.AddSingleton<IServiceRepository, ServiceRepository>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
