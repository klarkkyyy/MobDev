using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using ToDoApplication.Models;

namespace ToDoApplication;

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

#if DEBUG
        builder.Logging.AddDebug();
#endif

        // Ensure a consistent minimum log level across environments
        builder.Logging.SetMinimumLevel(LogLevel.Information);

        // Register a shared tasks collection so pages/viewmodels can be resolved from DI
        // (allows moving away from constructor parameter passing in the future)
        builder.Services.AddSingleton<ObservableCollection<ToDoClass>>(sp => new ObservableCollection<ToDoClass>());

        return builder.Build();
    }
}