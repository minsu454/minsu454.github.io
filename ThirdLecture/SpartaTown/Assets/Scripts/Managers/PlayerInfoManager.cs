using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoManager
{
    private readonly Dictionary<JobType, RuntimeAnimatorController> jobDic = new Dictionary<JobType, RuntimeAnimatorController>();      //캐릭터별로 애니메이터 저장 dic
    private readonly Dictionary<JobType, Sprite> spriteDic = new Dictionary<JobType, Sprite>();                                         //캐릭터별로 기본이미지 저장 dic

    /// <summary>
    /// 생성 함수
    /// </summary>
    public void Init()
    {
        foreach (JobType type in Enum.GetValues(typeof(JobType)))
        {
            RuntimeAnimatorController controller = Resources.Load<RuntimeAnimatorController>(string.Format($"Animator/{type.ToString()}"));
            jobDic.Add(type, controller);

            Sprite sprite = Resources.Load<Sprite>(string.Format($"Sprite/{type.ToString()}"));
            spriteDic.Add(type, sprite);
        }
    }

    /// <summary>
    /// 해당 직업 animator 반환 함수
    /// </summary>
    public RuntimeAnimatorController GetAnimator(JobType type)
    {
        if (!jobDic.TryGetValue(type, out var animator))
        {
            Debug.LogError($"Is Not Find JobDic {type}");
            return null;
        }

        return animator;
    }

    /// <summary>
    /// 해당 직업 sprite 반환 함수
    /// </summary>
    public Sprite GetSprite(JobType type)
    {
        if (!spriteDic.TryGetValue(type, out var sprite))
        {
            Debug.LogError($"Is Not Find JobDic {type}");
            return null;
        }

        return sprite;
    }

}
