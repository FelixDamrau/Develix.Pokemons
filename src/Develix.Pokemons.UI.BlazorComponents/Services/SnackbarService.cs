using Develix.Pokemons.State;
using MudBlazor;

namespace Develix.Pokemons.UI.BlazorComponents.Services;

public class SnackbarService : ISnackbarService
{
    private readonly ISnackbar snackbar;

    public SnackbarService(ISnackbar snackbar)
    {
        this.snackbar = snackbar;
    }

    public void Add(string message, string detail)
    {
        var snackbarMessage =
            $"""
            <b>{message}</b><br />
            <div style="font-size: 0.8em">{detail}</div>
            """;
        snackbar.Add(snackbarMessage, Severity.Error);
    }
}
