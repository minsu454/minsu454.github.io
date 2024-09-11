using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;

    public Text timeTxt;
    private float time = 0f;

    private float curCheckTime = 10f;
    private float maxcheckTime = 10f;
    private bool isShuffle;

    public bool isStart = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Update()
    {
        if (!isStart) return;

        if (time <= 0)
        {
            time = 0;

            GameManager.Instance.GameOver();
        }
        else
        {
            if (isShuffle)
            {
                if (curCheckTime <= 0)
                {
                    time = Mathf.Ceil(time);
                    curCheckTime = maxcheckTime;

                    isStart = false;
                    GameManager.Instance.board.ShuffleCard();
                }
                curCheckTime -= Time.deltaTime;
            }
            
            time -= Time.deltaTime;
        }

        timeTxt.text = time.ToString("N2");
    }

    public void SetTime(float time, bool isShuffle = false)
    {
        this.time = time;
        this.isShuffle = isShuffle;
    }
}
