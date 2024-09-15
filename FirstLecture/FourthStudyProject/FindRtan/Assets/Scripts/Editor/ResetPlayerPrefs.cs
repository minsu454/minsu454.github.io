using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ResetPlayerPrefs
{
    /// <summary>
    /// PlayerPrefs초기화 함수
    /// </summary>
    [MenuItem("Tools/PlayerPrefs/Reset")]
    private static void Reset()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("PlayerPrefs is Reset.");
    }

    /// <summary>
    /// 보스 x까지 스킵시켜주는 함수
    /// </summary>
    [MenuItem("Tools/PlayerPrefs/Skip/GoToX")]
    private static void SkipX()
    {
        PlayerPrefs.SetInt("Rtan", 13);
        Debug.Log("Stage Skip.");
    }

    /// <summary>
    /// 보스 y까지 스킵시켜주는 함수
    /// </summary>
    [MenuItem("Tools/PlayerPrefs/Skip/GoToY")]
    private static void SkipY()
    {
        PlayerPrefs.SetInt("Rtan", 14);
        Debug.Log("Stage Skip.");
    }

    /// <summary>
    /// 보스 z까지 스킵시켜주는 함수
    /// </summary>
    [MenuItem("Tools/PlayerPrefs/Skip/GoToZ")]
    private static void SkipZ()
    {
        PlayerPrefs.SetInt("Rtan", 15);
        Debug.Log("Stage Skip.");
    }

    /// <summary>
    /// 모두 클리어 함수
    /// </summary>
    [MenuItem("Tools/PlayerPrefs/StageAllClear")]
    private static void StageAllClear()
    {
        PlayerPrefs.SetInt("Rtan", 100);
        Debug.Log("Stage All Clear.");
    }
}
