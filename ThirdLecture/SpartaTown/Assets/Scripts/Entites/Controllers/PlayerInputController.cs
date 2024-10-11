using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : BaseController
{
    private void Awake()
    {
        Managers.Camera.SetFollowTarget(transform);
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnLook(InputValue value)
    {
        Vector2 mousePos = Managers.Camera.Main.ScreenToWorldPoint(value.Get<Vector2>());

        CallLookEvent(mousePos);
    }
}
