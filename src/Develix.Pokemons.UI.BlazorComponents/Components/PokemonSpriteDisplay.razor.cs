using Microsoft.AspNetCore.Components;

namespace Develix.Pokemons.UI.BlazorComponents.Components;

public partial class PokemonSpriteDisplay
{
    [Parameter]
    [EditorRequired]
    public string FrontName { get; set; } = null!;

    [Parameter]
    [EditorRequired]
    public string FrontImage { get; set; } = null!;

    [Parameter]
    public string? BackName { get; set; }

    [Parameter]
    public string? BackImage { get; set; }
}
