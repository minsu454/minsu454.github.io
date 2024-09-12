using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    /// <summary>
    /// Pause버튼 함수
    /// </summary>
    public void PauseBtn()
    {
        Time.timeScale = 0f;
        GameManager.Instance.settingUI.SetActive(true);
    }
}
