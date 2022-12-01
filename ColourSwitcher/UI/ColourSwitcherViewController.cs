using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.ViewControllers;
using System;
using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.MenuButtons;
using BeatSaberMarkupLanguage.ViewControllers;
using HMUI;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using ColourSwitcher.HarmonyPatches;
using UnityEngine;

namespace ColourSwitcher.UI
{
    class CSFlowCoordinator : FlowCoordinator
    {
        View view = null;

        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
        {
            if (firstActivation)
            {
                SetTitle("Colour Switcher");
                showBackButton = true;

                if (view == null)
                {
                    view = BeatSaberUI.CreateViewController<View>();
                }

                ProvideInitialViewControllers(view);
            }
        }

        protected override void BackButtonWasPressed(ViewController topViewController)
        {
            BeatSaberUI.MainFlowCoordinator.DismissFlowCoordinator(this, null, ViewController.AnimationDirection.Horizontal);
            Config.Instance.Changed();
        }

        public void ShowFlow()
        {
            var _parentFlow = BeatSaberUI.MainFlowCoordinator.YoungestChildFlowCoordinatorOrSelf();

            BeatSaberUI.PresentFlowCoordinator(_parentFlow, this);
        }

        static CSFlowCoordinator flow = null;

        static MenuButton menuButton;

        public static void Initialize()
        {
            MenuButtons.instance.RegisterButton(menuButton ??= new MenuButton("Colour Switcher", "a", () =>
            {
                if (flow == null)
                    flow = BeatSaberUI.CreateFlowCoordinator<CSFlowCoordinator>();

                flow.ShowFlow();

            }, true));
        }

        public static void DeInit()
        {
            if (menuButton != null)
            {
                MenuButtons.instance.UnregisterButton(menuButton);
            }
        }
    }

    [HotReload(RelativePathToLayout = @"./settings.bsml")]
    [ViewDefinition("ColourSwitcher.UI.settings.bsml")]
    class View : BSMLAutomaticViewController
    {
        Config config = Config.Instance;

        static bool isAprilFirst = (DateTime.Now.Month == 4) && (DateTime.Now.Day == 1);
        static bool __true = true;

        void ClearBombColour()
        {
            bombColour = BombColour.defaultColour;
            NotifyPropertyChanged("bombColour");
        }
        Color bombColour
        {
            get => config.bombColour;
            set => config.bombColour = value.ColorWithAlpha(1);
        }


        public static class BsmlWrapper
        {
            static readonly bool hasBsml = IPA.Loader.PluginManager.GetPluginFromId("BeatSaberMarkupLanguage") != null;

            public static void EnableUI()
            {
                void wrap() => CSFlowCoordinator.Initialize();

                if (hasBsml)
                    wrap();
            }
            public static void DisableUI()
            {
                void wrap() => CSFlowCoordinator.DeInit();

                if (hasBsml)
                    wrap();
            }
        }
    }
}
