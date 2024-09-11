using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageUI : MonoBehaviour
{
    public GameObject lockGo;
    public GameObject btnGo;

    public void SetUnlock(bool value)
    {
        lockGo.SetActive(!value);
        btnGo.SetActive(value);
    }
}
