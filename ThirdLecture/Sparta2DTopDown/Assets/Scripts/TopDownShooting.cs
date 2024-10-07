using System;
using UnityEngine;

public class TopDownShooting : MonoBehaviour
{
    private TopDownController controller;

    [SerializeField]
    private Transform projectileSpawnTr;
    private Vector2 aimDir = Vector2.right;

    public GameObject TestPrefab;

    private void Awake()
    {
        controller = GetComponent<TopDownController>();
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

    private void OnShoot()
    {
        CreateProjectile();
    }

    private void CreateProjectile()
    {
        Instantiate(TestPrefab, projectileSpawnTr.position, Quaternion.identity);
    }
}