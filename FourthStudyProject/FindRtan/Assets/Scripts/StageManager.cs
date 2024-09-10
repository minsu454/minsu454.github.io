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
        Stage st1 = new Stage(16, 30);
    }

    public Stage GetStage()
    {
        return stageList[stageLevel];
    }

}
