using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using TMPro;
using UnityEngine;

public class EntityListPopup : BasePopup
{
    [SerializeField] private TextMeshProUGUI listTxt;       //텍스트리스트 작성 변수

    public override void Init()
    {
        base.Init();

        newLoad();
        Managers.Event.Subscribe(GameEventType.SetNewName, newLoad);
        Managers.Event.Subscribe(GameEventType.InAreaEntity, SetListTxt);
    }

    /// <summary>
    /// 내 자신의 내용이 뭔가 바꿨을 때 호출되는 함수(인게임 이름 변경)
    /// </summary>
    public void newLoad(object args = null)
    {
        SetListTxt(Managers.Data.InAreaEntityNames);
    }

    /// <summary>
    /// 리스트 사람들 보여주는 함수
    /// </summary>
    public void SetListTxt(object args)
    {
        var names = args as HashSet<string>;

        string temp = string.Empty;

        temp += $"{Managers.Data.Name} (나)\n";

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
