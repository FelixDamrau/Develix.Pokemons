using System.Linq.Expressions;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using PokeApiNet;

namespace Develix.Pokemons.UI.BlazorComponents.Components;

public partial class PokemonCard
{
    private IReadOnlyList<PokemonSpriteInfo> sprites = Array.Empty<PokemonSpriteInfo>();
    private Pokemon? pokemon;
    private MudCarousel<PokemonSpriteInfo>? carousel;

    [Parameter]
    [EditorRequired]
    public Pokemon? Pokemon
    {
        get => pokemon;
        set
        {
            if (pokemon?.Id == value?.Id)
                return;

            sprites = value is not null ? GetSpriteInfos(value.Sprites) : Array.Empty<PokemonSpriteInfo>();
            pokemon = value;
            if (carousel is not null && carousel.SelectedIndex >= sprites.Count)
                carousel.MoveTo(0);
        }
    }

    [EditorRequired]
    [Parameter]
    public PokemonSpecies? Species { get; set; }

    private static string GetPokemonTypeNames(Pokemon pokemon)
    {
        var types = pokemon.Types.Select(t => t.Type.Name);
        return string.Join(", ", types);
    }

    private IReadOnlyList<PokemonSpriteInfo> GetSpriteInfos(PokemonSprites sprites)
    {
        var spriteInfos = new List<PokemonSpriteInfo>();
        if (!string.IsNullOrWhiteSpace(sprites.FrontDefault))
            spriteInfos.Add(PokemonSpriteInfo.Create(() => sprites.FrontDefault, () => sprites.BackDefault));
        if (!string.IsNullOrWhiteSpace(sprites.FrontShiny))
            spriteInfos.Add(PokemonSpriteInfo.Create(() => sprites.FrontShiny, () => sprites.BackShiny));
        if (!string.IsNullOrWhiteSpace(sprites.FrontFemale))
            spriteInfos.Add(PokemonSpriteInfo.Create(() => sprites.FrontFemale, () => sprites.BackFemale));
        if (!string.IsNullOrWhiteSpace(sprites.FrontShinyFemale))
            spriteInfos.Add(PokemonSpriteInfo.Create(() => sprites.FrontShinyFemale, () => sprites.BackShinyFemale));

        return spriteInfos;
    }

    private static string GetPokemonColor(PokemonSpecies species)
    {
        return species.Color.Name switch
        {
            "black" => Colors.Shades.Black,
            "blue" => Colors.Blue.Darken4,
            "gray" => Colors.Grey.Darken1,
            "green" => Colors.Green.Default,
            "pink" => Colors.Pink.Default,
            "purple" => Colors.Purple.Default,
            "red" => Colors.Red.Darken1,
            "white" => Colors.Shades.White,
            "yellow" => Colors.Yellow.Darken1,
            _ => throw new NotSupportedException($"Color '{species.Color.Name}' is not supported yet!"),
        };
    }

    private class PokemonSpriteInfo
    {
        public string FrontName { get; }
        public string FrontImage { get; }
        public string? BackName { get; }
        public string? BackImage { get; }

        private PokemonSpriteInfo(string frontName, string backName, string frontImage, string backImage)
        {
            FrontName = frontName;
            FrontImage = frontImage;
            BackName = backName;
            BackImage = backImage;
        }

        public static PokemonSpriteInfo Create(Expression<Func<string>> front, Expression<Func<string>> back)
        {
            var frontName = ((MemberExpression)front.Body).Member.Name;
            var frontDisplayName = GetDisplayName(frontName);
            var frontImage = front.Compile()();
            var backName = ((MemberExpression)back.Body).Member.Name;
            var backDisplayName = GetDisplayName(backName);
            var backImage = back.Compile()();

            return new(frontDisplayName, backDisplayName, frontImage, backImage);
        }

        private static string GetDisplayName(string name) => Regex.Replace(name, "([A-Z])", " $1", RegexOptions.Compiled).Trim();
    }
}
