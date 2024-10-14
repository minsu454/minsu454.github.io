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

    /// <summary>
    /// 캐릭터 바꾸는 팝업 생성 함수
    /// </summary>
    public void ChangeCharacter()
    {
        Managers.Popup.CreatePopup(PopupType.SetCharacter, false);
    }

    /// <summary>
    /// 이름 바꾸는 팝업 생성 함수
    /// </summary>
    public void ChangeName()
    {
        Managers.Popup.CreatePopup(PopupType.SetName, false);
    }

    /// <summary>
    /// 인원리스트 팝업 생성 함수
    /// </summary>
    public void EntityList()
    {
        Managers.Popup.CreatePopup(PopupType.EntityList, false);
    }
}
