using System;
using UnityEngine;

/// <summary>
/// base 컨트롤러
/// </summary>
public class TopDownController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;           //이동시 호출될 이벤트
    public event Action<Vector2> OnLookEvent;           //표적지를 바라볼때 호출될 이벤트
    public event Action<AttackSO> OnAttackEvent;        //공격시 호출될 이벤트

    protected bool IsAttacking { get; set; }            //공격중인지 체크하는 변수

    private float timeSinceLastAttack = float.MaxValue; //딜레이측정하기 위한 변수

    protected CharacterStatHandler stats { get; private set; }      //캐릭터 스텟

    protected virtual void Awake()
    {
        stats = GetComponent<CharacterStatHandler>();    
    }

    private void Update()
    {
        HandleAttackDelay();
    }

    /// <summary>
    /// 공격 딜레이 계산해주는 함수
    /// </summary>
    private void HandleAttackDelay()
    {
        if (timeSinceLastAttack < stats.CurrentStat.attackSO.delay)
        {
            timeSinceLastAttack += Time.deltaTime;
        }
        else if(IsAttacking)
        {
            timeSinceLastAttack = 0f;
            CallAttackEvent(stats.CurrentStat.attackSO);
        }
    }

    /// <summary>
    /// 등록된 MoveEvent를 모두 실행해주는 함수
    /// </summary>
    public void CallMoveEvent(Vector2 dir)
    {
        //? null이면 무시 값이 들어 있으면 실행
        OnMoveEvent?.Invoke(dir);
    }

    /// <summary>
    /// 등록된 LookEvent를 모두 실행해주는 함수
    /// </summary>
    public void CallLookEvent(Vector2 dir)
    {
        OnLookEvent?.Invoke(dir);
    }

    /// <summary>
    /// 등록된 AttackEvent를 모두 실행해주는 함수
    /// </summary>
    private void CallAttackEvent(AttackSO attackSO)
    {
        OnAttackEvent?.Invoke(attackSO);
    }
}
