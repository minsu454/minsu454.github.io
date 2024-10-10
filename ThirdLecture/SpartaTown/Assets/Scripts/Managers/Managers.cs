using UnityEngine;
using UnityEngine.SceneManagement;

public class Managers : MonoBehaviour
{
    private static Managers instance;
    public static Managers Instance { get { return instance; } }

    public static EventManager Event { get { return Instance.eventManager; } }
    public static CameraManager Camera { get { return Instance.cameraManager; } }
    public static SceneManagerEx Scene { get { return Instance.sceneManager; } }

    private CameraManager cameraManager;
    private EventManager eventManager = new EventManager();
    private SceneManagerEx sceneManager = new SceneManagerEx();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Init()
    {
        GameObject managers = new GameObject("Managers");
        instance = managers.AddComponent<Managers>();
        DontDestroyOnLoad(managers);

        GameObject cameraManager = new GameObject("CameraManager");
        cameraManager.transform.parent = managers.transform;
        instance.cameraManager = cameraManager.AddComponent<CameraManager>();

        Camera.Init();
    }

    private void Update()
    {
        Camera.OnUpdate();
    }
}
