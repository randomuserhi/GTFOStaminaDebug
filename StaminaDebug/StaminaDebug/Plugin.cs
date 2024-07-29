using API;
using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;

namespace StaminaDebug.BepInEx;

[BepInPlugin(Module.GUID, Module.Name, Module.Version)]
public class Plugin : BasePlugin {
    public override void Load() {
        APILogger.Log("Plugin is loaded!");
        harmony = new Harmony(Module.GUID);
        harmony.PatchAll();

        APILogger.Log("Debug is " + (ConfigManager.Debug ? "Enabled" : "Disabled"));

        RundownManager.OnExpeditionGameplayStarted += (Action)(() => {
            PlayerStamina.EnableStaminaDebugGraph = true;
        });
    }

    private static Harmony? harmony;
}