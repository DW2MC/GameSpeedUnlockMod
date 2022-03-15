using System.Diagnostics.CodeAnalysis;
using DistantWorlds2;
using HarmonyLib;
using JetBrains.Annotations;

namespace GameSpeedUnlockMod;

[PublicAPI]
[HarmonyPatch(typeof(ScaledRenderer))]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class PatchScaledRenderer
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(ScaledRenderer.GameSpeedFaster))]
    public static bool GameSpeedFaster(ref DWGame ____Game)
    {
        ____Game.ChangeGameSpeed(Math.Max(0.125f, Math.Min(____Game.GetGameSpeed() * 2f, 32f)));
        return false;
    }

    [HarmonyPrefix]
    [HarmonyPatch(nameof(ScaledRenderer.GameSpeedSlower))]
    public static bool GameSpeedSlower(ref DWGame ____Game)
    {
        ____Game.ChangeGameSpeed(Math.Max(0.125f, Math.Min(____Game.GetGameSpeed() * .5f, 32f)));
        return false;
    }
}