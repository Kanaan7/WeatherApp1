using Microsoft.Extensions.Logging;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace WeatherApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            // I set up the MAUI app builder
            var builder = MauiApp.CreateBuilder();

            // I register the main App class and custom fonts
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    // I add OpenSans fonts for styling text
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            // I enable debug logging during development
            builder.Logging.AddDebug();
#endif

            // I build and return the configured app
            return builder.Build();
        }
    }
}
