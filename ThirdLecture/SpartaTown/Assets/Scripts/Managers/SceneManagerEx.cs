using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneManagerEx
{
    private readonly Dictionary<SceneType, string> typeToStringDic = new Dictionary<SceneType, string>();

    public void LoadScene(SceneType type)
    {
        SceneManager.LoadScene(GetSceneName(type));
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

    public void OnLoadCompleted(UnityAction<Scene, LoadSceneMode> callback)
    {
        SceneManager.sceneLoaded += callback;
    }
}
