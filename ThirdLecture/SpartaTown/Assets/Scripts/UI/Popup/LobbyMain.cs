using System;
using TMPro;
using UnityEngine;

public class LobbyMain : BasePopup
{
    [SerializeField] private TextMeshProUGUI timeText;

    private void Update()
    {
        timeText.text = DateTime.Now.ToString("HH:mm");
    }

    public void ChangeCharacter()
    {
        Managers.Popup.CreatePopup(PopupType.SetCharacter, false);
    }

    public void ChangeName()
    {
        Managers.Popup.CreatePopup(PopupType.SetName, false);
    }

    public void PersonList()
    {
        Managers.Popup.CreatePopup(PopupType.EntityList, false);
    }
}
