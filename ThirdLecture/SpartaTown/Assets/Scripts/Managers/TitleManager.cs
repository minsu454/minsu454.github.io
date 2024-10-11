using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public void Start()
    {
        BasePopup popup = Managers.Popup.CreatePopup(PopupType.SetName);

        Managers.Event.Subscribe(GameEventType.PopupClose, LoadLobbyScene);
        popup.OnCloss += () => Managers.Event.Unsubscribe(GameEventType.PopupClose, LoadLobbyScene);
    }

    public void LoadLobbyScene(object args)
    {
        Managers.Scene.LoadScene(SceneType.Lobby);
    }
}
