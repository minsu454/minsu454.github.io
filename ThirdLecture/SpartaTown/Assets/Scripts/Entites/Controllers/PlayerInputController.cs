using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : BaseController
{
    private Camera camera;

    private void Awake()
    {

        camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnLook(InputValue value)
    {
        Vector2 mousePos = camera.ScreenToWorldPoint(value.Get<Vector2>());
        //mousePos = (mousePos - (Vector2)transform.position).normalized;

        CallLookEvent(mousePos);
    }
}
