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

    public void LoadScene(int value)
    {
        StageManager.Instance.stageLevel = value;

        LoadScene("MainScene");
    }

    public void NextLevelLoadScene()
    {
        StageManager.Instance.stageLevel++;

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
            TitleManager.Instance.rtan1Anim.SetBool("isMove", true);
        }
        
    }

    public void Rtan1MoveUI()
    {
        TitleManager.Instance.StartSceneUI(false);
        TitleManager.Instance.rtan1Anim.SetBool("isMove", false);
    }

    public void Rtan2MoveUI()
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
