using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;
using PluginUtilities;
using System.Linq;
using UnityEngine;

namespace HelloTaleSpire
{
    [BepInPlugin(Guid, Name, Version)]
    [BepInDependency(SetInjectionFlag.Guid)]
    public class PluginTemplate: BaseUnityPlugin
    {
        // Plugin info
        public const string Author = "HolloFox";
        public const string Name = "Hello TaleSpire";
        public const string Guid = "org.HF.plugins.HelloSpire";
        public const string Version = "0.0.0.0";

        private ConfigEntry<KeyboardShortcut> KeyboardShortcut { get; set; }

        /// <summary>
        /// Method triggered when the plugin loads
        /// </summary>
        public void Awake()
        {
            Logger.LogInfo($"In Awake for {Name}");
            Debug.Log("In awake");

            KeyboardShortcut = Config.Bind("Hotkeys", "My new config", new KeyboardShortcut(KeyCode.F1));

            // var harmony = new Harmony(Guid);
            // harmony.PatchAll();
        }

        public void Update()
        {

            if (KeyboardShortcut.Value.IsUp())
            {
                Logger.LogInfo($"Key Pressed");
            }
        }
    }
}
