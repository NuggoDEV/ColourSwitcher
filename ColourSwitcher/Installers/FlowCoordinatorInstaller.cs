using ColourSwitcher.UI;
using Zenject;
using ColourSwitcher.Managers;

namespace ColourSwitcher.Installers
{
    internal class FlowCoordinatorInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<ColourSwitcherFlowCoordinator>().FromNewComponentOnNewGameObject().AsSingle();
            Container.Bind<ColourSwitcherViewController>().FromNewComponentAsViewController().AsSingle();
            Container.BindInterfacesTo<MenuButtonManager>().AsSingle();
        }
    }
}
