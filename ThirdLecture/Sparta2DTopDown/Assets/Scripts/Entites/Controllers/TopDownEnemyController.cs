using UnityEngine;
using UnityEngine.UIElements;

/// <summary>
/// base EnemyController class
/// </summary>
public class TopDownEnemyController : TopDownController
{
    protected Transform ClosestTarget { get; private set; }     //타겟 위치

    protected override void Awake()
    {
        base.Awake();

    }

    protected virtual void Start()
    {
        ClosestTarget = GameManager.Instance.Player;
    }

    protected virtual void FixedUpdate()
    {

    }

    /// <summary>
    /// 거리 측정 함수
    /// </summary>
    protected float DistanceToTarget()
    {
        return Vector3.Distance(transform.position, ClosestTarget.position);
    }

    /// <summary>
    /// 방향값 반환 함수
    /// </summary>
    protected Vector2 DirectionToTarget()
    {
        return (ClosestTarget.position - transform.position).normalized;
    }
}
