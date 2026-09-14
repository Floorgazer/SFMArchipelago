using System.Collections.Generic;
using Archipelago.MultiClient.Net.Models;

using UnityEngine;

using ExposureUnnoticed2.Master.Stage;
using ExposureUnnoticed2.Master.RankRelease;
using ExposureUnnoticed2.Master.Skill;
using ExposureUnnoticed2.Master.Skill.SkillSlow;

using SFMArchipelago.Utils;
using SFMArchipelago.Archipelago;

namespace SFMArchipelago;

public class ItemManager : MonoBehaviour
{
    public Queue<ItemInfo> itemQueue = new Queue<ItemInfo>();

    public static void CreateInstance(Plugin loader)
    {
        ItemManager itemManager = loader.AddComponent<ItemManager>();
        Plugin.ItemManager = itemManager;
        Object.DontDestroyOnLoad(itemManager.gameObject);
        itemManager.hideFlags |= HideFlags.HideAndDontSave;
    }

    public void AddItem(ItemInfo itemInfo)
    {
        this.itemQueue.Enqueue(itemInfo);
    }

    public void Awake()
    {
    }

    public void Update()
    {
        if (Plugin.LoadedInSlot)
        {
            while (this.itemQueue.Count > 0) {
                ItemInfo item = this.itemQueue.Dequeue();
                string message = ItemResolver.Resolve(item);
                Plugin.MessageManager.AddMessage(message);
            }
        }
    }
}

public class ItemResolver {

