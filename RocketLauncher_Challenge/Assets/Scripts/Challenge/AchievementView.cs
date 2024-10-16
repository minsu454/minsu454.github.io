﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class AchievementView : MonoBehaviour
{
    [SerializeField] private GameObject achievementSlotPrefab;  // 업적 슬롯 프리팹
    private Dictionary<int, AchievementSlot> achievementSlots = new();

    public void CreateAchievementSlots(AchievementSO[] achievements)
    {
        // achievement 데이터에 따라 슬롯을 생성함
        for (int i = 0; i < achievements.Length; i++)
        {
            GameObject go = Instantiate(achievementSlotPrefab, transform);
            AchievementSlot slot = go.GetComponent<AchievementSlot>();

            slot.Init(achievements[i]);
            achievementSlots[achievements[i].threshold] = slot;
        }
    }

    public void UnlockAchievement(int threshold)
    {
        if (!achievementSlots.TryGetValue(threshold, out AchievementSlot achievement))
            return;

        // UI 반영 로직
        achievement.MarkAsChecked();
    }
}