using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraManager : MonoBehaviour
{
    public Action OnLateUpdate;                     //씬전환 순간에 LateUpdate에 사용할 함수 모음 변수

    public Camera Main { get; private set; }        //메인 카메라
    private Transform target;                       //카메라 따라다닐 목표 저장 변수

    public void Init()
    {
        Managers.Scene.OnLoadCompleted(FindMainCamera);
    }

    /// <summary>
    /// 씬 전환시 호출 되는 main카메라 찾고 lobby씬일 시 타겟을따라다니게 설정하는 함수
    /// </summary>
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

    /// <summary>
    /// 따라다닐 목표 설정해주는 함수
    /// </summary>
    public void SetFollowTarget(Transform target)
    {
        this.target = target;
    }

    /// <summary>
    /// 카메라위치를 목표로 이동시켜주는 함수
    /// </summary>
    private void FollowTarget()
    {
        if (target == null)
            return;

        Main.transform.position = new Vector3(target.position.x, target.position.y, Main.transform.position.z);
    }

}
