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
        TitleManager.Instance.StartSceneUI(showTitle);
    }
}
