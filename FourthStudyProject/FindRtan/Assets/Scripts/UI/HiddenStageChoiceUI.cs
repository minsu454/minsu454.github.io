using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenStageChoiceUI : MonoBehaviour
{
    public GameObject stageChoiceUI;        //stageChoiceUI
    public GameObject balls;                //아래움직이는 ball들 묶어논 obj

    public Animator HiddenUIAnim;           //UI Anim

    private void OnEnable()
    {
        balls.SetActive(true);
    }

    /// <summary>
    /// HiddenstageUI -> stageChoiceUI 전환 애니메이션 함수
    /// </summary>
    public void PlayAnim()
    {
        stageChoiceUI.transform.position = new Vector3(Screen.width / 2, Screen.height / 2);
        stageChoiceUI.SetActive(true);
        balls.SetActive(false);

        HiddenUIAnim.SetBool("isMove", true);
    }

    /// <summary>
    /// 변환완료된 함수
    /// </summary>
    public void AnimOnComplete()
    {
        gameObject.SetActive(false);
        HiddenUIAnim.SetBool("isMove", false);
    }
}
