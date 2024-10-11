using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    private void Start()
    {
        Managers.Popup.CreatePopup(PopupType.LobbyMain);
    }
}
