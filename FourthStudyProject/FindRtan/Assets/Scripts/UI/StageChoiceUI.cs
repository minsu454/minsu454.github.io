using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class StageChoiceUI : MonoBehaviour
{
    public GameObject hiddenUI;         //hiddenUI
    public GameObject hiddenMissionGo;  //히든UI로 가기위한 미션 총괄 오브젝트

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
    /// HiddenstageUI -> stageChoiceUI 전환 애니메이션 함수
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
    /// 변환 완료된 함수
    /// </summary>
    public void AnimOnComplete()
    {
        hiddenUI.transform.position = new Vector3(Screen.width / 2, Screen.height / 2);
        hiddenUI.SetActive(true);
        gameObject.SetActive(false);

        StageChoiceAnim.SetBool("isMove", false);
    }

    /// <summary>
    /// 히든방 가기위한 입력 버튼
    /// </summary>
    public void HiddenStageKey(GameObject go)
    {
        go.SetActive(false);

        SoundManager.Instance.PlaySFX(SfxType.Coin);

        curKey++;

        PlayAnim();
    }

    /// <summary>
    /// 기본스테이지 전원 클리어했으면 hidden버튼 활성화 시켜주는 함수
    /// </summary>
    public void IsGoalAchieved()
    {
        if (StageManager.Instance.MaxUnlockLevel > 12)
        {
            hiddenMissionGo.SetActive(true);
        }
    }

    /// <summary>
    /// 내가 해금한 최대레벨에 맞게 UI 세팅해주는 함수
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
