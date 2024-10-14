using System;
using UnityEngine;

public class BasePopup : MonoBehaviour
{
    public Action ClossEvent;

    private void OnEnable()
    {
        Init();
    }

    public virtual void Init()
    {
        
    }

    public virtual void Close()
    {
        Managers.Popup.Close();
        
        ClossEvent?.Invoke();
        Destroy(gameObject);
    }
}
