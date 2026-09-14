using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using Archipelago.MultiClient.Net;
using Archipelago.MultiClient.Net.BounceFeatures.DeathLink;
using Archipelago.MultiClient.Net.Enums;
using Archipelago.MultiClient.Net.Helpers;
using Archipelago.MultiClient.Net.Packets;
using Archipelago.MultiClient.Net.Models;
using SFMArchipelago.Utils;

namespace SFMArchipelago.Archipelago;

public class ArchipelagoClient
{
    public const string APVersion = "0.5.0";
    private const string Game = "SFM";

    public static bool Authenticated;
    private bool attemptingConnection;

    public static ArchipelagoData ServerData = new();
    private DeathLinkHandler DeathLinkHandler;
    private ArchipelagoSession session;

    /// <summary>
    /// call to connect to an Archipelago session. Connection info should already be set up on ServerData
    /// </summary>
    /// <returns></returns>
    public void Connect()
    {
        if (Authenticated || attemptingConnection) return;

        try
        {
            session = ArchipelagoSessionFactory.CreateSession(ServerData.Uri);
            SetupSession();
        }
        catch (Exception e)
        {
            Plugin.BepinLogger.LogError(e);
        }

        TryConnect();
    }

    /// <summary>
    /// add handlers for Archipelago events
    /// </summary>
    private void SetupSession()
    {
        session.MessageLog.OnMessageReceived += message => ArchipelagoConsole.LogMessage(message.ToString());
        session.Items.ItemReceived += OnItemReceived;
        session.Socket.ErrorReceived += OnSessionErrorReceived;
        session.Socket.SocketClosed += OnSessionSocketClosed;
    }

    /// <summary>
    /// attempt to connect to the server with our connection info
    /// </summary>
    private void TryConnect()
    {
        try
        {
            // it's safe to thread this function call but unity notoriously hates threading so do not use excessively
            ThreadPool.QueueUserWorkItem(
                _ => HandleConnectResult(
                    session.TryConnectAndLogin(
                        Game,
                        ServerData.SlotName,
                        ItemsHandlingFlags.AllItems,
                        new Version(APVersion),
                        password: ServerData.Password,
                        requestSlotData: ServerData.NeedSlotData
                    )));
        }
        catch (Exception e)
        {
            Plugin.BepinLogger.LogError(e);
            HandleConnectResult(new LoginFailure(e.ToString()));
            attemptingConnection = false;
        }
    }

    /// <summary>
    /// handle the connection result and do things
    /// </summary>
    /// <param name="result"></param>
    private void HandleConnectResult(LoginResult result)
    {
        string outText;
        if (result.Successful)
        {
            var success = (LoginSuccessful)result;

            ServerData.SetupSession(success.SlotData, session.RoomState.Seed);
            Authenticated = true;

            DeathLinkHandler = new(session.CreateDeathLinkService(), ServerData.SlotName);
            session.Locations.CompleteLocationChecksAsync(ServerData.CheckedLocations.ToArray());
            outText = $"Successfully connected to {ServerData.Uri} as {ServerData.SlotName}!";

            ArchipelagoConsole.LogMessage(outText);
        }
        else
        {
            var failure = (LoginFailure)result;
            outText = $"Failed to connect to {ServerData.Uri} as {ServerData.SlotName}.";
            outText = failure.Errors.Aggregate(outText, (current, error) => current + $"\n    {error}");

            Plugin.BepinLogger.LogError(outText);

            Authenticated = false;
            Disconnect();
        }

        ArchipelagoConsole.LogMessage(outText);
        attemptingConnection = false;
    }

    /// <summary>
    /// something went wrong, or we need to properly disconnect from the server. cleanup and re null our session
    /// </summary>
    public void Disconnect()
    {
        Plugin.BepinLogger.LogDebug("disconnecting from server...");
        session?.Socket.DisconnectAsync();
        session = null;
        Authenticated = false;
        ServerData = new(ServerData.Uri,ServerData.SlotName,ServerData.Password);
    }

    public void SendMessage(string message)
    {
        session.Socket.SendPacketAsync(new SayPacket { Text = message });
    }

    public long GetLocationId(string name)
    {
        return session.Locations.GetLocationIdFromName(Game, name);
    }
    public void CheckLocations(long[] ids)
    {

        session.Locations.CompleteLocationChecks(ids);
        ServerData.CheckedLocations.AddRange(ids);


        Action<Dictionary<long, ScoutedItemInfo>> callback = (dict) => {
            foreach (var id in ids)
            {
                ScoutedItemInfo info = dict[id];
                string playerName = info.Player.Name;
                string itemName = info.ItemName;
                string locationName = session.Locations.GetLocationNameFromId(id);
                Plugin.MessageManager.AddMessage($"Found {playerName}'s \"{itemName}\" ({locationName})");
                ServerData.CheckedLocations.Add(id);
            }
        };
        //session.Locations.ScoutLocationsAsync(ids);
    }

    /// <summary>
    /// we received an item so reward it here
    /// </summary>
    /// <param name="helper">item helper which we can grab our item from</param>
    private void OnItemReceived(ReceivedItemsHelper helper)
    {
        var receivedItem = helper.DequeueItem();

        if (helper.Index <= ServerData.Index) return;

        ServerData.Index++;

        Plugin.BepinLogger.LogMessage(receivedItem.ItemName);
        Plugin.ItemManager.AddItem(receivedItem);
    }

    /// <summary>
    /// something went wrong with our socket connection
    /// </summary>
    /// <param name="e">thrown exception from our socket</param>
    /// <param name="message">message received from the server</param>
    private void OnSessionErrorReceived(Exception e, string message)
    {
        Plugin.BepinLogger.LogError(e);
        ArchipelagoConsole.LogMessage(message);
    }

    /// <summary>
    /// something went wrong closing our connection. disconnect and clean up
    /// </summary>
    /// <param name="reason"></param>
    private void OnSessionSocketClosed(string reason)
    {
        Plugin.BepinLogger.LogError($"Connection to Archipelago lost: {reason}");
        Disconnect();
    }
}
