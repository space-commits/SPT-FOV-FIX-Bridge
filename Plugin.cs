
using BepInEx;
using BepInEx.Bootstrap;
using BepInEx.Configuration;
using Comfort.Common;
using EFT;

namespace Bridge
{

    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {

        private bool checkedForSensMods = false;

        public bool CheckIsReady()
        {
            var gameWorld = Singleton<GameWorld>.Instance;
            var sessionResultPanel = Singleton<SessionResultPanel>.Instance;

            if (gameWorld == null || gameWorld.AllPlayers == null || gameWorld.AllPlayers.Count <= 0 || sessionResultPanel != null)
            {
                return false;
            }
            return true;
        }

        void Update()
        {
            if (CheckIsReady() && !checkedForSensMods) 
            {
                if (Chainloader.PluginInfos.ContainsKey("FOVFix")) 
                {
                    if (Chainloader.PluginInfos.ContainsKey("RealismMod") && Chainloader.PluginInfos.ContainsKey("RecoilStandalone")) 
                    {
                        Logger.LogError("FOV FIX COMPATIBILITY BRIDGE ERROR: REALISM MOD AND RECOIL STANDALONE ARE PRESENT AT THE SAME TIME!");
                    }

                    if (Chainloader.PluginInfos.ContainsKey("RealismMod"))
                    {
                        RealismMod.Plugin.StartingAimSens = FOVFix.Plugin.AimingSens;
                        checkedForSensMods = true;
                    }
                    else if (Chainloader.PluginInfos.ContainsKey("RecoilStandalone")) 
                    {
                        RecoilStandalone.Plugin.StartingAimSens = FOVFix.Plugin.AimingSens;
                        checkedForSensMods = true;
                    }
                    Logger.LogError("FOV FIX COMPATIBILITY BRIDGE ERROR: COULD NOT FIND REALISM MOD OR RECOIL STANDALONE, REMOVE BRIDGE IF NEITHER IS INSTALLED!");
                }
            }

        }
    }
}

