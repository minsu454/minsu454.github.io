using UnityEngine;
using UnityEngine.SceneManagement;

public class Managers : MonoBehaviour
{
    private static Managers instance;

    #region No MonoBehaviour
    public static EventManager Event { get { return instance.eventManager; } }
    public static SceneManagerEx Scene { get { return instance.sceneManager; } }
    public static DataService Data { get { return instance.dataScrvice; } }

    private readonly EventManager eventManager = new EventManager();
    private readonly SceneManagerEx sceneManager = new SceneManagerEx();
    private readonly DataService dataScrvice = new DataService();
    #endregion

    #region MonoBehaviour
    public static CameraManager Camera { get { return instance.cameraManager; } }
    public static PopupManager Popup { get { return instance.popupManager; } }

    private CameraManager cameraManager;
    private PopupManager popupManager;
    #endregion

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void Init()
    {
        GameObject managers = new GameObject("Managers");
        instance = managers.AddComponent<Managers>();
        DontDestroyOnLoad(managers);

        instance.cameraManager = instance.CreateManager<CameraManager>("CameraManager", managers.transform);
        instance.popupManager = instance.CreateManager<PopupManager>("PopupManager", managers.transform);

        Camera.Init();
        Popup.Init();

        Data.Init();
    }

    private void LateUpdate()
    {
        Camera.OnLateUpdate?.Invoke();
    }

    private T CreateManager<T>(string name, Transform parent = null) where T : MonoBehaviour
    {
        GameObject manager = new GameObject(name);
        if(parent != null)
            manager.transform.parent = parent;

        return manager.AddComponent<T>();
    }
}
