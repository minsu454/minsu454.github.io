using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject normalCat;
    public GameObject retryBtn;

    public Text levelTxt;
    public RectTransform levelFront;

    private int level = 0;
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

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MakeCat()
    {
        Instantiate(normalCat);
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
