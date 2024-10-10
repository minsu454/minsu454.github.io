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

    private Vector2 movementDir = Vector2.zero;     //캐릭터 움직임 값 변수
    private Vector2 knockback = Vector2.zero;       //넉백 변수
    private float knockbackDuration = 0f;           //넉백 지속시간 변수

    private void Awake()
    {
        controller = GetComponent<TopDownController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
        characterStatsHandler = GetComponent<CharacterStatHandler>();
    }

    private void Start()
    {
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

    /// <summary>
    /// Action에 움직임 추가해주는 함수
    /// </summary>
    private void Move(Vector2 dir)
    {
        movementDir = dir;
    }

    /// <summary>
    /// 넉백으로 인해 움직임 밀리는 효과 함수
    /// </summary>
    public void ApplyKnockback(Transform other, float power, float duration)
    {
        knockbackDuration = duration;
        knockback = -(other.position - transform.position).normalized * power;
    }

    /// <summary>
    /// 실질적으로 veloctiy에 값 넣어주는 함수
    /// </summary>
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
