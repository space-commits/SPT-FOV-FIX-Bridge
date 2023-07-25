
using BepInEx;
using BepInEx.Bootstrap;
using BepInEx.Configuration;
using Comfort.Common;
using EFT;

namespace Bridge
{

    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInDependency("FOVFix", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("RealismMod", BepInDependency.DependencyFlags.HardDependency)]
    public class Plugin : BaseUnityPlugin
    {

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
            RealismMod.Plugin.StartingAimSens = FOVFix.Plugin.AimingSens;
            RealismMod.Plugin.IsInDeadZone = FOVFix.FreeAimController.IsInDeadZone;
            RealismMod.Plugin.DeadZoneReduceSens = !FOVFix.Plugin.FreeAimBlocksRotation.Value;
            RealismMod.Plugin.DeadZoneSensAmount = FOVFix.Plugin.FreeAimRotationReduction.Value;
            RealismMod.Plugin.DeadZonePanCamUp = FOVFix.FreeAimController.PanCamUp;
            RealismMod.Plugin.DeadZonePanCamDown = FOVFix.FreeAimController.PanCamDown;
            RealismMod.Plugin.DeadZonePanCamLeft = FOVFix.FreeAimController.PanCamLeft;
            RealismMod.Plugin.DeadZonePanCamRight = FOVFix.FreeAimController.PanCamRight;
            RealismMod.Plugin.FreeAimEnabled = FOVFix.Plugin.EnableFreeAim.Value;
            RealismMod.Plugin.CamRotationMulti = FOVFix.Plugin.CamRotationMulti.Value;
        }
    }
}

