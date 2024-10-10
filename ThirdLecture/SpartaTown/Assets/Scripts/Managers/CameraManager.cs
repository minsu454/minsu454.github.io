using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraManager : MonoBehaviour
{
    public Camera main;

    public void Init()
    {
        SceneManager.sceneLoaded += FindMainCamera;
    }

    public void FindMainCamera(Scene scene, LoadSceneMode mode)
    {
        main = Camera.main;

        switch (scene.name)
        {

        }
    }

    public void OnUpdate()
    {
        
    }
}
