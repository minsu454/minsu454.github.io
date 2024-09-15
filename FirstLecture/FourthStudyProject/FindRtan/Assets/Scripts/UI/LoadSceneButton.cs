using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{
    /// <summary>
    /// LoadScene해주는 함수
    /// </summary>
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    /// <summary>
    /// LoadScene해주는 함수(현재 내가 선택한 stage 저장)
    /// </summary>
    public void LoadScene(int value)
    {
        StageManager.Instance.stageLevel = value;

        LoadScene("MainScene");
    }

    /// <summary>
    /// 플레이 중인 레벨에 다음레벨로 넘어가는 함수
    /// </summary>
    public void NextLevelLoadScene()
    {
        StageManager.Instance.stageLevel++;

        LoadScene("MainScene");
    }
}
