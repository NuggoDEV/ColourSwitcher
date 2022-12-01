using HarmonyLib;
using IPA;
using IPA.Config.Stores;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using ColourSwitcher.HarmonyPatches;
using ColourSwitcher.UI;
using UnityEngine.SceneManagement;
using IPALogger = IPA.Logging.Logger;
using static ColourSwitcher.UI.View;

namespace ColourSwitcher
{

    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        internal static IPALogger Log { get; private set; }

        internal static bool enabled { get; private set; } = true;

        public static Harmony harmony;

        [Init]
        /// <summary>
        /// Called when the plugin is first loaded by IPA (either when the game starts or when the plugin is enabled if it starts disabled).
        /// [Init] methods that use a Constructor or called before regular methods like InitWithConfig.
        /// Only use [Init] with one Constructor.
        /// </summary>Console.WriteLine
        public void Init(IPA.Config.Config conf, IPALogger logger)
        {
            Instance = this;
            Log = logger;

            Config.Instance = conf.Generated<Config>();

            harmony = new Harmony("NuggoDEV.ColourSwitcher");
        }

        [OnEnable]
        public void OnEnable()
        {
            enabled = true;
            Config.Instance.ApplyValues();

            BsmlWrapper.EnableUI();
        }

        /// <summary>
        /// Called when the plugin is disabled and on Beat Saber quit. It is important to clean up any Harmony patches, GameObjects, and Monobehaviours here.
        /// The game should be left in a state as if the plugin was never started.
        /// Methods marked [OnDisable] must return void or Task.
        /// </summary>
        [OnDisable]
        public void OnDisable()
        {
            enabled = false;

            harmony.UnpatchSelf();
            BsmlWrapper.DisableUI();
        }
    }
}