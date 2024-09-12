using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;

    public Text timeTxt;            //�ð�UI
    private float time = 0f;        //�����ð� ����

    public bool isStart = false;        //���� �������� �˷��ִ� ����

    private bool isShuffle;             //�����ϴ��� ��Ÿ���ִ� ����
    private float curCheckTime = 10f;   //���� �ð� üũ�� ����ϴ� ���� ���� �ð� ����
    private float maxcheckTime = 10f;   //���� �ð� üũ�� ���� ���� �ð� �ʱ�ȭ�� ����

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
    /// �ð� üũ �Լ�
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
    /// ���� ���� �ð� �� ���� �������ִ� �Լ�
    /// </summary>
    public void SetTime(float time, bool isShuffle = false)
    {
        this.time = time;
        this.isShuffle = isShuffle;
    }
}
