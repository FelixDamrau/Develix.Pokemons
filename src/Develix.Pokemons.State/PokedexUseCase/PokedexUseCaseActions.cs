using PokeApiNet;

namespace Develix.Pokemons.State.PokedexUseCase;

public record GetPokedexEntryAction(int PokedexId);

public record GetPokemonAction(int PokedexId);

public record GetPokemonResultAction(Pokemon? Pokemon);

public record GetPokemonSpeciesAction(int PokedexId);

public record GetPokemonSpeciesResultAction(PokemonSpecies? Species);
