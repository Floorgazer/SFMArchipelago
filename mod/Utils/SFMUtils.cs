using System;
using System.Collections.Generic;

using IGen = Il2CppSystem.Collections.Generic;

using UnityEngine;

using ExposureUnnoticed2.Master.Stage;
using ExposureUnnoticed2.Master.FastTravel;
using ExposureUnnoticed2.Master.Skill;
using ExposureUnnoticed2.Master.AdultGoods;
using ExposureUnnoticed2.Master.Accessory;
using ExposureUnnoticed2.Master.Hair;
using ExposureUnnoticed2.Master.Rank;
using ExposureUnnoticed2.Master.RankRelease;
using ExposureUnnoticed2.Master.Mission;
using ExposureUnnoticed2.Scripts.InGame;

using SFMArchipelago.Archipelago;

namespace SFMArchipelago.Utils;

public class GameEffects
{
    public static void SetBodyOptions(Dictionary<string, object> slotData)
    {
        var data = GameState.PlayerCustomData;
        data.CustomizeHeight = Convert.ToInt32(slotData["height"]);
        data.CustomizeBoobs = Convert.ToInt32(slotData["boob_size"]);
        data.CustomizeFutanariSaoSize = Convert.ToInt32(slotData["penis_size"]);

        data.CustomizeSkinColor = Convert.ToInt32(slotData["skin_col"]);
        data.CustomizeEyePattern = Convert.ToInt32(slotData["eye_col"]);
        data.CustomizeOddEye = Convert.ToBoolean(slotData["heterochromia"]);
        data.CustomizeEyeLeftPattern = Convert.ToInt32(slotData["left_eye_col"]);
        data.CustomizeYaeba = Convert.ToBoolean(slotData["fang"]);

        // TODO: This seems to not initialise properly on first load for some reason. Perhaps delay adjustments like this with a queue or manager.
        HairType hairType;
        switch (Convert.ToInt32(slotData["hair"]))
        {
            case 1:
                hairType = HairType.Bob;
                break;
            case 2:
                hairType = HairType.Wolf;
                break;
            case 3:
                hairType = HairType.SideBob;
                break;
            case 4:
                hairType = HairType.FairyTwin;
                break;
            case 5:
                hairType = HairType.HalfTwin;
                break;
            case 6:
                hairType = HairType.ElegantLong;
                break;
            case 7:
                hairType = HairType.PrincesWave;
                break;
            case 8:
                hairType = HairType.Pony;
                break;
            case 9:
                hairType = HairType.MafuHair;
                break;
            case 10:
                hairType = HairType.Lynn;
                break;
            case 11:
                hairType = HairType.Himari;
                break;
            case 12:
                hairType = HairType.Invert;
                break;
            case 13:
                hairType = HairType.Natsu;
                break;
            case 14:
                hairType = HairType.Nekomimi;
                break;
            case 15:
                hairType = HairType.Shu;
                break;
            case 16:
                hairType = HairType.Yuki;
                break;
            case 17:
                hairType = HairType.WavePony;
                break;
            case 18:
                hairType = HairType.LovelyMedium;
                break;
            case 19:
                hairType = HairType.WaveLong;
                break;
            case 20:
                hairType = HairType.StraightBob;
                break;
            default:
                //Plugin.BepinLogger.LogMessage("Boring choice");
                //Plugin.BepinLogger.LogMessage(slotData["hair"]);
                hairType = HairType.Short;
                break;
        }
        GameState.GameStateData.HairTypeList[0] = hairType;
        data.CurrentHair = hairType;
        var hairData = data.HairCustomizeDataDict[hairType];
        hairData.TextureId = Convert.ToInt32(slotData["hair_col_pattern"]);
        hairData.R = Convert.ToInt32(slotData["hair_R"]);
        hairData.G = Convert.ToInt32(slotData["hair_G"]);
        hairData.B = Convert.ToInt32(slotData["hair_B"]);
    }


    /* TODO:
     * Various unlocks (shop, coat stages, etc) via ExposureUnnoticed2.Master.Rank.RankRelease override
     * Skill/Pose unlocks via ExposureUnnoticed2.Master.Skill RelaseRank override
     * Investigate whether we can separate unlocks from shop interfaces
     */
    public static void UnlockStage(StageType stageType)
    {
        // Set the rank limit to 0 so it can be accessed no matter how early we are
        MStageRecord record = MStage.Get(stageType);
        record.EnterRankLimit = 0;

        // Unlock the fast travel entry immediately so we can go out of order
        RFastTravel fastTravel = MFastTravel.CreateListByStage(stageType)[0]; // All the list seem to be length 1
        GameState.GameStateData.ReleaseFastTravel.Add(fastTravel.Id);

        // Update the progression data so we can save the state of things.
        ArchipelagoClient.ServerData.progressionData.StageRelease[stageType] = true;
    }

    public static void UnlockDaytime()
    {
        UnlockRankRelease(RankReleaseType.ExposeDaytime);

    }

    public static void UnlockRankRelease(RankReleaseType rankReleaseType)
    {
        MRankRelease.Get(rankReleaseType).ReleaseRank = 0;
        // Update the progression data so we can save the state of things.
        ArchipelagoClient.ServerData.progressionData.RankRelease[rankReleaseType] = true;

    }

