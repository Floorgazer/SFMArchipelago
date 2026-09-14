using System.IO;
using Newtonsoft.Json;

using HarmonyLib;

using UnityEngine;

using ExposureUnnoticed2.ObjectUI.SaveDataSelectPanel;
using ExposureUnnoticed2.ObjectUI.ResultPanel;
using ExposureUnnoticed2.Scripts.OtherScene;
using ExposureUnnoticed2.Scripts.UI;
using ExposureUnnoticed2.Scripts.InGame;
using ExposureUnnoticed2.Scripts.Base;

using SFMArchipelago.Utils;
using SFMArchipelago.Archipelago;

namespace SFMArchipelago;

[HarmonyPatch(typeof(SpringboardLoadEmpty), nameof(SpringboardLoadEmpty.Start))]
class PatchSpringboard
{
    static void Postfix(SpringboardLoadEmpty __instance)
    {
        //TODO: Logic about only loading on the right slots/initialising on new game

        if (!Plugin.LoadedInSlot)
        {
            int slot = ExposureUnnoticed2.Scripts.InGame.GameState.SaveDataSlotIndex;
            string path = Path.Combine(Application.persistentDataPath, $"SaveData/{slot}AP.json");
            if (Plugin.NewGame)
            {
                //GameEffects.InitialiseAll();
                Listeners.AddAllListeners();
                if (File.Exists(path))
                {
                    File.Delete(path);
                    Plugin.BepinLogger.LogMessage("Destroying old save...");
                }
                //SFMArchipelago.Utils.GameEffects.UnlockStage(ExposureUnnoticed2.Master.Stage.StageType.StationFront);
                Plugin.LoadedInSlot = true;
                Plugin.BepinLogger.LogMessage("Connecting...");
                Plugin.ArchipelagoClient.Connect();
            } else if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                JsonSerializerSettings settings = new JsonSerializerSettings();
                ArchipelagoClient.ServerData = JsonConvert.DeserializeObject<ArchipelagoData>(json, settings);
                GameEffects.LoadData();
                Listeners.AddAllListeners();
                Plugin.LoadedInSlot = true;
                Plugin.BepinLogger.LogMessage("Connecting...");
                Plugin.ArchipelagoClient.Connect();
            }
        } else {
            Plugin.BepinLogger.LogMessage("Already in");
        }
    }
}

[HarmonyPatch(typeof(SaveManager), nameof(SaveManager.SaveSystem))]
class PatchSaveManager
{
    static void Postfix(SaveRapper.SaveDataType type, int slot)
    {

        //TODO: Logic about only saving over the right slots
        if (Plugin.LoadedInSlot == true)
        {
            if (slot >= 0)
            {
                string json = ArchipelagoClient.ServerData.ToString();
                string path = Path.Combine(Application.persistentDataPath, $"SaveData/{slot}AP.json");
                File.WriteAllText(path,json);
                Plugin.BepinLogger.LogMessage("Saved!");
            }
        };
    }
}

[HarmonyPatch(typeof(TitleSceneView))]
class PatchTitleScreen
{
    [HarmonyPostfix]
    [HarmonyPatch("Awake")]
    static void AwakePostfix()
    {
        if (Plugin.LoadedInSlot)
        {
            Plugin.BepinLogger.LogMessage("Exited...");
            Plugin.LoadedInSlot = false;
            Listeners.RemoveAllListeners();
        }
        if (ArchipelagoClient.Authenticated)
        {
            Plugin.ArchipelagoClient.Disconnect();
        }
        Utils.GameEffects.InitialiseAll();
    }

    [HarmonyPostfix]
    [HarmonyPatch("OnClickNewGame")]
    static void NewGamePostfix(TitleSceneView __instance)
    {
        Plugin.NewGame = true;
    }

    [HarmonyPostfix]
    [HarmonyPatch("OnClickContinue")]
    static void ContinuePostfix(TitleSceneView __instance)
    {
        Plugin.NewGame = false;
    }
}
