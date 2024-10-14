using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCTalkPopup : BasePopup
{
    private InfoHandler talkInfo;

    [SerializeField] private GameObject talkWindowGo;               //가까이 가면 나오는 팝업 Go
    [SerializeField] private GameObject showTalkGo;                 //대화하고 있는 창 Go

    [SerializeField]  private TextMeshProUGUI talkWindowName;       //가까이 가면 나오는 팝업에 이름 Txt 변수
    [SerializeField]  private TextMeshProUGUI showTalkName;         //대화하고 있는 창에 띄워주는 이름 Txt 변수
    [SerializeField]  private TextMeshProUGUI showTalk;             //대화하고 있는 창에 띄워주는 대화내용 Txt 변수

    public override void Init()
    {
        base.Init();
        Managers.Event.Subscribe(GameEventType.TargetChange, OnTargetChange);
    }

    /// <summary>
    /// 목표 바뀔 경우 목표의 데이터로 바꿔주는 함수
    /// </summary>
    public void OnTargetChange(object args)
    {
        InfoHandler info = args as InfoHandler;

        talkWindowName.text = $"{info.SO.goName}와 대화하기";
        showTalkName.text = info.SO.goName;

        showTalk.text = info.SO.talk;

        talkInfo = info;
    }

    /// <summary>
    /// 대화하고있는 팝업인지 아닌지 팝업 바꿔주는 함수
    /// </summary>
    public void IsTalkButton(bool isTalking)
    {
        talkWindowGo.SetActive(!isTalking);
        showTalkGo.SetActive(isTalking);

        Managers.Event.Dispatch(GameEventType.LockInput, !isTalking);
    }

    public override void Close()
    {
        Managers.Event.Unsubscribe(GameEventType.TargetChange, OnTargetChange);
        base.Close();
    }
}
