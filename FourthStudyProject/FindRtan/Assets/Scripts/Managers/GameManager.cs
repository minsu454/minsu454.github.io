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

    [Header("Card")]
    public Card firstCard;
    public Card secondCard;

    [Header("UI")]
    public GameObject stageUI;
    public GameObject settingUI;
    public Text stageTxt;
    public GameObject GameOverUI;
    public GameObject GameClearUI;

    [Header("Board")]
    public Board board;

    public int cardCount = 0;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1f;

        SetStage();
    }

    public void SetStage()
    {
        Stage nowStage = StageManager.Instance.GetStage();

        if ((nowStage.type & BossType.Shuffle) != 0)
        {
            TimeManager.Instance.SetTime(nowStage.time, true);
        }
        else
        {
            TimeManager.Instance.SetTime(nowStage.time);
        }

        if ((nowStage.type & BossType.Shuffle) != 0)
        {
        }
        else
        {
        }


        board.SetCardCount(nowStage.cardMax);
        cardCount = nowStage.cardMax;

        stageTxt.text = $"{stageTxt.text}{nowStage.level}";
    }

    public void Matched()
    {
        if (firstCard.idx == secondCard.idx)
        {
            SoundManager.Instance.PlaySFX(SfxType.Match);

            firstCard.DestoryCard();
            secondCard.DestoryCard();
            cardCount -= 2;

            if (cardCount == 0)
            {
                GameClear();
            }
        }
        else
        {
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        firstCard = null;
        secondCard = null;
    }

    public void GameOver()
    {
        GameOverUI.SetActive(true);
    }

    public void GameClear()
    {
        Time.timeScale = 0f;
        GameClearUI.SetActive(true);

        if (StageManager.Instance.IsMyLevelHighest())
        {
            StageManager.Instance.SetHighPlayLevel();
            Debug.Log("NextLevel");
        }
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
