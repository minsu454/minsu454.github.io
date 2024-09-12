using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{
    /// <summary>
    /// LoadScene���ִ� �Լ�
    /// </summary>
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    /// <summary>
    /// LoadScene���ִ� �Լ�(���� ���� ������ stage ����)
    /// </summary>
    public void LoadScene(int value)
    {
        StageManager.Instance.stageLevel = value;

        LoadScene("MainScene");
    }

    /// <summary>
    /// �÷��� ���� ������ ���������� �Ѿ�� �Լ�
    /// </summary>
    public void NextLevelLoadScene()
    {
        StageManager.Instance.stageLevel++;

        LoadScene("MainScene");
    }
}
