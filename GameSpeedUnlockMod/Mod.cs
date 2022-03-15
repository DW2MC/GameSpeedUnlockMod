using DistantWorlds2;
using HarmonyLib;
using JetBrains.Annotations;

namespace GameSpeedUnlockMod;

[PublicAPI]
public class Mod
{
    public Mod(DWGame game)
        => new Harmony(nameof(GameSpeedUnlockMod)).PatchAll();
}
