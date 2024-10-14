using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    private TextMeshProUGUI text;

    private BasePopup popup;

    public void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        ShowName(Managers.Data.Name);
        Managers.Event.Subscribe(GameEventType.SetNewName, ShowName);
    }

    public void ShowName(object args)
    {
        text.text = args.ToString();
    }

    public void ShowNPCTalkPopup()
    {
        if (popup != null)
        {
            popup = Managers.Popup.CreatePopup(PopupType.NPCTalk, false);
        }
    }

    public void OnDestroy()
    {
        Managers.Event.Unsubscribe(GameEventType.SetNewName, ShowName);
    }
}
