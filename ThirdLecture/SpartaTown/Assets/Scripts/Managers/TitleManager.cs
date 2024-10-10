using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public void OnButton()
    {
        Managers.Scene.LoadScene(SceneType.Lobby);
    }
}
