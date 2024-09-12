using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.Rendering.DebugUI;

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
        AddStage(1, 4, 10);
        AddStage(2, 8, 25);
        AddStage(3, 8, 15);

        AddStage(4, 12, 40);
        AddStage(5, 12, 30);
        AddStage(6, 12, 20);

        AddStage(7, 16, 60);
        AddStage(8, 16, 40);
        AddStage(9, 16, 25);

        AddStage(10, 24, 50);
        AddStage(11, 24, 40);
        AddStage(12, 24, 30);

        AddStage(13, 24, 50, BossType.Shuffle);
        AddStage(14, 16, 50, BossType.Same);
        AddStage(15, 16, 50, BossType.ImageError);

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

    public void AddStage(int level, int cardMax, float Time, BossType type = BossType.None)
    {
        if (stageList.Count != level - 1)
        {
            Debug.Log("Before Level is None.");
            return;
        }

        Stage st1 = new Stage(level, cardMax, Time, type);

        stageList.Add(st1);
    }

    public Stage GetStage()
    {
        if (stageLevel == -1)
            return stageList[0];

        return stageList[stageLevel];
    }

    public bool IsContainFlag(BossType type, BossType value)
    {
        return (type & value) != 0;
    }

}
