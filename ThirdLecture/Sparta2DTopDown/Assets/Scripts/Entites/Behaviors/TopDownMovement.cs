using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    //실제로 이동이 일어날 컴포넌트

    private TopDownController controller;       //이 캐릭터의 컨트롤러
    private Rigidbody2D movementRigidbody;
    private CharacterStatHandler characterStatsHandler;

    private Vector2 movementDir = Vector2.zero;
    private Vector2 knockback = Vector2.zero;
    private float knockbackDuration = 0f;

    private void Awake()
    {
        controller = GetComponent<TopDownController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
        characterStatsHandler = GetComponent<CharacterStatHandler>();
    }

    private void Start()
    {
        //실질적으로 Action 추가
        controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMovement(movementDir);

        if (knockbackDuration > 0f)
        {
            knockbackDuration -= Time.fixedDeltaTime;
        }
    }

    private void Move(Vector2 dir)
    {
        movementDir = dir;
    }

    private void ApplyKnockback(Transform other, float power, float duration)
    {
        knockbackDuration = duration;
        knockback = -(other.position - transform.position).normalized * power;
    }

    private void ApplyMovement(Vector2 dir)
    {
        dir = dir * characterStatsHandler.CurrentStat.speed;

        if (knockbackDuration > 0.0f)
        {
            dir += knockback;
        }

        movementRigidbody.velocity = dir;
    }
}
