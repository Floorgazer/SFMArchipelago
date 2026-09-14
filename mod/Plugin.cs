using System.IO;
using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using SFMArchipelago.Archipelago;
using SFMArchipelago.Utils;

namespace SFMArchipelago;

[BepInPlugin(PluginGUID, PluginName, PluginVersion)]
public class Plugin : BasePlugin
{
    public const string PluginGUID = "com.floorgazer.SFMArchipelago";
    public const string PluginName = "SFMArchipelago";
    public const string PluginVersion = "0.1.0";

    public const string ModDisplayInfo = $"{PluginName} v{PluginVersion}";
    private const string APDisplayInfo = $"Archipelago v{ArchipelagoClient.APVersion}";
    public static ManualLogSource BepinLogger;
    public static ArchipelagoClient ArchipelagoClient;

    public static bool LoadedInSlot = false;
    public static bool NewGame = false;
    public static ItemManager ItemManager;
    public static MessageManager MessageManager;

    public override void Load()
    {
        // Plugin startup logic
        BepinLogger = base.Log;

        SFMArchipelago.ItemManager.CreateInstance(this);
        SFMArchipelago.MessageManager.CreateInstance(this);

        ArchipelagoClient = new ArchipelagoClient();

        using StreamReader reader = new StreamReader("slot.txt");
        ArchipelagoClient.ServerData.Uri = reader.ReadLine();
        ArchipelagoClient.ServerData.SlotName = reader.ReadLine();
        ArchipelagoClient.ServerData.Password = reader.ReadLine();
        reader.Close();

        SFMArchipelago.ArchipelagoOverlay.CreateInstance(this);

        ArchipelagoConsole.LogMessage($"{ModDisplayInfo} loaded! Wiggly!");
    }

    public static void OnEnable()
    {
        ItemManager.enabled = true;
    }
}
