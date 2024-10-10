using UnityEngine;

public class BaseMovement : MonoBehaviour
{
    private BaseController myController;
    private Rigidbody2D myRb;

    private Vector2 moveDir = Vector2.zero;
    private float speed = 5f;

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

    public void Move(Vector2 vec)
    {
        moveDir = vec;
    }

    private void ApplyMovement(Vector2 dir)
    {
        dir *= speed;

        myRb.velocity = dir;
    }
}
