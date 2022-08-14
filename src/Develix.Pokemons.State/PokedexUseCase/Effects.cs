using PokeApiNet;

namespace Develix.Pokemons.State.PokedexUseCase;

public class Effects
{
    private readonly PokeApiClient pokeApiClient;

    public Effects(PokeApiClient pokeApiClient)
    {
        this.pokeApiClient = pokeApiClient;
    }

    [EffectMethod]
    public async Task HandleGetPokemonAction(GetPokemonAction action, IDispatcher dispatcher)
    {
        var pokemon = await pokeApiClient.GetResourceAsync<Pokemon>(action.PokedexId);
        var resultAction = new GetPokemonResultAction(pokemon);
        dispatcher.Dispatch(resultAction);
    }
}
