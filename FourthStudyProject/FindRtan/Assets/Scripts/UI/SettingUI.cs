using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingUI : MonoBehaviour
{
    /// <summary>
    /// ����UI �ݾ��ִ� ��ư
    /// </summary>
    public void CloseBtn()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
