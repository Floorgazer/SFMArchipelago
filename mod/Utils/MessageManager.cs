using System.Collections.Generic;

using UnityEngine;

using ExposureUnnoticed2.ObjectUI.InGame.MessagePanel;


namespace SFMArchipelago;

public class MessageManager : MonoBehaviour
{

    public Queue<string> messageQueue = new Queue<string>();
    public int cooldown = 0;

    public static void CreateInstance(Plugin loader)
    {
        MessageManager messageManager = loader.AddComponent<MessageManager>();
        Plugin.MessageManager = messageManager;
        Object.DontDestroyOnLoad(messageManager.gameObject);
        messageManager.hideFlags |= HideFlags.HideAndDontSave;
    }

    public void AddMessage(string message)
    {
        this.messageQueue.Enqueue(message);
    }

    public void Awake()
    {
    }

    public void Update()
    {
        MessagePanelView panel = MessagePanelView.Instance;
        if (panel != null)
        {
            if (this.cooldown > 0)
            {
                this.cooldown -= 1;
            } else {
                if (this.messageQueue.Count > 0) {
                    string message = this.messageQueue.Dequeue();
                    panel.AddMessageInstance(message, MessagePanelView.MessageType.Log);
                    this.cooldown = 30;
                }
            }
        }
    }
}
