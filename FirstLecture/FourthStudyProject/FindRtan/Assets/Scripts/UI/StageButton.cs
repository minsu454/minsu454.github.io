using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageButton : MonoBehaviour
{
    public GameObject lockGo;       //자물쇠 이미지 obj
    public GameObject btnGo;        //실질적인 버튼 obj

    /// <summary>
    /// 잠금 해제 설정 함수
    /// </summary>
    public void SetUnlock(bool value)
    {
        lockGo.SetActive(!value);
        btnGo.SetActive(value);
    }
}
