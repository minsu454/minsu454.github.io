using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 플레이어가 키들을 입력했을 때 쓰는 class
/// </summary>
public class PlayerInputController : TopDownController
{
    private Camera camera;          //메인카메라 저장 변수

    protected override void Awake()
    {
        base.Awake();
        camera = Camera.main;
    }

    /// <summary>
    /// 플레이어 움직임(wasd)이 감지되었을 때 호출 함수(Input System에서 Move라고 만들어줬기에 그 키를 입력하면 OnMove를 찾아온다)
    /// </summary>
    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    /// <summary>
    /// 플레이어 움직임(마우스)이 감지되었을 때 호출 함수
    /// </summary>
    public void OnLook(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = camera.ScreenToWorldPoint(newAim);
        newAim = (worldPos - (Vector2)transform.position).normalized;

        CallLookEvent(newAim);
    }

    /// <summary>
    /// 플레이어 공격(마우스 왼쪽클릭)이 감지되었을 때 호출 함수
    /// </summary>
    public void OnFire(InputValue value)
    {
        IsAttacking = value.isPressed;
    }
}
