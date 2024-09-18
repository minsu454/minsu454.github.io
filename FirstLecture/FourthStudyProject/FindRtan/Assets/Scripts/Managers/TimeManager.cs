using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;

    public Text timeTxt;            //시간UI
    private float time = 0f;        //남은시간 변수

    public bool isStart = false;        //게임 시작인지 알려주는 변수

    private bool isShuffle;             //셔플하는지 나타내주는 변수
    private float curCheckTime = 10f;   //셔플 시간 체크시 사용하는 현재 남은 시간 변수
    private float maxcheckTime = 10f;   //셔플 시간 체크시 현재 남은 시간 초기화용 변수

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Update()
    {
        if (!isStart) return;

        CheckTime();
    }

    /// <summary>
    /// 시간 체크 함수
    /// </summary>
    private void CheckTime()
    {
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

    /// <summary>
    /// 시작 전에 시간 및 셔플 설정해주는 함수
    /// </summary>
    public void SetTime(float time, bool isShuffle = false)
    {
        this.time = time;
        this.isShuffle = isShuffle;
    }
}
