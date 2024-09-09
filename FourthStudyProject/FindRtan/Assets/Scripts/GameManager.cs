using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text timeTxt;
    private float time = 0f;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        timeTxt.text = time.ToString("N2");
    }
}
