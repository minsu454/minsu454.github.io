using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private T instance;
    public T Instance { get { return Instance; } }

    public virtual void Awake()
    {
        instance = this as T;
    }

    public virtual void OnDestroy()
    {
        instance = null;
    }
}
