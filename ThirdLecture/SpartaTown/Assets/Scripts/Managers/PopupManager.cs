using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopupManager : MonoBehaviour
{
    private readonly Dictionary<PopupType, GameObject> popupContainerDic = new Dictionary<PopupType, GameObject>();
    private readonly Stack<GameObject> depth = new Stack<GameObject>();

    private Transform mainCanvas;

    public void Init()
    {
        foreach (PopupType type in Enum.GetValues(typeof(PopupType)))
        {
            GameObject go = Resources.Load<GameObject>(string.Format($"Prefabs/Popup/{type.ToString()}"));
            popupContainerDic.Add(type, go);
        }

        Managers.Scene.OnLoadCompleted(FindMainCanvas);
        Managers.Scene.OnLoadCompleted(ResetPopup);
    }

    public void FindMainCanvas(Scene scene, LoadSceneMode mode)
    {
        GameObject mainCanvasObj = GameObject.Find("MainCanvas");
        if (mainCanvasObj == null)
        {
            Debug.LogError("Is Not MainCanvas.");
            return;
        }

        mainCanvas = mainCanvasObj.transform;
    }

    public void ResetPopup(Scene scene, LoadSceneMode mode)
    {
        depth.Clear();
    }

    public BasePopup CreatePopup(PopupType type, bool active = true)
    {
        if (!popupContainerDic.TryGetValue(type, out GameObject popupGo))
        {
            Debug.LogError("Is Not BasePopup : popupContainerDic");
            return null;
        }

        GameObject clone = Instantiate(popupGo, mainCanvas);

        if (depth.TryPeek(out GameObject go) && active)
        {
            go.SetActive(false);
        }

        depth.Push(clone);

        BasePopup popup = clone.GetComponent<BasePopup>();

        return popup;
    }

    public void Close()
    {
        if (depth.Count == 0)
        {
            return;
        }

        depth.Pop();

        if (depth.TryPeek(out GameObject go))
        {
            go.SetActive(true);
        }
    }
}
