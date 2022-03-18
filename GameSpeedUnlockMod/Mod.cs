using DistantWorlds2;
using HarmonyLib;
using JetBrains.Annotations;

namespace GameSpeedUnlockMod;

[PublicAPI]
public class Mod
{
    public Mod(DWGame game)
    {
        Console.WriteLine("GameSpeedUnlockMod Patching");
        var harmony = new Harmony(nameof(GameSpeedUnlockMod));
        harmony.PatchAll();

        foreach (var m in harmony.GetPatchedMethods())
            Console.WriteLine($"GameSpeedUnlockMod Patched {m.Name}");
        Console.WriteLine("GameSpeedUnlockMod Done Patching");
    }
}
