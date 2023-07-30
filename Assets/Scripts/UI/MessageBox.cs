using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;

public enum MessageBoxState { Enabled, Disabled }
struct Message { public string MessageText; public float Time; }


/// <summary>
/// MessageBox allows to display some message to the screen.
/// Use AddMessage method to add message to the messagebox queue
/// All the added message will be displayed in provided interval of time
/// </summary>
public class MessageBox : MonoBehaviour
{
    public static MessageBox Singleton;
    public const float TransitionDisableTime = 0.8f;//The message box is disabled for this time before enabling for next message to display
    public MessageBoxState MessageBoxCurrentState = MessageBoxState.Disabled;

    [SerializeField] GameObject MessageBoxGameObject;
    [SerializeField] TMP_Text MessageText;

    private Queue<Message> _messages = new Queue<Message>();

    private void Awake()
    {
        if (Singleton == null) Singleton = this;
        else Destroy(this.gameObject);
    }

    private void Start()
    {
        DisableMessageBox();
        MessageText.text = "";
        MessageBoxCurrentState = MessageBoxState.Disabled;
    }
    /// <summary>
    /// Adds the message to message registry and displays the message.
    /// </summary>
    /// <param name="message">The message to be displayed</param>
    /// <param name="time">Message will be displayed for this amount of time</param>
    public void AddMessage(string message, float time)
    {
        _messages.Enqueue(new Message() { MessageText = message, Time = time });
        print($"Message Added : {message}");
        if (MessageBoxCurrentState == MessageBoxState.Disabled)
            StartCoroutine(ShowMessages());
    }

    private IEnumerator ShowMessages()
    {
        MessageBoxCurrentState = MessageBoxState.Enabled;

        while (_messages.Count > 0)
        {
            Message message = _messages.Dequeue();
            MessageText.text = message.MessageText;
            EnableMessageBox();
            yield return new WaitForSeconds(message.Time);
            DisableMessageBox();
            yield return new WaitForSeconds(TransitionDisableTime);
        }
        MessageBoxCurrentState = MessageBoxState.Disabled;
    }

    private void EnableMessageBox() => MessageBoxGameObject.SetActive(true);
    private void DisableMessageBox() => MessageBoxGameObject.SetActive(false);
}