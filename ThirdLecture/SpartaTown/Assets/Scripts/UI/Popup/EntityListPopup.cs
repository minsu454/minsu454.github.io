using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;

public class EntityListPopup : BasePopup
{
    [SerializeField] private TextMeshProUGUI listTxt;

    public override void Init()
    {
        base.Init();

        newLoad();
        Managers.Event.Subscribe(GameEventType.SetNewName, newLoad);
        Managers.Event.Subscribe(GameEventType.InAreaEntity, SetListTxt);
    }

    public void newLoad(object args = null)
    {
        SetListTxt(Managers.Data.InAreaEntityNames);
    }

    public void SetListTxt(object args)
    {
        var names = args as HashSet<string>;

        string temp = string.Empty;

        temp += $"{Managers.Data.Name} (³ª)\n";

        foreach (var name in names)
        {
            temp += $"{name}\n";
        }

        listTxt.text = temp;
    }

    public override void Close()
    {
        Managers.Event.Unsubscribe(GameEventType.SetNewName, newLoad);
        Managers.Event.Unsubscribe(GameEventType.InAreaEntity, SetListTxt);
        base.Close();
    }
}
