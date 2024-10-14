using Common.StringEx;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SetCharacterPopup : BaseLockPopup
{
    public List<Image> jobImage;

    public override void Init()
    {
        base.Init();

        for (int i = 0; i < jobImage.Count; i++)
        {
            jobImage[i].sprite = Managers.Job.GetSprite((JobType)i);
        }
    }

    /// <summary>
    /// 캐릭터 선택 함수
    /// </summary>
    public void OnClick(string type)
    {
        Managers.Event.Dispatch(GameEventType.SetCharacter, StringExtensions.StringToEnum<JobType>(type));
        Close();
    }
}
