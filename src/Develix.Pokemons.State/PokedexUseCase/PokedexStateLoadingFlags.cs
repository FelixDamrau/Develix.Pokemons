
namespace Develix.Pokemons.State.PokedexUseCase;

[Flags]
public enum PokedexStateLoadingFlags
{
    Idle = 0x0,
    PokemonLoading = 0x1,
    PokemonSpeciesLoading = 0x2,
}
