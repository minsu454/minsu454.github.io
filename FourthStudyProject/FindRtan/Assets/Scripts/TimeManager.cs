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

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Update()
    {
        if (time <= 0)
        {
            time = 0;

            GameManager.Instance.EndGame();
        }
        else
        {
            time -= Time.deltaTime;
        }

        timeTxt.text = time.ToString("N2");
    }

    public void SetTime(float time)
    {
        this.time = time;
    }
}
