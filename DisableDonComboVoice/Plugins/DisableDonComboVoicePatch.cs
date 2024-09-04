using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisableDonComboVoice.Plugins
{
    internal class DisableDonComboVoicePatch
    {
        [HarmonyPatch(typeof(EnsoSound))]
        [HarmonyPatch(nameof(EnsoSound.KeyOnGameDonMekaVoice))]
        [HarmonyPatch(MethodType.Normal)]
        [HarmonyPrefix]
        public static bool EnsoSound_KeyOnGameDonMekaVoice_Prefix(EnsoSound __instance, string toneName)
        {
            Plugin.Log.LogInfo("");
            Plugin.Log.LogInfo("EnsoSound_KeyOnGameDonMekaVoice_Prefix");

            // removes the 50combo, 100combo, xxcombo voice
            // doesn't remove fullcombo voice
            if (toneName.Contains("0combo"))
            {
                return false;
            }

            return true;
        }
    }
}
