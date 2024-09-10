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

    #region Title
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
    #endregion

    #region InGame
    public void PauseBtnUI()
    {
        Time.timeScale = 0f;
        GameManager.Instance.settingUI.SetActive(true);
    }

    public void CloseBtnUI()
    {
        GameManager.Instance.settingUI.SetActive(false);
        Time.timeScale = 1f;
    }
    #endregion
}
