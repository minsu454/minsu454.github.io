using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePopup : MonoBehaviour
{
    public Action OnCloss;

    public virtual void Init()
    {
        
    }

    public virtual void Close()
    {
        Managers.Popup.Close();
        
        OnCloss?.Invoke();
        Destroy(gameObject);
    }
}
