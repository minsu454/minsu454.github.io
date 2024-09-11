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
}
