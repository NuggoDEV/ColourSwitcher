using BeatSaberMarkupLanguage.MenuButtons;
using BeatSaberMarkupLanguage;
using System;
using ColourSwitcher.UI;
using Zenject;

namespace ColourSwitcher.Managers
{
    internal class MenuButtonManager : /*IInitializable,*/ IDisposable
    {
        private readonly MenuButton menuButton;
        private readonly MainFlowCoordinator mainFlowCoordinator;
        private readonly ColourSwitcherFlowCoordinator colourSwitcherFlowCoordinator;

        public MenuButtonManager(MainFlowCoordinator _mainFlowCoordinator, ColourSwitcherFlowCoordinator _bAFC)
        {
            menuButton = new MenuButton("Colour Switcher", "Idk man", MenuButtonClicked);
            mainFlowCoordinator = _mainFlowCoordinator;
            colourSwitcherFlowCoordinator = _bAFC;
        }

        public void Initialize()
        {
            MenuButtons.instance.RegisterButton(menuButton);
        }

        public void Dispose()
        {
            if (MenuButtons.IsSingletonAvailable)
                MenuButtons.instance.UnregisterButton(menuButton);
        }

        private void MenuButtonClicked()
        {
            mainFlowCoordinator.PresentFlowCoordinator(colourSwitcherFlowCoordinator);
        }
    }
}