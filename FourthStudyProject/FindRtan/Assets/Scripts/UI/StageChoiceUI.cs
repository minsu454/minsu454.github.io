using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class StageChoiceUI : MonoBehaviour
{
    public GameObject hiddenUI;
    public GameObject hiddenMissionGo;

    public Animator StageChoiceAnim;

    private RectTransform rect;

    public List<GameObject> hiddenBtnList = new List<GameObject>();

    public List<StageUI> stageUIList = new List<StageUI>();

    private int curKey = 0;
    private int maxKey = 4;

    private void OnEnable()
    {
        foreach (var btn in hiddenBtnList)
        {
            btn.SetActive(true);
        }
        curKey = 0;
    }

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Start()
    {
        StageChoiceLockUI();
        IsGoalAchieved();
    }

    public void HiddenUI()
    {
        hiddenUI.transform.position = new Vector3(Screen.width / 2, Screen.height / 2);
        hiddenUI.SetActive(true);
        gameObject.SetActive(false);
    }

    public void HiddenMoveUI()
    {
        HiddenUI();
        StageChoiceAnim.SetBool("isMove", false);
    }

    public void HiddenStageKey(GameObject go)
    {
        go.SetActive(false);

        SoundManager.Instance.PlaySFX(SfxType.Coin);

        curKey++;
        if (curKey == maxKey)
        {
            StageChoiceAnim.SetBool("isMove", true);
            curKey = 0;
        }
    }

    public void IsGoalAchieved()
    {
        if (StageManager.Instance.MinUnlockLevel > 12)
        {
            hiddenMissionGo.SetActive(true);
        }
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
