using System;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnAttackEvent;

    protected bool IsAttacking { get; set; }

    private float timeSinceLastAttack = float.MaxValue;

    private void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {

        if (timeSinceLastAttack < 0.2f)
        {
            timeSinceLastAttack += Time.deltaTime;
        }
        else if(IsAttacking)
        {
            timeSinceLastAttack = 0f;
            CallAttackEvent();
        }
    }

    public void CallMoveEvent(Vector2 dir)
    {
        //? null이면 무시 값이 들어 있으면 실행
        OnMoveEvent?.Invoke(dir);
    }

    public void CallLookEvent(Vector2 dir)
    {
        OnLookEvent?.Invoke(dir);
    }

    private void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }
}
