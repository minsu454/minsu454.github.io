using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    public TextMeshProUGUI timeText;

    public override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        timeText.text = DateTime.Now.ToString("HH:mm");
    }
}
