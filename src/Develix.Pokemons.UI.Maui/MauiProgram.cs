using Develix.Pokemons.State.PokedexUseCase;
using Fluxor;
using MudBlazor.Services;
using PokeApiNet;

namespace Develix.Pokemons.UI.Maui;

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
            });

        builder.Services.AddFluxor(o => o.ScanAssemblies(typeof(PokedexState).Assembly));
        builder.Services.AddMudServices();
        builder.Services.AddMauiBlazorWebView();
#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
#endif

        builder.Services.AddScoped<PokeApiClient>();

        return builder.Build();
    }
}
