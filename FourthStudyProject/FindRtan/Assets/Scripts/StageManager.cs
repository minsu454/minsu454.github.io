using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;

    private List<Stage> stageList = new List<Stage>();

    public int stageLevel = -1;

    private int minUnlockLevel = 1;
    public int MinUnlockLevel
    {
        get { return minUnlockLevel; }
    }

    public bool isTest = false;
    public int testHighestLevel = 5;

    private string keyCode = "Rtan";

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void init()
    {
        GameObject go = new GameObject("StageManager");
        Instance = go.AddComponent<StageManager>();

        DontDestroyOnLoad(go);
    }

    public void Awake()
    {
        AddStage(4, 10);
        AddStage(8, 25);
        AddStage(8, 15);

        AddStage(12, 40);
        AddStage(12, 30);
        AddStage(12, 20);

        AddStage(16, 60);
        AddStage(16, 40);
        AddStage(16, 30);

        AddStage(24, 50);
        AddStage(24, 35);
        AddStage(24, 25);

        GetHighPlayLevel();
    }

    public bool IsMyLevelHighest()
    {
        if (stageLevel + 1 >= minUnlockLevel)
        {
            return true;
        }
        return false;
    }

    public void SetHighPlayLevel()
    {
        minUnlockLevel++;
        PlayerPrefs.SetInt(keyCode, minUnlockLevel);
    }

    public void SetHighPlayLevel(int value)
    {
        minUnlockLevel = value;
        PlayerPrefs.SetInt(keyCode, value);
    }

    private void GetHighPlayLevel()
    {
        if (isTest)
        {
            minUnlockLevel = testHighestLevel;
            return;
        }

        if (!PlayerPrefs.HasKey(keyCode))
        {
            Debug.Log($"is not keyCode : {keyCode}");
            return;
        }

        minUnlockLevel = PlayerPrefs.GetInt(keyCode);
    }

    public void AddStage(int cardMax, float Time)
    {
        Stage st1 = new Stage(cardMax, Time);

        stageList.Add(st1);
    }

    public Stage GetStage()
    {
        if (stageLevel == -1)
            return stageList[0];

        return stageList[stageLevel];
    }

}