    public static void UnlockSkill(SkillType skillType)
    {
        MSkill.Get(skillType).ReleaseRank = 0;
        // Update the progression data so we can save the state of things.
        ArchipelagoClient.ServerData.progressionData.SkillRelease[skillType] = true;

    }

    public static void LockSkill(SkillType skillType)
    {
        MSkill.Get(skillType).ReleaseRank = 8;
        // Update the progression data so we can save the state of things.
        ArchipelagoClient.ServerData.progressionData.SkillRelease[skillType] = true;

    }

    public static void AddRP(int rp)
    {
        GameState.GameStateData.CurrentRp += rp;
    }

    public static void LoadData()
    {
        foreach (KeyValuePair<StageType,bool> kvp in ArchipelagoClient.ServerData.progressionData.StageRelease)
        {
            if (kvp.Value)
            {
                UnlockStage(kvp.Key);
            }
        }
        foreach (KeyValuePair<SkillType,bool> kvp in ArchipelagoClient.ServerData.progressionData.SkillRelease)
        {
            if (kvp.Value)
            {
                UnlockSkill(kvp.Key);
            }
        }
        foreach (KeyValuePair<RankReleaseType,bool> kvp in ArchipelagoClient.ServerData.progressionData.RankRelease)
        {
            if (kvp.Value)
            {
                UnlockRankRelease(kvp.Key);
            }
        }
    }


    public static void InitialiseAll()
    {
        // Add a dummy rank so we're at least pointing at something
        MRankRecord archRecord = ScriptableObject.CreateInstance<MRankRecord>();
        archRecord.NameKey = "Archipelago";
        archRecord.NeedRp = 1<<30;
        archRecord.Rank = 8;
        MRank.GetAll()[8] = archRecord;

        InitialiseStages();
        InitialiseSkills();
        InitialiseRankRelease();
        InitialiseMissions();
    }

    public static void InitialiseStages()
    {
        foreach (IGen.KeyValuePair<StageType,MStageRecord> kvp in MStage.GetAll())
        {
            try
            {
                StageType stageType = kvp.Key;
                MStageRecord record = kvp.Value;

                //Don't restrict home or we'll softlock
                if (stageType != StageType.Apart) {
                    record.EnterRankLimit = 8;
                }

            }
            catch (NullReferenceException e)
            {

            }
        }
    }

    public static void InitialiseSkills()
    {
        foreach (IGen.KeyValuePair<SkillType,MSkillRecord> kvp in MSkill.GetAll())
        {
            try
            {
                SkillType skillType = kvp.Key;
                MSkillRecord record = kvp.Value;

                record.ReleaseRank = 8;
            }
            catch (NullReferenceException e)
            {

            }
        }
    }

    public static void InitialiseRankRelease()
    {
        foreach (IGen.KeyValuePair<RankReleaseType,MRankReleaseRecord> kvp in MRankRelease.GetAll())
        {
            try
            {
                RankReleaseType rankReleaseType = kvp.Key;
                MRankReleaseRecord record = kvp.Value;

                if (rankReleaseType != RankReleaseType.NoneConditionRelease)
                {
                    record.ReleaseRank = 8;
                }
            }
            catch (NullReferenceException e)
            {

            }
        }
    }

    public static void InitialiseMissions()
    {
        //Unlock all missions to start with since they're logically blocked instead
        foreach (IGen.KeyValuePair<StageType,MMissionArea> kvp in MMission.GetAll())
        {
            MMissionArea area = kvp.Value;
            foreach (MMissionOverrideRecord record in area.records)
            {
                record.ReleaseRank = 0;
            }
        }
    }
}

/* TODO:
 * Hook ResultPanel for mission completions on return
 * Do we need other locations?
 */


/* TODO:
 * Hook shop panels to show custom unlock condition text kinda like this
 * static void Postfix(ExposureUnnoticed2.ObjectUI.SkillPanel.SkillItemView __instance, ExposureUnnoticed2.Master.Skill.MSkillRecord __0, Il2CppSystem.Action<ExposureUnnoticed2.Master.Skill.MSkillRecord> __1, Il2CppSystem.Action<ExposureUnnoticed2.Master.Skill.MSkillRecord> __2)
 * {
 *    try {
 *	   if (__0.ReleaseRank == 8) {
 *      __instance.rankConditionText.GetTextInfo("spooky");
 *
 *      }
 *    }
 *    catch (System.Exception ex) {
 *        UnityExplorer.ExplorerCore.LogWarning($"Exception in patch of void        ExposureUnnoticed2.ObjectUI.SkillPanel.SkillItemView::Initialize(ExposureUnnoticed2.Master.Skill.MSkillRecord skill, Il2CppSystem.Action<ExposureUnnoticed2.Master.Skill.MSkillRecord> onClick, Il2CppSystem.Action<ExposureUnnoticed2.Master.Skill.MSkillRecord> onClickReinforce):\n{ex}");
 *    }
 * }
 */

/* TODO:
 * Some kind of in-game text input for server details/slot name
 * Maybe use the NameEditPanelView?
 * Action<string> boo = (x)=>Log(x);
    String test = "Hello";
    //ExposureUnnoticed2.ObjectUI.NameEditPanel.NameEditPanelView.Open(test,boo);

    GameObject.FindObjectOfType<ExposureUnnoticed2.ObjectUI.NameEditPanel.NameEditPanelView>().GetComponentInChildren<Common.CommonUI.CommonTextView>().text.GetTextInfo("olo");
    //Log(panel.get_name());
*/
