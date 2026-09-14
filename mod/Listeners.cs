using System.Collections.Generic;

using ExposureUnnoticed2.Scripts.Base;
using ExposureUnnoticed2.Scripts.Mission;
using ExposureUnnoticed2.Scripts.InGame;
using ExposureUnnoticed2.Master.Stage;

namespace SFMArchipelago;

public class Listeners
{
    public static void AddAllListeners()
    {
        EventManager.AddListener<CompleteTransitionStageEvent>((Il2CppSystem.Action<CompleteTransitionStageEvent>)OnCompleteTransitionStageEvent);
        Plugin.BepinLogger.LogMessage("Registered Listeners!");
    }
    public static void RemoveAllListeners()
    {
        EventManager.RemoveListener<CompleteTransitionStageEvent>((Il2CppSystem.Action<CompleteTransitionStageEvent>)OnCompleteTransitionStageEvent);
        Plugin.BepinLogger.LogMessage("Removed Listeners!");
    }

    public static void OnCompleteTransitionStageEvent(CompleteTransitionStageEvent e)
    {
        if (Plugin.LoadedInSlot == true)
        {
            Plugin.BepinLogger.LogMessage("Heard the stage transition!");
            if (e.StageController.StageType == StageType.Apart)
            {
                Plugin.BepinLogger.LogMessage("Made it home!");
                List<MissionBase> newCompleteMissions = new List<MissionBase>();

                int completed_missions = 0;
                foreach (var mission in MissionManager.Instance.MissionList)
                {
                    var key = mission.UniqueMissionId;
                    var dict = GameState.GameStateData.MissionAchieveCountDict;
                    if (!dict.ContainsKey(key) || dict[key]==0)
                    {
                        // Msision hasn't been completed before, so we check if we're completing it now.
                        if (InGameManager.Instance.TempInGameState.MissionCompleteThisGameSet.Contains(key)
                        )
                        {
                            // If we had a way to look up a mission from its id we could just do that directly
                            newCompleteMissions.Add(mission);
                            Plugin.BepinLogger.LogMessage($"Found new completed mission {key}!");
                            completed_missions += 1;
                        }
                    } else {
                        completed_missions += 1;
                    }
                }
                LocationManager.CompleteMissions(newCompleteMissions.ToArray());
                if (completed_missions >= MissionManager.Instance.MissionList.Count)
                {
                    LocationManager.CompleteGame();
                }
            }
        };
    }
}
