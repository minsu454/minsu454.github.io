using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenStageChoiceUI : MonoBehaviour
{
    public GameObject stageChoiceUI;

    public Animator HiddenUIAnim;

    public void GoToStageChoiceUI()
    {
        StageChoiceUI();
        HiddenUIAnim.SetBool("isMove", false);
    }

    private void StageChoiceUI()
    {
        gameObject.SetActive(false);
    }

    public void HiddenMoveUI()
    {
        stageChoiceUI.transform.position = new Vector3(Screen.width / 2, Screen.height / 2);
        stageChoiceUI.SetActive(true);

        HiddenUIAnim.SetBool("isMove", true);
    }
}
