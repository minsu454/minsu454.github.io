using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public static TitleManager Instance;

    public GameObject titleUI;
    public GameObject stageChoiceUI;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void StartSceneUI(bool active)
    {
        titleUI.SetActive(active);
        stageChoiceUI.SetActive(!active);
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
