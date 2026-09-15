using System.Linq;
using System;
using SFMArchipelago.Archipelago;

using ExposureUnnoticed2.Scripts.Mission;
using ExposureUnnoticed2.Master.Stage;

namespace SFMArchipelago;

public class LocationManager
{
    public static void CompleteGame()
    {
        Plugin.ArchipelagoClient.CheckLocations([Plugin.ArchipelagoClient.GetLocationId("All missions complete")]);
    }

    public static void CompleteMissions(MissionBase[] missionIds)
    {
        long[] ids = missionIds.Select(x => GetMissionLocationId(x)).ToArray();

        Plugin.ArchipelagoClient.CheckLocations(ids);
    }

    public static long GetMissionLocationId(MissionBase mission)
    {
        StageType stage = mission.RMission.StageType;
        string name = mission.MissionName;



        string APMissionName = "";

        switch (stage)
        {
            case StageType.Residence:
                APMissionName += "RA: ";
                break;
            case StageType.Park:
                APMissionName += "CP: ";
                break;
            case StageType.StationFront:
                APMissionName += "DT: ";
                break;
            case StageType.Convenience:
                APMissionName += "CO: ";
                break;
            case StageType.Mansion:
                APMissionName += "AP: ";
                break;
            case StageType.ShoppingMall:
                APMissionName += "SM: ";
                break;
            case StageType.FashionShop:
                APMissionName += "CL: ";
                break;
        }
        APMissionName += ConvertMissionName(name);
        return Plugin.ArchipelagoClient.GetLocationId(APMissionName);
    }

