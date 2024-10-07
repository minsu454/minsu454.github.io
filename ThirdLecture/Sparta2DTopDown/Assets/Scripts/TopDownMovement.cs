using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    //실제로 이동이 일어날 컴포넌트

    private TopDownController controller;
    private Rigidbody2D movementRigidbody;

    private Vector2 movementDir = Vector2.zero;

    private void Awake()
    {
        controller = GetComponent<TopDownController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMovement(movementDir);
    }

    private void Move(Vector2 dir)
    {
        movementDir = dir;
    }

    private void ApplyMovement(Vector2 dir)
    {
        dir = dir * 5;
        movementRigidbody.velocity = dir;
    }
}