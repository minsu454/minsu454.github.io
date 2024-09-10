using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;

    private List<Stage> stageList = new List<Stage>();

    public int stageLevel = -1;

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
        AddStage(24, 20);
    }

    public void AddStage(int cardMax, float Time)
    {
        Stage st1 = new Stage(cardMax, Time);

        stageList.Add(st1);
    }

    public Stage GetStage()
    {
        return stageList[stageLevel];
    }

}
