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

    public Card firstCard;
    public Card secondCard;

    public GameObject endTxt;
    public GameObject titleUI;
    public GameObject stageChoiceUI;

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

        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            Stage nowStage = StageManager.Instance.GetStage();

            TimeManager.Instance.SetTime(nowStage.time);
        }
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
                EndGame();
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

    public void EndGame()
    {
        Time.timeScale = 0f;
        endTxt.SetActive(true);
    }

    public void StartSceneUI(bool active)
    {
        titleUI.SetActive(active);
        stageChoiceUI.SetActive(!active);
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
