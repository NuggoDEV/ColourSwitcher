using HarmonyLib;
using IPA.Utilities;
using System;
using System.Reflection;
using ColourSwitcher.Util;
using UnityEngine;

namespace ColourSwitcher.HarmonyPatches
{
    [HarmonyPatch]
    static class BombColour
    {
        internal static readonly Color defaultColour = Color.black.ColorWithAlpha(0);

        static readonly int _SimpleColour = Shader.PropertyToID("_SimpleColour");

        static readonly FieldAccessor<ConditionalMaterialSwitcher, Material>.Accessor BombNoteController_material0
            = FieldAccessor<ConditionalMaterialSwitcher, Material>.GetAccessor("_material0");

        static readonly FieldAccessor<ConditionalMaterialSwitcher, Material>.Accessor BombNoteController_material1
            = FieldAccessor<ConditionalMaterialSwitcher, Material>.GetAccessor("_material1");

        static Color? basegameBombaColour0 = null;
        static Color? basegameBombaColour1 = null;

        [HarmonyPriority(int.MaxValue)]
        static void Postfix(BombNoteController ____bombNotePrefab)
        {
            var cms = ____bombNotePrefab
                .GetComponentInChildren<ConditionalMaterialSwitcher>();

            if (cms == null)
                return;

            basegameBombaColour0 ??= BombNoteController_material0(ref cms)?.GetColor(_SimpleColour);
            basegameBombaColour1 ??= BombNoteController_material1(ref cms)?.GetColor(_SimpleColour);

            var isDefaultColor = Config.Instance.bombColour == defaultColour;

            BombNoteController_material0(ref cms)?.SetColor(_SimpleColour, isDefaultColor ? (basegameBombaColour0 ?? default) : Config.Instance.bombColour);
            BombNoteController_material1(ref cms)?.SetColor(_SimpleColour, isDefaultColor ? (basegameBombaColour1 ?? default) : Config.Instance.bombColour);
        }

        static MethodBase TargetMethod() => Resolver.GetMethod(nameof(BeatmapObjectsInstaller), "InstallBindings");
    }
}
