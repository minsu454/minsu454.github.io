using UnityEngine;

/// <summary>
/// 움직이기 전용 class
/// </summary>
public class BaseMovement : MonoBehaviour
{
    private BaseController myController;
    private Rigidbody2D myRb;

    private Vector2 moveDir = Vector2.zero; //방향
    private float speed = 5f;               //속도

    private void Awake()
    {
        myRb = GetComponent<Rigidbody2D>();
        myController = GetComponent<BaseController>();
    }

    private void Start()
    {
        myController.MoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMovement(moveDir);
    }

    /// <summary>
    /// 움직일 방향을 저장해주는 함수
    /// </summary>
    public void Move(Vector2 vec)
    {
        moveDir = vec;
    }

    /// <summary>
    /// 실질적으로 움직이는 함수
    /// </summary>
    private void ApplyMovement(Vector2 dir)
    {
        dir *= speed;

        myRb.velocity = dir;
    }
}
