using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class NPCController : BaseController
{
    private Transform target;                                       //목표지점 저장 변수
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Start()
    {
        target = GameManager.Instance.Player;
    }

    private void FixedUpdate()
    {
        Rotate(DirectionToTarget());
    }

    /// <summary>
    /// 방향에 따라 고개 바꿔주는 함수
    /// </summary>
    private void Rotate(Vector2 dir)
    {
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        spriteRenderer.flipX = Mathf.Abs(angle) > 90f;
    }

    /// <summary>
    /// 목표지점까지의 거리 반환함수
    /// </summary>
    private float DistanceToTarget()
    {
        return Vector3.Distance(transform.position, target.position);
    }

    /// <summary>
    /// 목표지점까지의 방향 반환함수
    /// </summary>
    private Vector2 DirectionToTarget()
    {
        return (target.position - transform.position).normalized;
    }
}