    public static string Resolve(ItemInfo item)
    {
        string message = "Unknown Item Received";
        // See items.py in the APWorld for these ids
        switch(item.ItemId)
        {
            case 1:
                GameEffects.UnlockStage(StageType.Residence);
                message = "Received Stage: Residential Area";
                break;
            case 2:
                GameEffects.UnlockStage(StageType.Park);
                message = "Received Stage: Central Park";
                break;
            case 3:
                GameEffects.UnlockStage(StageType.Convenience);
                message = "Received Stage: Convenience Store";
                break;
            case 4:
                GameEffects.UnlockStage(StageType.Mansion);
                message = "Received Stage: Apartment";
                break;
            case 5:
                GameEffects.UnlockStage(StageType.StationFront);
                message = "Received Stage: Downtown";
                break;
            case 6:
                GameEffects.UnlockStage(StageType.ShoppingMall);
                message = "Received Stage: Shopping Mall";
                break;
            case 7:
                GameEffects.UnlockStage(StageType.FashionShop);
                message = "Received Stage: Clothes Shop";
                break;
            case 8:
                GameEffects.UnlockDaytime();
                message = "Received: Daytime";
                break;

            case 10:
                switch (ArchipelagoClient.ServerData.progressionData.progressiveCoatCount)
                {
                    case 0:
                        GameEffects.UnlockRankRelease(RankReleaseType.ClothesAction2);
                        ArchipelagoClient.ServerData.progressionData.progressiveCoatCount = 1;
                        message = "Recieved Ability: Flash Upper Body";
                        break;
                    case 1:
                        GameEffects.UnlockRankRelease(RankReleaseType.ClothesAction3);
                        ArchipelagoClient.ServerData.progressionData.progressiveCoatCount = 2;
                        message = "Recieved Ability: Get Naked";
                        break;
                }
                break;
            case 11:
                GameEffects.UnlockRankRelease(RankReleaseType.ClothesAction1);
                message = "Received Ability: Flash Butt";
                break;

            case 20:
                GameEffects.UnlockRankRelease(RankReleaseType.Drone);
                message = "Received Item: Drone";
                break;
            case 21:
                GameEffects.UnlockRankRelease(RankReleaseType.Futanari);
                message = "Received Item: Futanari Pill";
                break;
            case 22:
                GameEffects.UnlockRankRelease(RankReleaseType.Handcuff);
                message = "Received Item: Handcuffs";
                break;
            case 23:
                GameEffects.UnlockRankRelease(RankReleaseType.Vibe);
                message = "Received Item: Vibrator";
                break;
            case 24:
                GameEffects.UnlockRankRelease(RankReleaseType.Dildo);
                message = "Received Item: Dildo";
                break;
            case 25:
                GameEffects.UnlockRankRelease(RankReleaseType.EyeMask);
                message = "Received Item: Eye Mask";
                break;
            case 26:
                GameEffects.UnlockRankRelease(RankReleaseType.PistonGoods);
                message = "Received Item: Piston";
                break;
            case 27:
                GameEffects.UnlockRankRelease(RankReleaseType.BodyPaint);
                message = "Received Item: Body Paint";
                break;
            case 28:
                switch (ArchipelagoClient.ServerData.progressionData.progressiveUpgradeCount)
                {
                    case 0:
                        GameEffects.UnlockRankRelease(RankReleaseType.ReinforceRank1);
                        ArchipelagoClient.ServerData.progressionData.progressiveUpgradeCount = 1;
                        message = "Received Upgrade Rank 1";
                        break;
                    case 1:
                        GameEffects.UnlockRankRelease(RankReleaseType.ReinforceRank2);
                        ArchipelagoClient.ServerData.progressionData.progressiveUpgradeCount = 2;
                        message = "Received Upgrade Rank 2";
                        break;
                    case 2:
                        GameEffects.UnlockRankRelease(RankReleaseType.ReinforceRank3);
                        ArchipelagoClient.ServerData.progressionData.progressiveUpgradeCount = 3;
                        message = "Received Upgrade Rank 3";
                        break;
                }
                break;

            case 100:
                GameEffects.UnlockSkill(SkillType.KaikyakuFella);
                message = "Received Pose: Spread-Leg Blowjob";
                break;
            case 101:
                GameEffects.UnlockSkill(SkillType.IBalance);
                message = "Received Pose: I-Split Balance";
                break;
            case 102:
                GameEffects.UnlockSkill(SkillType.Dogeza);
                message = "Received Pose: Dogeza";
                break;
            case 103:
                GameEffects.UnlockSkill(SkillType.HipShake);
                message = "Received Pose: Butt Wiggle";
                break;
            case 104:
                GameEffects.UnlockSkill(SkillType.Tebura);
                message = "Received Pose: Hand Bra";
                break;
            case 105:
                GameEffects.UnlockSkill(SkillType.AhegaoDoublePiece);
                message = "Received Pose: Ahegao Double Peace";
                break;
            case 106:
                GameEffects.UnlockSkill(SkillType.GanimataHip);
                message = "Received Pose: All-Fours";
                break;
            case 107:
                GameEffects.UnlockSkill(SkillType.GanimataWalk);
                message = "Received Pose: Spread-Leg Walk";
                break;
            case 108:
                GameEffects.UnlockSkill(SkillType.DogTintin);
                message = "Received Pose: Penis";
                break;
            case 109:
                GameEffects.UnlockSkill(SkillType.NeKataashiage);
                message = "Received Pose: One-Leg Raise";
                break;
            case 110:
                GameEffects.UnlockSkill(SkillType.WakimiseCrouch);
                message = "Received Pose: Armpit Squat";
                break;
            case 111:
                GameEffects.UnlockSkill(SkillType.Haigure);
                message = "Received Pose: High-Leg";
                break;
            case 112:
                GameEffects.UnlockSkill(SkillType.GanimataKoshiHeko);
                message = "Received Pose: Hip Thrust";
                break;
            case 120:
                GameEffects.UnlockSkill(SkillType.PeeKaikyaku);
                message = "Received Pose: Spread-Leg Urination";
                break;
            case 121:
                GameEffects.UnlockSkill(SkillType.PeeStand);
                message = "Received Pose: Standing Pee";
                break;
            case 122:
                GameEffects.UnlockSkill(SkillType.PeeDog);
                message = "Received Pose: Dog Pee";
                break;
            case 130:
                GameEffects.UnlockSkill(SkillType.OnaniNormal);
                message = "Received Pose: Masturbate";
                break;
            case 131:
                GameEffects.UnlockSkill(SkillType.MituasiOnani);
                message = "Received Pose: Three-Leg Masturbation";
                break;
            case 132:
                GameEffects.UnlockSkill(SkillType.OnaniNeGanimata);
                message = "Received Pose: Supine Masturbation";
                break;
            case 133:
                GameEffects.UnlockSkill(SkillType.OnaniYotuashi);
                message = "Received Pose: Doggy Masturbation";
                break;
            case 134:
                GameEffects.UnlockSkill(SkillType.ChikubiRotate);
                message = "Received Pose: Nipple Play";
                break;
            case 135:
                GameEffects.UnlockSkill(SkillType.OnaniArmKuri);
                message = "Received Pose: Clit Play";
                break;
            case 136:
                GameEffects.UnlockSkill(SkillType.Sikoru);
                message = "Received Pose: Stroking";
                break;

            case 150:
                GameEffects.UnlockSkill(SkillType.NpcDirect);
                message = "Received Skill: Show NPC Direction";
                break;
            case 151:
                switch (ArchipelagoClient.ServerData.progressionData.progressiveSlowMotionCount)
                {
                    case 0:
                        GameEffects.UnlockSkill(SkillType.Slow);
                        ArchipelagoClient.ServerData.progressionData.progressiveSlowMotionCount = 1;
                        message = "Received Skill: Slow Motion";
                        break;
                    // TODO: How to increase slowmo level???
                    // Need to relock the shop option once it's taken if the level you have is equal to your unlock
                }
                break;
            case 152:
                GameEffects.UnlockSkill(SkillType.AutoSlow);
                message = "Received Skill: AutoSlow";
                break;
            case 153:
                GameEffects.UnlockSkill(SkillType.AutoAddMoisture);
                message = "Received Skill: Frequent Urination";
                break;
            case 154:
                GameEffects.UnlockSkill(SkillType.Perspective);
                message = "Received Skill: X-Ray Vision";
                break;
            case 155:
                GameEffects.UnlockSkill(SkillType.DisableHideCostume);
                message = "Received Skill: Casual Outfit Anywhere";
                break;
            case 156:
                GameEffects.UnlockSkill(SkillType.NoReinforceEffect);
                message = "Received Skill: Equipment Effects Disabled";
                break;
            case 157:
                GameEffects.UnlockSkill(SkillType.CantDash);
                message = "Received Skill: Walker";
                break;
            case 158:
                GameEffects.UnlockSkill(SkillType.ContinueMission);
                message = "Received Skill: Mission Cannot Be Interrupted";
                break;
            case 159:
                GameEffects.UnlockSkill(SkillType.FixFps);
                message = "Received Skill: Fixed First-Person View";
                break;
            case 160:
                GameEffects.UnlockSkill(SkillType.FixTps);
                message = "Received Skill: Fixed Third-Person View";
                break;
            case 161:
                GameEffects.UnlockSkill(SkillType.HideStrangeUi);
                message = "Received Skill: Hard Mode";
                break;
            case 162:
                GameEffects.UnlockSkill(SkillType.MaxAccessoryNum);
                // TODO: How to raise this?
                // Similar to slowmo, needs shop relocking
                message = "Received Skill: Progressive Costume Slot Expansion";
                break;
            case 170:
                GameEffects.UnlockSkill(SkillType.AutoBaretaSlow);
                message = "Received Skill: Ah, I'm Finished";
                break;
            case 171:
                GameEffects.UnlockSkill(SkillType.TimeStop);
                message = "Received Skill: Time Stop";
                break;
            case 172:
                GameEffects.UnlockSkill(SkillType.Exhibitionism);
                message = "Received Skill: Exhibitionist Urge";
                break;

            case 200:
                GameEffects.AddRP(100);
                message = "Received: Small RP Bonus";
                break;
            case 201:
                GameEffects.AddRP(500);
                message = "Received: Big RP Bonus";
                break;

            case 210:
                message = "Received Trap: Handcuff Trap";
                break;
            case 211:
                message = "Received Trap: Big Trap";
                break;
            case 212:
                message = "Received Trap: Small Trap";
                break;
            case 213:
                message = "Received Trap: Suspicious Trap";
                break;
        }
        return message;
    }
}
