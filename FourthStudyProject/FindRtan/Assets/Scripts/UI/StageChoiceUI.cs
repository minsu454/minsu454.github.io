using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageChoiceUI : MonoBehaviour
{
    public List<StageUI> stageUIList = new List<StageUI>();

    private void Start()
    {
        StageChoiceLockUI();
    }

    public void StageChoiceLockUI()
    {
        for (int i = 0; i < StageManager.Instance.MinUnlockLevel; i++)
        {
            if (stageUIList.Count <= i)
                break;

            stageUIList[i].SetUnlock(true);
        }
    }
}
