using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public void Start()
    {
        BasePopup popup = Managers.Popup.CreatePopup(PopupType.SetName);

        popup.ClossEvent += LoadLobbyScene;
    }

    public void LoadLobbyScene()
    {
        Managers.Scene.LoadScene(SceneType.Lobby);
    }
}
