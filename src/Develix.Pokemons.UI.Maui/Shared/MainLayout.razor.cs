using System.Reflection;

namespace Develix.Pokemons.UI.Maui.Shared;
public partial class MainLayout
{
    private bool drawerOpen = true;

    private void DrawerToggle() => drawerOpen = !drawerOpen;

    private static string GetVersion() => Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "Unknown version";
}

