using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenStageChoiceUI : MonoBehaviour
{
    public GameObject stageChoiceUI;        //stageChoiceUI
    public GameObject balls;                //�Ʒ������̴� ball�� ����� obj

    public Animator HiddenUIAnim;           //UI Anim

    private void OnEnable()
    {
        balls.SetActive(true);
    }

    /// <summary>
    /// HiddenstageUI -> stageChoiceUI ��ȯ �ִϸ��̼� �Լ�
    /// </summary>
    public void PlayAnim()
    {
        stageChoiceUI.transform.position = new Vector3(Screen.width / 2, Screen.height / 2);
        stageChoiceUI.SetActive(true);
        balls.SetActive(false);

        HiddenUIAnim.SetBool("isMove", true);
    }

    /// <summary>
    /// ��ȯ�Ϸ�� �Լ�
    /// </summary>
    public void AnimOnComplete()
    {
        gameObject.SetActive(false);
        HiddenUIAnim.SetBool("isMove", false);
    }
}
