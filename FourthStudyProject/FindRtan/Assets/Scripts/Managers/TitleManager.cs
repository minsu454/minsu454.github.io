using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections.Generic;

public class TitleManager : MonoBehaviour
{
    public static TitleManager Instance;

    [Header("UI")]
    public GameObject titleUI;
    public StageChoiceUI stageChoiceUI;

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
    }

    public void StartSceneUI(bool active)
    {
        titleUI.SetActive(active);
        stageChoiceUI.gameObject.SetActive(!active);
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
