using IPA.Config.Stores;
using System;
using System.Runtime.CompilerServices;
using ColourSwitcher.HarmonyPatches;
using UnityEngine;


[assembly: InternalsVisibleTo(GeneratedStore.AssemblyVisibilityTarget)]
namespace ColourSwitcher
{
    internal class Config
    {
        public static Config Instance { get; set; }

        public Color bombColour = Color.white;



        public virtual void Changed() => ApplyValues();

        public void ApplyValues()
        {
            if (!Plugin.enabled)
                return;

            if (bombColour == Color.black)
                bombColour = BombColour.defaultColour;
        }
    }
}
