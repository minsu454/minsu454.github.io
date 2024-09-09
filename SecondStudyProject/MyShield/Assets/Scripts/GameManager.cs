using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject square;
    public Text timeTxt;
    public Text nowScoreTxt;
    public Text bestScoreTxt;
    public GameObject endPanel;

    private string key = "bestScore";

    private bool isPlay = true;

    private float time = 0f;
    //private float nowScore = 0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        InvokeRepeating(nameof(MakeSquare), 0f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlay)
        {
            time += Time.deltaTime;

            timeTxt.text = time.ToString("N2");
        }
    }

    private void MakeSquare()
    {
        Instantiate(square);
    }

    public void GameOver()
    {
        isPlay = false;
        Time.timeScale = 0f;
        nowScoreTxt.text = time.ToString("N2");

        if (PlayerPrefs.HasKey(key))
        {
            float best = PlayerPrefs.GetFloat(key);
            if (best < time)
            {
                PlayerPrefs.SetFloat(key, time);
                bestScoreTxt.text = time.ToString("N2");
            }
            else
            {
                bestScoreTxt.text = best.ToString("N2");
            }
        }
        else
        {
            PlayerPrefs.SetFloat(key, time);
            bestScoreTxt.text = time.ToString("N2");
        }

        endPanel.SetActive(true);
    }
}
