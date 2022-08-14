using PokeApiNet;

namespace Develix.Pokemons.State.PokedexUseCase;

[FeatureState]
public record PokedexState
{
    public PokedexStateLoadingFlags LoadingState { get; init; }
    public Pokemon? Pokemon { get; init; }
    public PokemonSpecies? Species { get; init; }

    public bool IsLoading() => LoadingState != PokedexStateLoadingFlags.Idle;
}
