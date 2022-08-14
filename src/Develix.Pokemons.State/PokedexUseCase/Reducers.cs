namespace Develix.Pokemons.State.PokedexUseCase;

public static class Reducers
{
    [ReducerMethod(typeof(GetPokedexEntryAction))]
    public static PokedexState ReduceGetPokedexEntryAction(PokedexState state)
    {
        return state with { };
    }

    [ReducerMethod(typeof(GetPokemonAction))]
    public static PokedexState ReduceGetPokemonAction(PokedexState state)
    {
        return state with
        {
            LoadingState = state.LoadingState | PokedexStateLoadingFlags.PokemonLoading,
        };
    }

    [ReducerMethod]
    public static PokedexState ReduceGetPokemonResultAction(PokedexState state, GetPokemonResultAction action)
    {
        return state with
        {
            Pokemon = action.Pokemon,
            LoadingState = state.LoadingState & ~PokedexStateLoadingFlags.PokemonLoading,
        };
    }
    [ReducerMethod(typeof(GetPokemonSpeciesAction))]
    public static PokedexState ReduceGetPokemonSpeciesAction(PokedexState state)
    {
        return state with
        {
            LoadingState = state.LoadingState | PokedexStateLoadingFlags.PokemonSpeciesLoading,
        };
    }

    [ReducerMethod]
    public static PokedexState ReduceGetPokemonSpeciesResultAction(PokedexState state, GetPokemonSpeciesResultAction action)
    {
        return state with
        {
            Species = action.Species,
            LoadingState = state.LoadingState & ~PokedexStateLoadingFlags.PokemonSpeciesLoading,
        };
    }
}
