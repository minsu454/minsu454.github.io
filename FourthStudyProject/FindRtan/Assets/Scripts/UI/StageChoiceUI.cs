using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageChoiceUI : MonoBehaviour
{
    public GameObject hiddenGo;

    public List<StageUI> stageUIList = new List<StageUI>();

    private int curKey = 0;
    private int maxKey = 4;

    private void Start()
    {
        StageChoiceLockUI();
        IsGoalAchieved();
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

    public void IsGoalAchieved()
    {
        if (StageManager.Instance.MinUnlockLevel > 12)
        {
            hiddenGo.SetActive(true);
        }
    }

    public void HiddenStageKey(GameObject go)
    {
        go.SetActive(false);

        SoundManager.Instance.PlaySFX(SfxType.Coin);

        curKey++;
        if (curKey == maxKey)
        {
            Debug.Log("hidden!!");
        }
    }
}
