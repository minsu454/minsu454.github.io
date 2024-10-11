using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraManager : MonoBehaviour
{
    public Action OnLateUpdate;

    public Camera Main { get; private set; }
    private Transform target;

    public void Init()
    {
        Managers.Scene.OnLoadCompleted(FindMainCamera);
    }

    public void FindMainCamera(Scene scene, LoadSceneMode mode)
    {
        Main = Camera.main;

        OnLateUpdate = null;

        switch (scene.name)
        {
            case "Lobby":
                OnLateUpdate += FollowTarget;
                break;
        }
    }

    public void SetFollowTarget(Transform target)
    {
        this.target = target;
    }

    private void FollowTarget()
    {
        if (target == null)
            return;

        Main.transform.position = new Vector3(target.position.x, target.position.y, Main.transform.position.z);
    }

}
