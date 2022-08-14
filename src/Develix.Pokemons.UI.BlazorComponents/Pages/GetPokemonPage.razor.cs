using Develix.Pokemons.State.PokedexUseCase;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace Develix.Pokemons.UI.BlazorComponents.Pages;

public partial class GetPokemonPage
{
    private int pokedexId = 1;

    [Inject]
    private IDispatcher Dispatcher { get; set; } = null!;

    [Inject]
    IState<PokedexState> PokedexState { get; set; } = null!;

    private void GetPokemon()
    {
        var action = new GetPokemonAction(pokedexId);
        Dispatcher.Dispatch(action);
    }

    private void KeyPressedInInputField(KeyboardEventArgs e)
    {
        if (e.Key == "Enter" && !GetPokemonDisabled())
            GetPokemon();
    }

    private bool GetPokemonDisabled() => PokedexState.Value.IsLoading;
}
