using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoManager
{
    private readonly Dictionary<JobType, RuntimeAnimatorController> jobDic = new Dictionary<JobType, RuntimeAnimatorController>();
    private readonly Dictionary<JobType, Sprite> spriteDic = new Dictionary<JobType, Sprite>();

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

    public RuntimeAnimatorController GetAnimator(JobType type)
    {
        if (!jobDic.TryGetValue(type, out var animator))
        {
            Debug.LogError($"Is Not Find JobDic {type}");
            return null;
        }

        return animator;
    }

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
