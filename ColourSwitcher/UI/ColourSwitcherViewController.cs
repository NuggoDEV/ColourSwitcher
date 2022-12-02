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

        void ClearBombColour()
        {
            bombColour = BombColour.defaultColour;
            NotifyPropertyChanged("bombColour");
        }


        bool timedSwitch1Bool
        {
            get => config.timedSwitch1Bool; set => config.timedSwitch1Bool = value;
        }
        bool timedSwitch2Bool
        {
            get => config.timedSwitch2Bool; set => config.timedSwitch2Bool = value;
        }
        bool timedSwitch3Bool
        {
            get => config.timedSwitch3Bool; set => config.timedSwitch3Bool = value;
        }
        bool timedSwitch4Bool
        {
            get => config.timedSwitch4Bool; set => config.timedSwitch4Bool = value;
        }

        float timedSwitch1Time
        {
            get => config.timedSwitch1Time; set => config.timedSwitch1Time = value;
        }
        float timedSwitch2Time
        {
            get => config.timedSwitch2Time; set => config.timedSwitch2Time = value;
        }
        float timedSwitch3Time
        {
            get => config.timedSwitch3Time; set => config.timedSwitch3Time = value;
        }
        float timedSwitch4Time
        {
            get => config.timedSwitch4Time; set => config.timedSwitch4Time = value;
        }

        Color leftSaberColour
        {
            get => config.leftSaberColour; set => config.leftSaberColour = value;
        }
        Color rightSaberColour
        {
            get => config.rightSaberColour; set => config.rightSaberColour = value;
        }
        Color wallColour
        {
            get => config.wallColour; set => config.wallColour = value;
        }
        Color bombColour
        {
            get => config.bombColour;
            set => config.bombColour = value.ColorWithAlpha(1);
        }

        Color leftSaberColour1
        {
            get => config.leftSaberColour1; set => config.leftSaberColour1 = value;
        }
        Color rightSaberColour1
        {
            get => config.rightSaberColour1; set => config.rightSaberColour1 = value;
        }
        Color bombColour1
        {
            get => config.bombColour1; set => config.bombColour1 = value;
        }
        Color wallColour1
        {
            get => config.wallColour1; set => config.wallColour1 = value;
        }


        Color leftSaberColour2
        {
            get => config.leftSaberColour2; set => config.leftSaberColour2 = value;
        }
        Color rightSaberColour2
        {
            get => config.rightSaberColour2; set => config.rightSaberColour2 = value;
        }
        Color bombColour2
        {
            get => config.bombColour2; set => config.bombColour2 = value;
        }
        Color wallColour2
        {
            get => config.wallColour2; set => config.wallColour2 = value;
        }


        Color leftSaberColour3
        {
            get => config.leftSaberColour3; set => config.leftSaberColour3 = value;
        }
        Color rightSaberColour3
        {
            get => config.rightSaberColour3; set => config.rightSaberColour3 = value;
        }
        Color bombColour3
        {
            get => config.bombColour3; set => config.bombColour3 = value;
        }
        Color wallColour3
        {
            get => config.wallColour3; set => config.wallColour3 = value;
        }


        Color leftSaberColour4
        {
            get => config.leftSaberColour4; set => config.leftSaberColour4 = value;
        }
        Color rightSaberColour4
        {
            get => config.rightSaberColour4; set => config.rightSaberColour4 = value;
        }
        Color bombColour4
        {
            get => config.bombColour4; set => config.bombColour4 = value;
        }
        Color wallColour4
        {
            get => config.wallColour4; set => config.wallColour4 = value;
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
