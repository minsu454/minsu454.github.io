using System;
using System.Collections.Generic;
using Unity.VisualScripting;

public class DataService
{
    public string Name { get; private set; } = string.Empty;            //player이름
    public JobType Job { get; private set; } = JobType.Penguin;         //player캐릭터
    public HashSet<string> InAreaEntityNames { get; private set; } = new HashSet<string>(); //에리어에 들어온 EntityList
    
    public void Init()
    {
        Managers.Event.Subscribe(GameEventType.SetNewName, SetName);
        Managers.Event.Subscribe(GameEventType.SetCharacter, SetCharacter);
        Managers.Event.Subscribe(GameEventType.InAreaEntity, SaveEntitys);
    }

    /// <summary>
    /// 바뀐 이름 저장해주는 함수
    /// </summary>
    private void SetName(object args)
    {
        Name = args.ToString();
    }

    /// <summary>
    /// 바뀐 캐릭터 저장해주는 함수
    /// </summary>
    private void SetCharacter(object args)
    {
        Job = (JobType)args;
    }

    /// <summary>
    /// 바뀐 Entity 리스트 저장해주는 함수
    /// </summary>
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
