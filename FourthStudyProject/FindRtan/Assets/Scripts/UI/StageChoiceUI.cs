using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class StageChoiceUI : MonoBehaviour
{
    public GameObject hiddenUI;         //hiddenUI
    public GameObject hiddenMissionGo;  //����UI�� �������� �̼� �Ѱ� ������Ʈ

    public Animator StageChoiceAnim;

    public List<GameObject> hiddenBtnList = new List<GameObject>();

    public List<StageButton> stageUIList = new List<StageButton>();

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

    private void Start()
    {
        StageChoiceLockUI();
        IsGoalAchieved();
    }

    /// <summary>
    /// HiddenstageUI -> stageChoiceUI ��ȯ �ִϸ��̼� �Լ�
    /// </summary>
    public void PlayAnim()
    {
        if (curKey == maxKey)
        {
            StageChoiceAnim.SetBool("isMove", true);
            curKey = 0;
        }
    }

    /// <summary>
    /// ��ȯ �Ϸ�� �Լ�
    /// </summary>
    public void AnimOnComplete()
    {
        hiddenUI.transform.position = new Vector3(Screen.width / 2, Screen.height / 2);
        hiddenUI.SetActive(true);
        gameObject.SetActive(false);

        StageChoiceAnim.SetBool("isMove", false);
    }

    /// <summary>
    /// ����� �������� �Է� ��ư
    /// </summary>
    public void HiddenStageKey(GameObject go)
    {
        go.SetActive(false);

        SoundManager.Instance.PlaySFX(SfxType.Coin);

        curKey++;

        PlayAnim();
    }

    /// <summary>
    /// �⺻�������� ���� Ŭ���������� hidden��ư Ȱ��ȭ �����ִ� �Լ�
    /// </summary>
    public void IsGoalAchieved()
    {
        if (StageManager.Instance.MaxUnlockLevel > 12)
        {
            hiddenMissionGo.SetActive(true);
        }
    }

    /// <summary>
    /// ���� �ر��� �ִ뷹���� �°� UI �������ִ� �Լ�
    /// </summary>
    public void StageChoiceLockUI()
    {
        for (int i = 0; i < StageManager.Instance.MaxUnlockLevel; i++)
        {
            if (stageUIList.Count <= i)
                break;

            stageUIList[i].SetUnlock(true);
        }
    }
}
