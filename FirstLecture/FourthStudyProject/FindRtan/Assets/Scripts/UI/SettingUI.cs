using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingUI : MonoBehaviour
{
    /// <summary>
    /// 세팅UI 닫아주는 버튼
    /// </summary>
    public void CloseBtn()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
