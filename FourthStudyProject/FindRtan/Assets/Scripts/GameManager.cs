using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Card firstCard;
    public Card secondCard;

    public Text timeTxt;
    public GameObject endTxt;

    private AudioSource audioSource;
    public AudioClip clip;

    public int cardCount = 0;

    private float time = 0f;
    private float endTime = 30f;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1f;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (time >= endTime)
        {
            time = endTime;

            EndGame();
        }
        else
        {
            time += Time.deltaTime;
        }

        timeTxt.text = time.ToString("N2");
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

    private void OnDestroy()
    {
        Instance = null;
    }
}
