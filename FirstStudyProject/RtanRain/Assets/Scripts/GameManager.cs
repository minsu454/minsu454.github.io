using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject rain;
    public GameObject endPanel;

    public Text totalScoreTxt;
    public Text totalTimeTxt;

    private int totalScore = 0;
    private float totalTime = 30f;

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(MakeRain), 0f, 1f);
    }

    private void Update()
    {
        if (totalTime > 0)
        {
            totalTime -= Time.deltaTime;
        }
        else
        {
            totalTime = 0;
            Time.timeScale = 0f;

            endPanel.SetActive(true);
        }

        totalTimeTxt.text = totalTime.ToString("N2");
    }

    private void MakeRain()
    {
        Instantiate(rain);
    }

    public void AddScore(int score)
    {
        totalScore += score;
        totalScoreTxt.text = totalScore.ToString();
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
