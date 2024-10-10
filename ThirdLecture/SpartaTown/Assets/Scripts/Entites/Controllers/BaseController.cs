using System;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    public Action<Vector2> MoveEvent;
    public Action<Vector2> LookEvent;

    public void CallMoveEvent(Vector2 vec)
    {
        MoveEvent?.Invoke(vec);
    }

    public void CallLookEvent(Vector2 vec)
    {
        LookEvent?.Invoke(vec);
    }
}
