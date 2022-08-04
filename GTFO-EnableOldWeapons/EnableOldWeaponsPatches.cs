using GameData;
using Gear;
using HarmonyLib;

namespace EnableOldWeapons
{
    [HarmonyPatch]
    public class EnableOldWeaponsPatches
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(GearManager), nameof(GearManager.LoadOfflineGearDatas))]
        private static void OnGearEnableCheck(ref GearManager __instance)
        {
            PlayerOfflineGearDataBlock[] allBlocks = GameDataBlockBase<PlayerOfflineGearDataBlock>.Wrapper.Blocks.ToArray();
            var ids = Enum.GetValues(typeof(OldWeaponIds)).Cast<uint>().ToList();

            foreach (var gear in allBlocks)
            {
                if (ids.Contains(gear.persistentID) && !gear.internalEnabled)
                {
                    EnableOldWeaponsCore.log.LogInfo($"Enabling {gear.name}");
                    gear.internalEnabled = true;
                }
            }
        }
        
    }
}