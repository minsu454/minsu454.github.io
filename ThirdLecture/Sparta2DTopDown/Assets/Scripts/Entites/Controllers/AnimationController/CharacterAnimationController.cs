using System;
using System.Runtime.CompilerServices;
using UnityEngine;

/// <summary>
/// 캐릭터 애니메이션 컨트롤러 class
/// </summary>
public class CharacterAnimationController : AnimationController
{
    private static readonly int isWalking = Animator.StringToHash("isWalking");         //isWalking 해쉬 저장
    private static readonly int isHit = Animator.StringToHash("isHit");                 //isHit 해쉬 저장
    private static readonly int attack = Animator.StringToHash("attack");               //attack 해쉬 저장

    private readonly float magnitutedThreshold = 0.5f;              //최소의 감지할 움직임을 저장하는 변수
    private HealthSystem healthSystem;                              //체력 시스템

    protected override void Awake()
    {
        base.Awake();
        healthSystem = GetComponent<HealthSystem>();
    }

    private void Start()
    {
        controller.OnAttackEvent += Attaking;
        controller.OnMoveEvent += Move;

        if (healthSystem != null)
        {
            healthSystem.OnDeath += Hit;
            healthSystem.OnInvincibilityEnd += InvincibilityEnd;
        }
    }

    /// <summary>
    /// Action에 추가할 움직일 시 애니메이션 변동 함수
    /// </summary>
    private void Move(Vector2 vector)
    {
        animator.SetBool(isWalking, vector.magnitude > magnitutedThreshold);
    }

    /// <summary>
    /// Action에 추가할 공격 시 애니메이션 변동 함수
    /// </summary>
    private void Attaking(AttackSO sO)
    {
        animator.SetTrigger(attack);
    }

    /// <summary>
    /// Action에 추가할 피격 시 애니메이션 변동 함수
    /// </summary>
    private void Hit()
    {
        animator.SetBool(isHit, true);
    }

    /// <summary>
    /// Action에 추가할 무적시간 끝날 때 애니메이션 변동 함수
    /// </summary>
    private void InvincibilityEnd()
    {
        animator.SetBool(isHit, false);
    }

}