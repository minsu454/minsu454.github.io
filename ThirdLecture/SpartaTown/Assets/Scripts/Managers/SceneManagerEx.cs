using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SceneManagerEx
{
    private readonly Dictionary<SceneType, string> typeToStringDic = new Dictionary<SceneType, string>();

    public void LoadScene(SceneType type)
    {
        SceneManager.LoadScene(GetSceneName(type));

        Managers.Event.Dispatch(GameEventType.ChangeScene, null);
    }

    private string GetSceneName(SceneType type)
    {
        if (!typeToStringDic.TryGetValue(type, out string name))
        {
            name = type.ToString();
            typeToStringDic[type] = name;
        }

        return name;
    }
}
