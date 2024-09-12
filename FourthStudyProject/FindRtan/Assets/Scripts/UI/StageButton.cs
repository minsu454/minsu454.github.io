using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageButton : MonoBehaviour
{
    public GameObject lockGo;       //�ڹ��� �̹��� obj
    public GameObject btnGo;        //�������� ��ư obj

    /// <summary>
    /// ��� ���� ���� �Լ�
    /// </summary>
    public void SetUnlock(bool value)
    {
        lockGo.SetActive(!value);
        btnGo.SetActive(value);
    }
}
