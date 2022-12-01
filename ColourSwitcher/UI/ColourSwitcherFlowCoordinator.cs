using HMUI;
using Zenject;
using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.MenuButtons;
using ColourSwitcher;

namespace ColourSwitcher.UI
{
    public class ColourSwitcherFlowCoordinator : FlowCoordinator
    {
        private MainFlowCoordinator mainFlowCoordinator = null!;
        private ColourSwitcherViewController mainView = null!;

        //[Inject]
        private void Construct(MainFlowCoordinator _mainFlowCoordinator, ColourSwitcherViewController _mainView)
        {
            mainFlowCoordinator = _mainFlowCoordinator;
            mainView = _mainView;
        }

        protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
        {
            SetTitle("Colour Switcher");
            showBackButton = true;

            ProvideInitialViewControllers(mainView);
        }

        protected override void BackButtonWasPressed(ViewController topViewController)
        {
            mainFlowCoordinator.DismissFlowCoordinator(this);
        }
    }
}