using HarmonyLib;

namespace HelloTalespire.Patches
{
    [HarmonyPatch(typeof(HeightHidePlane), "Awake")]
    internal sealed class GetHeightHidePlanePatch
    {
        internal static HeightHidePlane myExposedHidePlane;

        // internal const string patchName = "Assembly Bouncyrock.TaleSpire.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null";

        static void Postfix(ref HeightHidePlane __instance)
        {
            myExposedHidePlane = __instance;
        }
    }
}
