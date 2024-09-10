using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadScene(int stageNum)
    {
        StageManager.Instance.stageLevel = stageNum;

        LoadScene("MainScene");
    }



    public void ChangeStartSceneUI(bool showTitle)
    {
        if (showTitle)
        {
            TitleManager.Instance.rtan2Anim.SetBool("isMove", true);
        }
        else
        {
            TitleManager.Instance.StartSceneUI(showTitle);
        }
        
    }

    public void RtanMoveUI()
    {
        TitleManager.Instance.StartSceneUI(true);
        TitleManager.Instance.rtan2Anim.SetBool("isMove", false);
    }
}
