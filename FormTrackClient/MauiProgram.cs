using FormTrackClient.Api;
using FormTrackClient.ViewModels;
using FormTrackClient.Views;

namespace FormTrackClient;

public static class MauiProgram
{
    public static string BearerToken { get; set; }
    public static string UserName { get; set; }
    public static DateTime TokenExpireDate { get; set; }
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Montserrat-Regular.ttf", "Montserrat");
                fonts.AddFont("Montserrat-Bold.ttf", "MontserratBold");
                fonts.AddFont("Montserrat-SemiBold.ttf", "MontserratSemiBold");
            });
        builder.Services.AddTransient<MainPageVM>();
        builder.Services.AddTransient<RegisterPageVM>();
        builder.Services.AddTransient<HomePageVM>();

        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<RegisterPage>();
        builder.Services.AddTransient<HomePage>();

        return builder.Build();
    }
}