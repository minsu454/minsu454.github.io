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

    public Animator rtan1Anim;          //��ź1 �ִϸ��̼� ����
    public Animator rtan2Anim;          //��ź2 �ִϸ��̼� ����

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
    /// titleUI <-> stageChoiceUI ȭ�麯ȯ �����ִ� ��ư
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
    /// titleUI <-> stageChoiceUI ȭ�麯ȯ �����ִ� �Լ�
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
