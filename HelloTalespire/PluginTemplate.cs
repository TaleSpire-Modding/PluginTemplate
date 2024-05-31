using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using LordAshes;
using ModdingTales;
using Newtonsoft.Json;
using PluginUtilities;
using System.Collections.Generic;
using UnityEngine;

namespace HelloTaleSpire
{
    [BepInPlugin(Guid, Name, Version)]
    [BepInDependency(SetInjectionFlag.Guid)]
    [BepInDependency(LordAshes.AssetDataPlugin.Guid)]
    [BepInDependency(LordAshes.FileAccessPlugin.Guid)]
    public sealed class PluginTemplate: BaseUnityPlugin
    {
        // Plugin info
        public const string Author = "HolloFox";
        public const string Name = "Hello TaleSpire";
        public const string Guid = "org.HF.plugins.HelloSpire";
        public const string Version = "0.0.0.0";

        internal static Harmony harmony;

        internal static ConfigEntry<ModdingUtils.LogLevel> _logLevel { get; set; }
        internal static ModdingUtils.LogLevel LogLevel => _logLevel.Value == ModdingUtils.LogLevel.Inherited ? ModdingUtils.LogLevelConfig.Value : _logLevel.Value;
        internal static ManualLogSource _logger;

        private static ConfigEntry<string> KeyboardShortcut { get; set; }

        private static Dictionary<KeyboardShortcut, float> keyValuePairs = new Dictionary<KeyboardShortcut, float>();

        public static void add(KeyboardShortcut shortcut, float height)
        {
            keyValuePairs.Add(shortcut, height);
            // KeyboardShortcut.Value = JsonConvert.SerializeObject(keyValuePairs);
        }

        /// <summary>
        /// Method triggered when the plugin loads
        /// </summary>
        public void Awake()
        {
            _logger = Logger;
            DoConfig(Config);
            DoPatching();

            if (LogLevel > ModdingUtils.LogLevel.None) _logger.LogInfo($"{Name} is Active.");
            ModdingUtils.Initialize(this, Logger, "HolloFoxes'");

            AssetDataPlugin.Subscribe($"{Guid}.SetHeight", myNetCode);
        }

        private static void myNetCode(AssetDataPlugin.DatumChange changes)
        {
            string newHeight = (string) changes.value;

            HelloTalespire.Patches.GetHeightHidePlanePatch.myExposedHidePlane.SetHeight(float.Parse(newHeight));
        }

        public static void DoPatching()
        {
            harmony = new Harmony(Guid);
            harmony.PatchAll();
            if (LogLevel > ModdingUtils.LogLevel.None) _logger.LogInfo($"{Name}: Patched.");
        }

        public static void DoConfig(ConfigFile Config)
        {
            _logLevel = Config.Bind("Logging", "Level", ModdingUtils.LogLevel.Low);
            if (LogLevel > ModdingUtils.LogLevel.None) _logger.LogInfo($"{Name}: Config Bound.");

            KeyboardShortcut = Config.Bind("Hotkeys", "My new config", JsonConvert.SerializeObject(new Dictionary<KeyboardShortcut, float>()));

            keyValuePairs = new Dictionary<KeyboardShortcut, float>();

            add(new KeyboardShortcut(KeyCode.F1), 10f);
        }

        public void Update()
        {
            foreach( var keyValuePair in keyValuePairs)
            {
                if (keyValuePair.Key.IsUp())
                {
                    AssetDataPlugin.SendInfo($"{Guid}.SetHeight",keyValuePair.Value.ToString());
                }
            }
        }
    }
}
