using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections.Generic;

public class TitleManager : MonoBehaviour
{
    public static TitleManager Instance;

    [Header("UI")]
    public GameObject titleUI;
    public GameObject stageChoiceUI;
    public List<StageUI> stageUIList = new List<StageUI>();

    public Animator rtan1Anim;
    public Animator rtan2Anim;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1f;

        StageChoiceLockUI();
    }

    public void StageChoiceLockUI()
    {
        for (int i = 0; i < StageManager.Instance.MinUnlockLevel; i++)
        {
            stageUIList[i].SetUnlock(true);
        }
    }

    public void StartSceneUI(bool active)
    {
        titleUI.SetActive(active);
        stageChoiceUI.SetActive(!active);
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
