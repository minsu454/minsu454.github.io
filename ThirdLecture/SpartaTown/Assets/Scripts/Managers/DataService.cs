using System;
using System.Collections.Generic;
using Unity.VisualScripting;

public class DataService
{
    public string Name { get; private set; } = string.Empty;
    public JobType Job { get; private set; } = JobType.Penguin;
    public HashSet<string> InAreaEntityNames { get; private set; } = new HashSet<string>();
    
    public void Init()
    {
        Managers.Event.Subscribe(GameEventType.SetNewName, SetName);
        Managers.Event.Subscribe(GameEventType.SetCharacter, SetCharacter);
        Managers.Event.Subscribe(GameEventType.InAreaEntity, SaveEntitys);
    }

    private void SetName(object args)
    {
        Name = args.ToString();
    }

    private void SetCharacter(object args)
    {
        Job = (JobType)args;
    }

    public void SaveEntitys(object args)
    {
        HashSet<string> temps = args as HashSet<string>;

        if (temps == null)
        {
            throw new NullReferenceException();
        }

        InAreaEntityNames.Clear();
        InAreaEntityNames = temps;
    }
}
