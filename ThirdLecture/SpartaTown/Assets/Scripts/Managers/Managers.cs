using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers instance;
    public static Managers Instace { get { return instance; } }

    public static CameraManager Camera { get { return Camera; } }

    private CameraManager camera;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Init()
    {
        GameObject managers = new GameObject("Managers");
        instance = managers.AddComponent<Managers>();
        DontDestroyOnLoad(managers);

        GameObject cameraManager = new GameObject("CameraManager");
        instance.camera = cameraManager.AddComponent<CameraManager>();
    }
}
