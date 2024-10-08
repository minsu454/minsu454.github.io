using System;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private LayerMask levelCollisionLayer;

    private bool isReady;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private TrailRenderer trailRenderer;

    private RangedAttackSO attackData;
    private float currentDuration;
    private Vector2 direction;

    private bool fxOnDestroy = true;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsLayerMatched(levelCollisionLayer.value, collision.gameObject.layer))
        {
            Vector2 destroyPosition = collision.ClosestPoint(transform.position) - direction * 0.2f;
            DestroyProjectile(destroyPosition, fxOnDestroy);
        }
        else if (IsLayerMatched(attackData.target.value, collision.gameObject.layer))
        {
            //TODO : 데미지 주기
            DestroyProjectile(collision.ClosestPoint(transform.position), fxOnDestroy);
        }
    }

    /// <summary>
    /// 원하는 레이어인지 반환해주는 함수
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