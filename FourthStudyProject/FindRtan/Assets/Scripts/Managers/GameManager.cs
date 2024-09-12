using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI")]
    public Text stageTxt;               //몇 stage인지 보여주는 UI
    public GameObject settingUI;        //설정시 나타나는 UI
    public GameObject GameOverUI;       //게임 오버시 나타나는 UI
    public GameObject GameClearUI;      //게임 클리어시 나타나는 UI

    [Header("Board")]
    public Board board;         //게임 보드 변수

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1f;

        StageManager.Instance.SetStage();
    }

    /// <summary>
    /// 게임오버 함수
    /// </summary>
    public void GameOver()
    {
        GameOverUI.SetActive(true);
    }

    /// <summary>
    /// 게임클리어 함수
    /// </summary>
    public void GameClear()
    {
        Time.timeScale = 0f;
        GameClearUI.SetActive(true);

        if (StageManager.Instance.IsMyLevelHighest())
        {
            StageManager.Instance.SetHighLevelData();
            Debug.Log("NextLevel");
        }
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
