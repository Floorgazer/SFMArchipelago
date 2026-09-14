using System.IO;
using UnityEngine;
using HarmonyLib;

using SFMArchipelago.Archipelago;

namespace SFMArchipelago
{
    public class ArchipelagoOverlay : MonoBehaviour
    {
        private bool showMenu = false;
        private Rect mainRect = new Rect(10f, 10f, 180f, 150f);
        private bool mainRectCollapsed = false;
        private string status = "";

        public static void CreateInstance(Plugin loader)
        {
            ArchipelagoOverlay overlay = loader.AddComponent<ArchipelagoOverlay>();
            Object.DontDestroyOnLoad(overlay.gameObject);
            overlay.hideFlags |= HideFlags.HideAndDontSave;

            Harmony harmony = new Harmony("com.floorgazer.SFMArchipelago");
            harmony.PatchAll();
        }

        public void Update()
        {
            bool keyDown = Input.GetKeyDown(KeyCode.F6);
            if (keyDown) {
                this.showMenu = !this.showMenu;
                if (this.showMenu)
                {
                    this.mainRect.position = new Vector2(10f, 10f);
                }
            }
        }

        public void OnGUI() {
            if (this.showMenu)
            {
                this.mainRect = GUI.Window(2345, this.mainRect, new System.Action<int>(this.DrawMainWindow), string.Empty);
            }
        }

        private void DrawMainWindow(int id)
        {
            GUIStyle label = GUI.skin.label;
            label.fontSize = 14;
            GUIStyle button = GUI.skin.button;
            button.fontSize = 12;

            GUI.Label(new Rect(10f, 10f, 150f, 30f), "Server IP: "+ArchipelagoClient.ServerData.Uri);
            GUI.Label(new Rect(10f, 40f, 150f, 30f), "Slot Name: "+ArchipelagoClient.ServerData.SlotName);
            GUI.Label(new Rect(10f, 70f, 150f, 30f), "Status: "+this.status);

            if (ArchipelagoClient.Authenticated)
            {
                this.status = "Connected";
            }
            else
            {
                this.status = "Disconnected";
                if (GUI.Button(new Rect(10f, 100f, 100f, 30f), "Reload Data"))
                {
                    using StreamReader reader = new StreamReader("slot.txt");
                    ArchipelagoClient.ServerData.Uri = reader.ReadLine();
                    ArchipelagoClient.ServerData.SlotName = reader.ReadLine();
                    ArchipelagoClient.ServerData.Password = reader.ReadLine();
                    reader.Close();
                }
                // if (GUI.Button(new Rect(10f, 150f, 200f, 30f), "Connect"))
                // {
                //     Plugin.ArchipelagoClient.Connect();
                // }
            }
        }
    }
}
