using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 플레이어가 키들을 입력했을 때 쓰는 class
/// </summary>
public class PlayerInputController : TopDownController
{
    private Camera camera;

    private void Awake()
    {
        camera = Camera.main;
    }

    /// <summary>
    /// Input System에서 Move라고 만들어줬기에 그 키를 입력하면 OnMove를 찾아온다.
    /// </summary>
    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;

        CallLookEvent(newAim);
    }

    public void OnFire(InputValue value)
    {
        IsAttacking = value.isPressed;
    }
}