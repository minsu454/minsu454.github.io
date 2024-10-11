using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DataService
{
    public string Name = string.Empty;

    public void Init()
    {
        Managers.Event.Subscribe(GameEventType.SetNewName, SetName);
    }

    public void SetName(object args)
    {
        Name = args.ToString();
    }
}
