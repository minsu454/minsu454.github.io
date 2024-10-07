using System;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;

    public void CallMoveEvent(Vector2 dir)
    {
        //? null이면 무시 값이 들어 있으면 실행
        OnMoveEvent?.Invoke(dir);
    }

    public void CallLookEvent(Vector2 dir)
    {
        OnLookEvent?.Invoke(dir);
    }
}