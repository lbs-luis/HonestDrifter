using BepInEx;
using BepInEx.Logging;
using HonestDrifter.Hooks;

namespace HonestDrifter
{
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
    public sealed class Plugin : BaseUnityPlugin
    {
        public const string PluginGUID = "com.lbsluis.honestdrifter";
        public const string PluginName = "HonestDrifter";
        public const string PluginVersion = "1.0.0";

        internal static ManualLogSource Log { get; private set; }

        private void Awake()
        {
            Log = Logger;
            DrifterHooks.Init();
            Log.LogInfo($"{PluginName} v{PluginVersion} loaded.");
        }
    }
}
