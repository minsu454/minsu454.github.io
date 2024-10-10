using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 체력과 관련한 것들 관리해주는 class
/// </summary>
public class HealthSystem : MonoBehaviour
{
    [SerializeField] private float healthChangeDelay = 0.5f;        //피격 시 무적시간

    private CharacterStatHandler statHandler;                       //캐릭터 스텟관리 class
    private float timeSinceLastChange = float.MaxValue;             //무적 시간 체크 변수
    private bool isAttacked = false;                                //캐릭터 공격

    public event Action OnDamage;
    public event Action OnHeal;
    public event Action OnDeath;
    public event Action OnInvincibilityEnd;

    public float CurrentHealth { get; private set; }

    public float MaxHealth => statHandler.CurrentStat.maxHealth;

    private void Awake()
    {
        statHandler = GetComponent<CharacterStatHandler>();
    }

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    private void Update()
    {
        //무적시간 체크
        if (isAttacked && timeSinceLastChange < healthChangeDelay)
        {
            timeSinceLastChange += Time.deltaTime;
            if (timeSinceLastChange >= healthChangeDelay)
            {
                OnInvincibilityEnd?.Invoke();
                isAttacked = false;
            }
        }
    }

    /// <summary>
    /// 체력을 파라미터 값만큼 바꿔주는 함수
    /// </summary>
    public bool ChangeHealth(float change)
    {
        if (isAttacked)
        {
            return false;
        }

        timeSinceLastChange = 0f;
        CurrentHealth += change;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, MaxHealth);

        if (CurrentHealth <= 0)
        {
            CallDeath();
            return true;
        }

        if (change >= 0)
        {
            OnHeal?.Invoke();
        }
        else
        {
            OnDamage?.Invoke();
            isAttacked = true;
        }

        return true;
    }

    /// <summary>
    /// 죽었을 때 호출하는 함수
    /// </summary>
    private void CallDeath()
    {
        OnDeath?.Invoke();
    }
}
