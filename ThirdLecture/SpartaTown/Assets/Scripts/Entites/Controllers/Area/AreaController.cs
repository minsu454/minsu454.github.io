using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaController : MonoBehaviour
{
    protected Action areaEvent;

    protected virtual void Start()
    {

    }

    void Update()
    {
        areaEvent?.Invoke();
    }
}
