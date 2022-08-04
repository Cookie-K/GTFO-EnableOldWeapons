using BepInEx;
using BepInEx.IL2CPP;
using BepInEx.Logging;
using HarmonyLib;
using Il2CppInterop.Runtime.Injection;

namespace EnableOldWeapons
{
    [BepInPlugin(GUID, MODNAME, VERSION)]
    [BepInProcess("GTFO.exe")]
    public class EnableOldWeaponsCore : BasePlugin
    {
        public const string
            NAME = "Enable Old Weapons Plugin",
            MODNAME = "EnableOldWeapons",
            AUTHOR = "Cookie_K",
            GUID = "com." + AUTHOR + "." + MODNAME,
            VERSION = "1.0.0";

        public static ManualLogSource log;
        
        private Harmony HarmonyPatches { get; set; }


        public override void Load()
        {
            log = Log;
            HarmonyPatches = new Harmony(GUID);
            HarmonyPatches.PatchAll();
        }
    }
}