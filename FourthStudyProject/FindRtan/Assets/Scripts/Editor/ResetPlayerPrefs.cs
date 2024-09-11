using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ResetPlayerPrefs
{
    [MenuItem("Tools/PlayerPrefs/Reset")]
    private static void Reset()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("PlayerPrefs is Reset.");
    }

    [MenuItem("Tools/PlayerPrefs/Skip")]
    private static void Skip()
    {
        PlayerPrefs.SetInt("Rtan", 12);
        Debug.Log("Stage Skip.");
    }

    [MenuItem("Tools/PlayerPrefs/StageAllClear")]
    private static void StageAllClear()
    {
        PlayerPrefs.SetInt("Rtan", 100);
        Debug.Log("Stage All Clear.");
    }
}
