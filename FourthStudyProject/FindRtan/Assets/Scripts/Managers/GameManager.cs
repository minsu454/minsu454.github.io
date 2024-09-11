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
    public GameObject endTxt;
    public GameObject stageUI;
    public GameObject settingUI;
    public Text stageTxt;
    public GameObject GameOverUI;

    [Header("Board")]
    public Board board;

    [Header("Audio")]
    private AudioSource audioSource;
    public AudioClip clip;

    public int cardCount = 0;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1f;
        audioSource = GetComponent<AudioSource>();

        Stage nowStage = StageManager.Instance.GetStage();

        Debug.Log($"{nowStage.level} {nowStage.time} {nowStage.cardMax}");

        TimeManager.Instance.SetTime(nowStage.time);
        board.SetCardCount(nowStage.cardMax);
        cardCount = nowStage.cardMax;

        stageTxt.text = $"{stageTxt.text}{nowStage.level}"; 
    }

    public void Matched()
    {
        if (firstCard.idx == secondCard.idx)
        {
            audioSource.PlayOneShot(clip);

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
        endTxt.SetActive(true);

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
