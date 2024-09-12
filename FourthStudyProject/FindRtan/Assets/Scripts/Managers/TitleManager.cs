using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections.Generic;

public class TitleManager : MonoBehaviour
{
    public static TitleManager Instance;

    [Header("UI")]
    public GameObject titleUI;          //titleUI
    public StageChoiceUI stageChoiceUI; //stageChoiceUI

    public Animator rtan1Anim;          //레탄1 애니메이션 저장
    public Animator rtan2Anim;          //레탄2 애니메이션 저장

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1f;
        SoundManager.Instance.PlayBGM(BgmType.Bgmusic);
    }

    /// <summary>
    /// titleUI <-> stageChoiceUI 화면변환 시켜주는 버튼
    /// </summary>
    public void ChangeUIBtn(bool showTitle)
    {
        if (showTitle)
        {
            rtan2Anim.SetBool("isMove", true);
        }
        else
        {
            rtan1Anim.SetBool("isMove", true);
        }
    }

    /// <summary>
    /// titleUI <-> stageChoiceUI 화면변환 시켜주는 함수
    /// </summary>
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
