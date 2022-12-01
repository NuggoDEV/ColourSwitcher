using IPA;
using ColourSwitcher.Installers;
using IPALogger = IPA.Logging.Logger;
using IPA.Config;
using IPA.Config.Stores;
using SiraUtil.Zenject;

namespace ColourSwitcher
{
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        internal static IPALogger Log { get; private set; }

        [Init]
        public void Init(IPALogger logger, Zenjector zenject, IPA.Config.Config conf)
        {
            Instance = this;
            Log = logger;
            Log.Info("ColourSwitcher initialized.");
            Config.Instance = conf.Generated<Config>();

            zenject.Install<FlowCoordinatorInstaller>(Location.Menu);
        }
    }
}
