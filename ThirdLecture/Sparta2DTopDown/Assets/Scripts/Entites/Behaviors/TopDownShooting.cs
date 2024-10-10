using System;
using UnityEngine;

/// <summary>
/// 발사체 발사하는 class
/// </summary>
public class TopDownShooting : MonoBehaviour
{
    private TopDownController controller;

    [SerializeField]
    private Transform projectileSpawnTr;        //발사체 소환 장소 변수
    private Vector2 aimDir = Vector2.right;     //공격 방향 저장 변수
    
    private ObjectPool pool;

    private void Awake()
    {
        controller = GetComponent<TopDownController>();
    }

    private void Start()
    {
        pool = GameManager.Instance.ObjectPool;

        controller.OnAttackEvent += OnShoot;
        controller.OnLookEvent += OnAim;
    }

    /// <summary>
    /// Action에 바라보는 것 추가 함수
    /// </summary>
    private void OnAim(Vector2 dir)
    {
        aimDir = dir;
    }

    /// <summary>
    /// AttackSO에 있는 값들을 발사체에 세팅해주는 함수
    /// </summary>
    private void OnShoot(AttackSO attackSO)
    {
        RangedAttackSO rangedAttackSO = attackSO as RangedAttackSO;
        if (rangedAttackSO == null)
            return;

        float projectilesAngleSpace = rangedAttackSO.multipleProjectilesAngle;
        int numberOfProjectilesPerShot = rangedAttackSO.numberOfProjectilesPerShot;

        float minAngle = -(numberOfProjectilesPerShot / 2f) * projectilesAngleSpace + 0.5f * rangedAttackSO.multipleProjectilesAngle;

        for (int i = 0; i < numberOfProjectilesPerShot; i++)
        {
            float angle = minAngle + i * projectilesAngleSpace;
            float randomSpread = UnityEngine.Random.Range(-rangedAttackSO.spread, rangedAttackSO.spread);

            angle += randomSpread;

            CreateProjectile(rangedAttackSO, angle);
        }
    }

    /// <summary>
    /// 발사체 스폰 함수
    /// </summary>
    private void CreateProjectile(RangedAttackSO rangedAttackSO, float angle)
    {
        GameObject obj = pool.SpawnFromPool(rangedAttackSO.bulletNameTag);
        obj.transform.position = projectileSpawnTr.position;
        ProjectileController attackController = obj.GetComponent<ProjectileController>();
        attackController.InitializeAttack(RotateVector2(aimDir, angle), rangedAttackSO);
    }

    private static Vector2 RotateVector2(Vector2 vec, float angle)
    {
        return Quaternion.Euler(0f, 0f, angle) * vec;
    }
}