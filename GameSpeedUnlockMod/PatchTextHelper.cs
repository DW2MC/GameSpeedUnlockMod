using System.Diagnostics.CodeAnalysis;
using System.Text;
using DistantWorlds.Types;
using HarmonyLib;
using JetBrains.Annotations;

namespace GameSpeedUnlockMod;

[PublicAPI]
[HarmonyPatch(typeof(TextHelper))]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class PatchTextHelper
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(TextHelper.ResolveGameSpeedDescription))]
    public static bool ResolveGameSpeedDescription(float gameSpeed, out string __result)
    {
        static string ApproximateFraction(float value)
        {
            const float EPSILON = .00005f;
            var n = 1;
            var d = 1;
            var f = 1d;
            while (Math.Abs(f - value) > EPSILON)
            {
                if (f < value)
                    n++;
                else
                    n = (int)Math.Round(value * ++d);
                f = n / (float)d;
            }
            return n == 1
                ? d switch
                {
                    2 => "½",
                    4 => "¼",
                    _ => $"1/{d}"
                }
                : $"{n}/{d}";
        }

        __result = gameSpeed switch
        {
            1f => "",
            < 1f => $" (×{ApproximateFraction(gameSpeed)})",
            _ => $" (×{gameSpeed:F0})"
        };

        return false;
    }
}
