using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerInputController : BaseController
{
    private PlayerInput input;

    private void Awake()
    {
        Managers.Camera.SetFollowTarget(transform);
        input = GetComponent<PlayerInput>();
        Managers.Event.Subscribe(GameEventType.LockInput, OnLockInput);
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

    public void OnLockInput(object args)
    {
        bool isActive = (bool)args;
        input.enabled = isActive;
    }

    private void OnDestroy()
    {
        Managers.Event.Unsubscribe(GameEventType.LockInput, OnLockInput);
    }
}
