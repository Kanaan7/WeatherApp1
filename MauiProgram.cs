using Microsoft.Extensions.Logging; // Importing the Microsoft.Extensions.Logging namespace for logging.

namespace WeatherApp1; // Defining a namespace called "WeatherApp1".

public static class MauiProgram // Defining a public static class called "MauiProgram".
{
    public static MauiApp CreateMauiApp() // Defining a public static method that returns a MauiApp object called "CreateMauiApp".
    {
        var builder = MauiApp.CreateBuilder(); // Instantiating a new MauiAppBuilder object and assigning it to the "builder" variable.

        builder
            .UseMauiApp<App>() // Configuring the builder to use the "App" class as the main application.
            .ConfigureFonts(fonts => // Configuring the builder to add custom fonts to the application.
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"); // Adding a font file named "OpenSans-Regular.ttf" with an alias of "OpenSansRegular".
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold"); // Adding a font file named "OpenSans-Semibold.ttf" with an alias of "OpenSansSemibold".
            });

#if DEBUG
        builder.Logging.AddDebug(); // Adding the logging provider for debugging purposes.
#endif

        return builder.Build(); // Building and returning the MauiApp object.
    }
}
