using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    [SerializeField] private Transform player;

    public Transform Player { get { return player; } } 

    public override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        Managers.Popup.CreatePopup(PopupType.LobbyMain);
    }
}
