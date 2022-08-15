using PokeApiNet;

namespace Develix.Pokemons.State.PokedexUseCase;

public class Effects
{
    private readonly PokeApiClient pokeApiClient;
    private readonly ISnackbarService snackbarService;

    public Effects(PokeApiClient pokeApiClient, ISnackbarService snackbarService)
    {
        this.pokeApiClient = pokeApiClient;
        this.snackbarService = snackbarService;
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
        var pokemon = await GetResourceAsync<Pokemon>(action.PokedexId);
        var resultAction = new GetPokemonResultAction(pokemon);
        dispatcher.Dispatch(resultAction);
    }

    [EffectMethod]
    public async Task HandleGetPokemonSpeciesAction(GetPokemonSpeciesAction action, IDispatcher dispatcher)
    {
        var pokemon = await GetResourceAsync<PokemonSpecies>(action.PokedexId);
        var resultAction = new GetPokemonSpeciesResultAction(pokemon);
        dispatcher.Dispatch(resultAction);
    }

    private async Task<T?> GetResourceAsync<T>(int id)
    where T : ResourceBase
    {
        try
        {
            return await pokeApiClient.GetResourceAsync<T>(id);
        }
        catch (Exception e)
        {
            snackbarService.Add($"Loading resource of type {typeof(T).Name} failed.", e.Message);
            return default;
        }
    }
}
