using TMPro;
using UnityEngine;

public class PlayerUI : BaseUIController
{
    private BasePopup popup;    //npc대화창 팝업 저장 변수

    public void Start()
    {
        ShowName(Managers.Data.Name);
        Managers.Event.Subscribe(GameEventType.SetNewName, ShowName);
    }

    /// <summary>
    /// Npc팝업 켜주고 꺼주는 함수
    /// </summary>
    public void ShowNPCTalkPopup(bool active)
    {
        if (!active)
        {
            popup?.Close();
            popup = null;
            return;
        }

        if (popup == null)
        {
            popup = Managers.Popup.CreatePopup(PopupType.NPCTalk, false);
        }
    }

    public void OnDestroy()
    {
        Managers.Event.Unsubscribe(GameEventType.SetNewName, ShowName);
    }
}