    private static string ConvertMissionName(string missionName)
    {
        switch (missionName)
        {
            case "Flash your front in a place where people pass by":
                return "Flash front";
            case "Perform a pose action while flashing or naked in a place where people pass by":
                return "Pose";
            case "Step into the light while flashing":
                return "Flash in light";
            case "Use a vending machine while flashing":
                return "Use vending machine while flashing";
            case "Urinate in a place where people pass by":
                return "Urinate";
            case "Flash your butt in a place where people pass by":
                return "Flash butt";
            case "Flash your upper body in a place where people pass by":
                return "Flash upper body";
            case "Flash near someone":
                return "Flash near someone";
            case "Flash while being watched":
                return "Flash while watched";
            case "Climax near someone while flashing":
                return "Climax near someone";
            case "Show off your flashed parts":
                return "Show off flashed parts";
            case "Use a dildo while flashing in a place where people pass by":
                return "Dildo";
            case "While flashing or naked and handcuffed, stay near someone":
                return "Handcuffs near someone";
            case "In a place where people pass by, handcuff yourself to an object while flashing or naked":
                return "Handcuffs object";
            case "Splash semen on a person":
                return "Splash someone";
            case "Get naked in a place where people pass by":
                return "Naked";
            case "Step into the light while naked":
                return "Naked in light";
            case "Use a vending machine while naked":
                return "Vending machine while naked";
            case "Use a dildo while naked in a place where people pass by":
                return "Naked Dildo";
            case "Get naked near someone":
                return "Naked near someone";
            case "Show off your naked body":
                return "Show off naked body";

            case "Press the intercom and wait at the door while flashing":
                return "Press intercom and wait while flashing";
            case "Be in Crosswalk while flashing":
                return "Be in crosswalk while flashing";
            case "Sit on a chair while flashing":
                return "Sit on chair while flashing";
            case "Be in Fountain Plaza while flashing":
                return "Be in plaza while flashing";
            case "Be in Checkout Counter while flashing":
                return "Be in counter while flashing";
            case "Flash while being served at a register":
                return "Flash while being served";
            case "Be in Footbridge while flashing":
                return "Be in footbridge while flashing";
            case "Be in Entrance while flashing":
                return "Be in entrance while flashing";
            case "Ride the elevator with someone while flashing":
                return "Ride elevator with someone while flashing";
            case "Move on an escalator while flashing":
                return "Move on escalator while flashing";

            case "Press the intercom and wait at the door while naked":
                return "Press intercom and wait while naked";
            case "Be in Crosswalk while naked":
                return "Be in crosswalk while naked";
            case "Sit on a chair while naked":
                return "Sit on chair while naked";
            case "Be in Fountain Plaza while naked":
                return "Be in plaza while naked";
            case "Be in Checkout Counter while naked":
                return "Be in counter while naked";
            case "Be in Entrance while naked":
                return "Be in entrance while naked";
            case "Ride the elevator with someone while naked":
                return "Ride elevator with someone while naked";
            case "Move on an escalator while naked":
                return "Move on escalator while naked";

            case "While flashing, set the vibrator to High/Random and move 50 m":
                return "Move 50m with vibe while flashing";
            case "While flashing, set the vibrator to High/Random and move 60 m":
                return "Move 60m with vibe while flashing";
            case "While flashing, set the vibrator to High/Random and move 25 m":
                return "Move 25m with vibe while flashing";
            case "While flashing, set the vibrator to High/Random and move 15 m":
                return "Move 15m with vibe while flashing";
            case "While flashing and blindfolded, move 50 m":
                return "Move 50m while flashing and blindfolded";
            case "While flashing and blindfolded, move 60 m":
                return "Move 60m while flashing and blindfolded";
            case "While flashing and blindfolded, move 25 m":
                return "Move 25m while flashing and blindfolded";
            case "While flashing and blindfolded, move 40 m":
                return "Move 40m while flashing and blindfolded";
            case "While flashing and blindfolded, move 15 m":
                return "Move 15m while flashing and blindfolded";

            case "While naked, set the vibrator to High/Random and move 60 m":
                return "Move 60m with vibe while naked";
            case "While naked, set the vibrator to High/Random and move 30 m":
                return "Move 30m with vibe while naked";
            case "While naked, set the vibrator to High/Random and move 25 m":
                return "Move 25m with vibe while naked";
            case "While naked, set the vibrator to High/Random and move 15 m":
                return "Move 15m with vibe while naked";
            case "While naked and crouching, move 25 m":
                return "Move 25m while naked and crouching";
            case "While naked and crouching, move 7 m":
                return "Move 7m while naked and crouching";
            case "While naked and crouching, move 15 m":
                return "Move 15m while naked and crouching";
            case "While naked and crouching, move 10 m":
                return "Move 10m while naked and crouching";
            case "While naked and blindfolded, move 50 m":
                return "Move 50m while naked and blindfolded";
            case "While naked and blindfolded, move 60 m":
                return "Move 60m while naked and blindfolded";
            case "While naked and blindfolded, move 30 m":
                return "Move 30m while naked and blindfolded";
            case "While naked and blindfolded, move 25 m":
                return "Move 25m while naked and blindfolded";
            case "While naked and blindfolded, move 40 m":
                return "Move 40m while naked and blindfolded";
            case "While naked and blindfolded, move 15 m":
                return "Move 15m while naked and blindfolded";
            case "Move 90 m away from your coat":
                return "Move 90m away from coat";
            case "Move 80 m away from your coat":
                return "Move 80m away from coat";
            case "Move 12 m away from your coat":
                return "Move 12m away from coat";
            case "Move 95 m away from your coat":
                return "Move 95m away from coat";
            case "Move 100 m away from your coat":
                return "Move 100m away from coat";
            case "Move 1 floors away from your coat":
                return "Move 1 floor away from coat";
            case "Move 2 floors away from your coat":
                return "Move 2 floors away from coat";

            case "Leave your coat outside the restroom and stay in the stall with the door open":
                return "Leave coat outside and stay in stall";
            case "Place the coat outside the pedestrian bridge and stand on top of the pedestrian bridge":
                return "Leave coat outside bridge and stand on";
            case "Wash your clothes in the washing machine":
                return "Wash clothes";
            case "Place the coat outside the apartment and go to the top floor":
                return "Leave coat outside and go to top floor";
            case "Leave the coat outside the elevator and stop at every floor naked.":
                return "Leave coat outside and stop at every floor";
            case "Leave your coat outside the elevator, then use the elevator to move":
                return "Leave coat outside elevator and use it";
            case "Leave your coat in the fitting room and move 17 m away from it":
                return "Leave coat in fitting room and move 17m away";
            default:
                return "Unknown mission";
        }
    }
}



/* Mission Id Stage reference
 *
 * RA: 10 0000
 * CP: 14 0000
 * DT: 12 0000
 * CO: 06 0000
 * AP: 15 0000
 * SM: 11 0000
 * CL: 07 0000
 *
 * ids are in mission list order
 */
