
using BepInEx;
using BepInEx.Bootstrap;
using BepInEx.Configuration;
using Comfort.Common;
using EFT;

namespace Bridge
{

    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInDependency("FOVFix", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("RecoilStandalone", BepInDependency.DependencyFlags.HardDependency)]
    public class Plugin : BaseUnityPlugin
    {
        void Update()
        {
            RecoilStandalone.Plugin.StartingAimSens = FOVFix.Plugin.AimingSens;
        }
    }
}

