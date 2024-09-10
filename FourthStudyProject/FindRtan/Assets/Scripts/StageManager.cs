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
        AddStage(16, 30);
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
