using BepInEx;
using HarmonyLib;
using PluginUtilities;

namespace PluginTemplate
{
    [BepInPlugin(Guid, Name, Version)]
    [BepInDependency(SetInjectionFlag.Guid)]
    public class PluginTemplate: BaseUnityPlugin
    {
        // Plugin info
        public const string Author = "<Author>";
        public const string Name = "<Name>";
        public const string Guid = "org.<Author>.plugins.<Name>";
        public const string Version = "0.0.0.0";

        /// <summary>
        /// Method triggered when the plugin loads
        /// </summary>
        public void Awake()
        {
            Logger.LogInfo($"In Awake for {Name}");
            var harmony = new Harmony(Guid);
            harmony.PatchAll();
        }
    }
}
