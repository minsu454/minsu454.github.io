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

    /// <summary>
    /// 키값이 입력되면 움직임 관련 action을 실행시켜주는 함수
    /// </summary>
    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    /// <summary>
    /// 키값이 입력되면 보는 것 관련 action을 실행시켜주는 함수
    /// </summary>
    public void OnLook(InputValue value)
    {
        Vector2 mousePos = Managers.Camera.Main.ScreenToWorldPoint(value.Get<Vector2>());

        CallLookEvent(mousePos);
    }

    /// <summary>
    /// Input을 잠구는 함수
    /// </summary>
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
