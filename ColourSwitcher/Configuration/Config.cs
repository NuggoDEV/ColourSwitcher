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

        public Color leftSaberColour = Color.white;
        public Color rightSaberColour = Color.white;
        public Color wallColour = Color.white;
        public Color bombColour = Color.white;

        public bool timedSwitch1Bool = false;
        public bool timedSwitch2Bool = false;
        public bool timedSwitch3Bool = false;
        public bool timedSwitch4Bool = false;

        public float timedSwitch1Time = 0;
        public float timedSwitch2Time = 0;
        public float timedSwitch3Time = 0;
        public float timedSwitch4Time = 0;

        public Color leftSaberColour1 = Color.white;
        public Color rightSaberColour1 = Color.white;
        public Color bombColour1 = Color.white;
        public Color wallColour1 = Color.white;

        public Color leftSaberColour2 = Color.white;
        public Color rightSaberColour2 = Color.white;
        public Color bombColour2 = Color.white;
        public Color wallColour2 = Color.white;

        public Color leftSaberColour3 = Color.white;
        public Color rightSaberColour3 = Color.white;
        public Color bombColour3 = Color.white;
        public Color wallColour3 = Color.white;

        public Color leftSaberColour4 = Color.white;
        public Color rightSaberColour4 = Color.white;
        public Color bombColour4 = Color.white;
        public Color wallColour4 = Color.white;



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
