using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCTalkPopup : BasePopup
{
    private InfoHandler talkInfo;

    [SerializeField] private GameObject talkWindowGo;
    [SerializeField] private GameObject showTalkGo;

    [SerializeField]  private TextMeshProUGUI talkWindowName;
    [SerializeField]  private TextMeshProUGUI showTalkName;
    [SerializeField]  private TextMeshProUGUI showTalk;

    public override void Init()
    {
        base.Init();
        Managers.Event.Subscribe(GameEventType.TargetChange, OnTargetChange);
    }

    public void OnTargetChange(object args)
    {
        InfoHandler info = args as InfoHandler;

        talkWindowName.text = $"{info.SO.goName}와 대화하기";
        showTalkName.text = info.SO.goName;

        showTalk.text = info.SO.talk;

        talkInfo = info;
    }

    public void ChangeUI(bool isTalking)
    {
        talkWindowGo.SetActive(!isTalking);
        showTalkGo.SetActive(isTalking);
    }

    public override void Close()
    {
        Managers.Event.Unsubscribe(GameEventType.TargetChange, OnTargetChange);
        base.Close();
    }
}
