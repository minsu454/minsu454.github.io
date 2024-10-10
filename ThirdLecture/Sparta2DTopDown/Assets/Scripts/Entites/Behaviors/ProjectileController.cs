using System;
using UnityEngine;

/// <summary>
/// 발사체컨트롤러 class
/// </summary>
public class ProjectileController : MonoBehaviour
{
    [SerializeField] private LayerMask levelCollisionLayer;     //벽 레이어 저장 변수

    private bool isReady;                       //obj가 켜졌는지 안켜졌는지 저장 변수

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private TrailRenderer trailRenderer;

    private RangedAttackSO attackData;          //원거리 공격데이터 저장 변수
    private float currentDuration;              //발사체 지속시간 저장 변수
    private Vector2 direction;                  //방향 변수

    private bool fxOnDestroy = true;            //obj 사라질 때 이펙트 사용 여부 변수

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        trailRenderer = GetComponent<TrailRenderer>();
    }

    private void Update()
    {
        if (!isReady)
            return;

        currentDuration += Time.deltaTime;

        //발사체가 켜져있는지 오래되면 삭제해주는 코드
        if (currentDuration > attackData.duration)
        {
            DestroyProjectile(transform.position, false);
        }

        rb.velocity = direction * attackData.speed;
    }

    /// <summary>
    /// 투사체 세팅해주는 함수
    /// </summary>
    public void InitializeAttack(Vector2 direction, RangedAttackSO attackData)
    {
        this.attackData = attackData;
        this.direction = direction;

        UpdateProectilSprite();
        trailRenderer.Clear();
        currentDuration = 0;
        spriteRenderer.color = attackData.projectileColor;

        transform.right = this.direction;

        isReady = true;
    }

    /// <summary>
    /// 투사체 크기 키워주는 함수
    /// </summary>
    private void UpdateProectilSprite()
    {
        transform.localScale = Vector3.one * attackData.size;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //벽에 충돌 했을 때
        if (IsLayerMatched(levelCollisionLayer.value, col.gameObject.layer))
        {
            Vector2 destroyPosition = col.ClosestPoint(transform.position) - direction * 0.2f;
            DestroyProjectile(destroyPosition, fxOnDestroy);
        }
        //타겟에 충돌 했을 때
        else if (IsLayerMatched(attackData.target.value, col.gameObject.layer))
        {
            HealthSystem healthSystem = col.GetComponent<HealthSystem>();
            if (healthSystem != null)
            {
                bool isAttackApplied = healthSystem.ChangeHealth(-attackData.power);

                if (isAttackApplied && attackData.isOnKnockBack)
                {
                    ApplyKnockback(col);
                }
            }

            DestroyProjectile(col.ClosestPoint(transform.position), fxOnDestroy);
        }
    }

    /// <summary>
    /// 넉백 처리해주는 함수
    /// </summary>
    private void ApplyKnockback(Collider2D col)
    {
        TopDownMovement movement = col.GetComponent<TopDownMovement>();
        if (movement != null)
        {
            movement.ApplyKnockback(transform, attackData.knockBackPower, attackData.knockBackTime);
        }
    }

    /// <summary>
    /// 레이어 동일한지 반환해주는 함수
    /// </summary>
    private bool IsLayerMatched(int value, int layer)
    {
        return value == (value | 1 << layer);
    }

    /// <summary>
    /// 투사체 삭제하면서 이펙트 뿌려주는 함수
    /// </summary>
    private void DestroyProjectile(Vector3 position, bool createFx)
    {
        if (createFx)
        {

        }
        gameObject.SetActive(false);
    }
}