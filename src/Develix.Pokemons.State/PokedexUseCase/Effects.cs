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
    public async Task HandleGetPokedexEntryAction(GetPokedexEntryAction action, IDispatcher dispatcher) //  TODO that's not nice...
    {
        var getPokemonAction = new GetPokemonAction(action.PokedexId);
        dispatcher.Dispatch(getPokemonAction);
        var getPokemonSpeciesAction = new GetPokemonSpeciesAction(action.PokedexId);
        dispatcher.Dispatch(getPokemonSpeciesAction);
    }

    [EffectMethod]
    public async Task HandleGetPokemonAction(GetPokemonAction action, IDispatcher dispatcher)
    {
        var pokemon = await pokeApiClient.GetResourceAsync<Pokemon>(action.PokedexId);
        var resultAction = new GetPokemonResultAction(pokemon);
        dispatcher.Dispatch(resultAction);
    }

    [EffectMethod]
    public async Task HandleGetPokemonSpeciesAction(GetPokemonSpeciesAction action, IDispatcher dispatcher)
    {
        var pokemon = await pokeApiClient.GetResourceAsync<PokemonSpecies>(action.PokedexId);
        var resultAction = new GetPokemonSpeciesResultAction(pokemon);
        dispatcher.Dispatch(resultAction);
    }
}
