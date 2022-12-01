using System.Runtime.CompilerServices;
using IPA.Config.Stores;
using UnityEngine;

[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace ColourSwitcher
{
    internal class Config
    {
        public static Config Instance { get; set; }

        public static Color bombColour = Color.white;
    }
}
