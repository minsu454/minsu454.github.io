using System;
using UnityEngine;

public class TopDownShooting : MonoBehaviour
{
    private TopDownController controller;

    [SerializeField]
    private Transform projectileSpawnTr;
    private Vector2 aimDir = Vector2.right;

    private ObjectPool pool;

    private void Awake()
    {
        controller = GetComponent<TopDownController>();
        pool = GameObject.FindObjectOfType<ObjectPool>();
    }

    private void Start()
    {
        controller.OnAttackEvent += OnShoot;
        controller.OnLookEvent += OnAim;
    }

    private void OnAim(Vector2 dir)
    {
        aimDir = dir;
    }

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