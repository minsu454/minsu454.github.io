using System;
using UnityEngine;

/// <summary>
/// 원거리 공격 enemy class
/// </summary>
public class TopDownRangeEnemyController : TopDownEnemyController
{
    [SerializeField][Range(0f, 100f)] private float followRange = 15f;      //적 감지 범위 저장 함수
    [SerializeField][Range(0f, 100f)] private float shootRange = 10f;       //공격 범위 저장 함수

    private int layerMaskTarget;            //타겟에 레이어마스크 저장

    protected override void Start()
    {
        base.Start();
        layerMaskTarget = stats.CurrentStat.attackSO.target;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        float distanceToTarget = DistanceToTarget();
        Vector2 directionToTarget = DirectionToTarget();

        UpdateEnemyState(distanceToTarget, directionToTarget);
    }

    /// <summary>
    /// 감지범위 안쪽에 있는지 검사하는 함수
    /// </summary>
    private void UpdateEnemyState(float distanceToTarget, Vector2 directionToTarget)
    {
        IsAttacking = false;
        if (distanceToTarget < followRange)
        {
            CheckIfNear(distanceToTarget, directionToTarget);
        }
    }

    /// <summary>
    /// 공격 사정거리 안쪽에 있는지 검사하는 함수
    /// </summary>
    private void CheckIfNear(float distance, Vector2 direction)
    {
        if (distance <= shootRange)
        {
            TryShootAtTarget(direction);
        }
        else
        {
            CallMoveEvent(direction);
        }
    }

    /// <summary>
    /// 타겟에게 레이케스트 쏴보고 공격가능한지 검사해주는 함수(벽이나 장애물이 있으면 공격 안함)
    /// </summary>
    private void TryShootAtTarget(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, shootRange, layerMaskTarget);

        if (hit.collider != null)
        {
            PerformAttackAction(direction);
        }
        else
        {
            CallMoveEvent(direction);
        }
    }

    /// <summary>
    /// 공격 함수
    /// </summary>
    private void PerformAttackAction(Vector2 direction)
    {
        CallLookEvent(direction);
        CallMoveEvent(Vector2.zero);
        IsAttacking = true;
    }
}