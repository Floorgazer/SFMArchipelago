using System.Collections.Generic;
using System.Linq;
using BepInEx;
using SFMArchipelago.Archipelago;
using HarmonyLib;
using UnityEngine;

namespace SFMArchipelago.Utils;

public class ArchipelagoConsole : MonoBehaviour
{
    private static List<string> logLines = new();

    private static float lastUpdateTime = Time.time;
    private const int MaxLogLines = 80;

    private Plugin loader;

    public static void CreateInstance(Plugin loader)
    {
        ArchipelagoConsole console = loader.AddComponent<ArchipelagoConsole>();
        console.loader = loader;
        Object.DontDestroyOnLoad(console.gameObject);
        console.hideFlags |= HideFlags.HideAndDontSave;

        Harmony harmony = new Harmony("com.floorgazer.SFMArchipelago");
        harmony.PatchAll();
    }

    public void Awake()
    {
        LogMessage("Testing testing 1 2 3");
    }

    public static void LogMessage(string message)
    {
        if (message.IsNullOrWhiteSpace()) return;

        if (logLines.Count == MaxLogLines)
        {
            logLines.RemoveAt(0);
        }
        logLines.Add(message);
        Plugin.BepinLogger.LogMessage(message);
        lastUpdateTime = Time.time;
    }

    public void OnGUI()
    {
        // TODO: The existing scrolling log and command window from the template didn't work here due to stripping, so we need to make our own.
    }

}
