using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject normalCat;
    public GameObject fatCat;
    public GameObject pirateCat;

    public GameObject retryBtn;

    public Text levelTxt;
    public RectTransform levelFront;

    private int level = 4;
    private int score = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        Application.targetFrameRate = 60;
        Time.timeScale = 1.0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(MakeCat), 0f, 1f);
    }

    private void MakeCat()
    {
        Instantiate(normalCat);

        if (level == 1)
        {
            int p = Random.Range(0, 10);
            if(p < 2) Instantiate(normalCat);
        }
        else if (level == 2)
        {
            int p = Random.Range(0, 10);
            if (p < 5) Instantiate(normalCat);
        }
        else if (level >= 3)
        {
            Instantiate(fatCat);
        }

        if (level >= 4)
        {
            Instantiate(pirateCat);
        }
    }

    public void GameOver()
    {
        retryBtn.SetActive(true);
        Time.timeScale = 0f;
    }

    public void AddScore()
    {
        score++;
        level = score / 5;
        levelTxt.text = level.ToString();
        levelFront.localScale = new Vector3((score - level * 5) / 5f, 1, 1);
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
