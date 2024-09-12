using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.Rendering.DebugUI;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;

    private List<Stage> stageList = new List<Stage>();  //모든 Stage 담아두는 List

    public int stageLevel = -1;                         //현재 플레이중인 스테이지 레벨 변수

    private int maxUnlockLevel = 1;                     //내가 해금한 최대레벨
    public int MaxUnlockLevel                           //maxUnlockLevel getter
    {
        get { return maxUnlockLevel; }
    }

    private string keyCode = "Rtan";                    //PlayerPrefs 저장 keyCode

    /// <summary>
    /// StageManager생성시켜주는 함수
    /// </summary>
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void init()
    {
        GameObject go = new GameObject("StageManager");
        Instance = go.AddComponent<StageManager>();

        DontDestroyOnLoad(go);
    }

    public void Awake()
    {
        AddStages();

        GetHighLevelData();
    }

    /// <summary>
    /// 스테이지 설정해주는 함수
    /// </summary>
    public void SetStage()
    {
        Stage nowStage = GetStage();

        GameManager.Instance.board.cardCount = nowStage.cardMax;

        if ((nowStage.type & BossType.Shuffle) != 0)
        {
            TimeManager.Instance.SetTime(nowStage.time, true);
        }
        else
        {
            TimeManager.Instance.SetTime(nowStage.time);
        }

        switch (nowStage.type)
        {
            case BossType.Same:
                GameManager.Instance.board.StartGame(BossType.Same);
                break;
            case BossType.ImageError:
                GameManager.Instance.board.StartGame(BossType.ImageError);
                break;
            default:
                GameManager.Instance.board.StartGame();
                break;
        }

        string levelName = string.Empty;

        switch (nowStage.level)
        {
            case 13:
                levelName = $"BossX";
                break;
            case 14:
                levelName = $"BossY";
                break;
            case 15:
                levelName = $"BossZ";
                break;
            default:
                levelName = $"{GameManager.Instance.stageTxt.text}{nowStage.level}";
                break;
        }

        GameManager.Instance.stageTxt.text = levelName;
    }

    /// <summary>
    /// 내가 플레이한 level이 최고레벨인지 체크, 반환해주는 함수
    /// </summary>
    /// <returns></returns>
    public bool IsMyLevelHighest()
    {
        if (stageLevel + 1 >= maxUnlockLevel)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// 저장되어 있는 내 최고 해금 값 설정해주는 함수
    /// </summary>
    public void SetHighLevelData()
    {
        maxUnlockLevel++;
        PlayerPrefs.SetInt(keyCode, maxUnlockLevel);
    }

    /// <summary>
    /// 저장되어 있는 내 최고 해금 값 가져오는 함수
    /// </summary>
    private void GetHighLevelData()
    {
        if (!PlayerPrefs.HasKey(keyCode))
        {
            Debug.Log($"is not keyCode : {keyCode}");
            return;
        }

        maxUnlockLevel = PlayerPrefs.GetInt(keyCode);
    }

    /// <summary>
    /// 스테이지 값 설정 함수(DB나 스프레드시트로 변환)
    /// </summary>
    public void AddStages()
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
    }

    /// <summary>
    /// 스테이지 생성하는 함수
    /// </summary>
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

    /// <summary>
    /// 스테이지 반환해주는 함수
    /// </summary>
    public Stage GetStage()
    {
        if (stageLevel == -1)
            return stageList[0];

        return stageList[stageLevel];
    }
}
