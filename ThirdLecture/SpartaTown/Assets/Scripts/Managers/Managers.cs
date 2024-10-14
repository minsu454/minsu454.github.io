using UnityEngine;
using UnityEngine.SceneManagement;

public class Managers : MonoBehaviour
{
    private static Managers instance;

    #region MonoBehaviour
    public static CameraManager Camera { get { return instance.cameraManager; } }
    public static PopupManager Popup { get { return instance.popupManager; } }

    private CameraManager cameraManager;                                                    //카메라매니저
    private PopupManager popupManager;                                                      //팝업매니저
    #endregion

    #region No MonoBehaviour
    public static EventManager Event { get { return instance.eventManager; } }
    public static SceneManagerEx Scene { get { return instance.sceneManager; } }
    public static DataService Data { get { return instance.dataScrvice; } }
    public static PlayerInfoManager Job { get { return instance.playerJobManager; } }

    private readonly EventManager eventManager = new EventManager();                        //이벤트매니저
    private readonly SceneManagerEx sceneManager = new SceneManagerEx();                    //씬매니저확장
    private readonly DataService dataScrvice = new DataService();                           //데이터
    private PlayerInfoManager playerJobManager = new PlayerInfoManager();                   //플레이어정보
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

        Job.Init();
        Data.Init();
    }

    private void LateUpdate()
    {
        Camera.OnLateUpdate?.Invoke();
    }

    /// <summary>
    /// MonoBehaviour 상속받고있는 매니저 만들 때 객체만들어주는 함수
    /// </summary>
    private T CreateManager<T>(string name, Transform parent = null) where T : MonoBehaviour
    {
        GameObject manager = new GameObject(name);
        if(parent != null)
            manager.transform.parent = parent;

        return manager.AddComponent<T>();
    }
}
