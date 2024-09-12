using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.Rendering.DebugUI;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;

    private List<Stage> stageList = new List<Stage>();  //��� Stage ��Ƶδ� List

    public int stageLevel = -1;                         //���� �÷������� �������� ���� ����

    private int maxUnlockLevel = 1;                     //���� �ر��� �ִ뷹��
    public int MaxUnlockLevel                           //maxUnlockLevel getter
    {
        get { return maxUnlockLevel; }
    }

    private string keyCode = "Rtan";                    //PlayerPrefs ���� keyCode

    /// <summary>
    /// StageManager���������ִ� �Լ�
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
    /// �������� �������ִ� �Լ�
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
    /// ���� �÷����� level�� �ְ������� üũ, ��ȯ���ִ� �Լ�
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
    /// ����Ǿ� �ִ� �� �ְ� �ر� �� �������ִ� �Լ�
    /// </summary>
    public void SetHighLevelData()
    {
        maxUnlockLevel++;
        PlayerPrefs.SetInt(keyCode, maxUnlockLevel);
    }

    /// <summary>
    /// ����Ǿ� �ִ� �� �ְ� �ر� �� �������� �Լ�
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
    /// �������� �� ���� �Լ�(DB�� ���������Ʈ�� ��ȯ)
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
    /// �������� �����ϴ� �Լ�
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
    /// �������� ��ȯ���ִ� �Լ�
    /// </summary>
    public Stage GetStage()
    {
        if (stageLevel == -1)
            return stageList[0];

        return stageList[stageLevel];
    }
}
