using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DataService
{
    public string Name = string.Empty;
    public JobType job = JobType.Penguin;

    public void Init()
    {
        Managers.Event.Subscribe(GameEventType.SetNewName, SetName);
        Managers.Event.Subscribe(GameEventType.SetCharacter, SetCharacter);
    }

    private void SetName(object args)
    {
        Name = args.ToString();
    }

    private void SetCharacter(object args)
    {
        job = (JobType)args;
    }
}
