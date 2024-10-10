using System;
using System.Runtime.CompilerServices;
using UnityEngine;

/// <summary>
/// 근접공격 enemy class
/// </summary>
public class TopDownContactEnemyController : TopDownEnemyController
{
    [SerializeField][Range(0, 100f)] private float followRange;     //몬스터가 캐릭터를 감지하는 범위
    [SerializeField] private string targetTag = "Player";           //타겟 태그 저장
    private bool isCollidinWithTarget;                              //몸박했는지 확인하는 변수

    [SerializeField] private SpriteRenderer characterRenderer;

    HealthSystem healthSystem;                                      //자신의 healthSystem
    private HealthSystem collidingTargetHealthSystem;               //타겟에 healthSystem
    private TopDownMovement collidingMovement;                      //타겟에 movenent(넉백 주려고)

    protected override void Start()
    {
        base.Start();

        healthSystem = GetComponent<HealthSystem>();
        healthSystem.OnDamage += OnDamage;
    }

    /// <summary>
    /// Action에 저장할 데미지 피격 시 호출되는 함수
    /// </summary>
    private void OnDamage()
    {
        followRange = 100f;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        if (isCollidinWithTarget)
        {
            ApplyHealthChange();
        }

        Vector2 direction = Vector2.zero;
        Move(ref direction);
        Rotate(direction);
    }

    /// <summary>
    /// 몸박시 호출하는 함수
    /// </summary>
    private void ApplyHealthChange()
    {
        AttackSO attackSO = stats.CurrentStat.attackSO;
        bool isAttackable = collidingTargetHealthSystem.ChangeHealth(-attackSO.power);

        if (isAttackable && attackSO.isOnKnockBack && collidingMovement != null)
        {
            collidingMovement.ApplyKnockback(transform, attackSO.knockBackPower, attackSO.knockBackTime);
        }
    }

    /// <summary>
    /// enemy 움직이는 함수
    /// </summary>
    private void Move(ref Vector2 direction)
    {
        //플레이어와의 거리가 내가 지정한 범위 안이라면
        if (DistanceToTarget() < followRange)
        {
            direction = DirectionToTarget();
        }

        CallMoveEvent(direction);
    }

    /// <summary>
    /// enemy 플레이어 방향으로 돌아가는 함수
    /// </summary>
    private void Rotate(Vector2 dir)
    {
        float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        characterRenderer.flipX = Mathf.Abs(rotZ) > 90;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        GameObject receiver = col.gameObject;

        if (!receiver.CompareTag(targetTag))
            return;

        collidingTargetHealthSystem = col.GetComponent<HealthSystem>();
        if (collidingTargetHealthSystem != null)
        {
            isCollidinWithTarget = true;
        }

        collidingMovement = col.GetComponent<TopDownMovement>();
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (!col.CompareTag(targetTag))
            return;

        isCollidinWithTarget = false;
    }
}
