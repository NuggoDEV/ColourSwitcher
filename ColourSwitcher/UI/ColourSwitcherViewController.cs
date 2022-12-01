using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.ViewControllers;
using System;
using ColourSwitcher;
using IPA.Loader;
using Zenject;
using SiraUtil.Zenject;
using HMUI;
using UnityEngine;

namespace ColourSwitcher.UI
{
    [HotReload(RelativePathToLayout = @"settings.bsml")]
    [ViewDefinition("ColourSwitcher.UI.settings.bsml")]
    internal class ColourSwitcherViewController : BSMLAutomaticViewController
    {
        Config config = Config.Instance;

        [UIComponent("version-text")]
        private readonly CurvedTextMeshPro _versionText = null!;

        [UIValue("version-text-value")]
        private string VersionText => "Colour Switcher v0.0.1 by Nuggo";

        [UIValue("bombColour")]
        public Color bombColour
        {
            get => Config.bombColour;
            set
            {
                Config.bombColour = value;
                NotifyPropertyChanged();
            }
        }


        [UIAction("#post-parse")]
        internal void PostParse()
        {
            // Code to run after BSML finishes
        }
    }
}
