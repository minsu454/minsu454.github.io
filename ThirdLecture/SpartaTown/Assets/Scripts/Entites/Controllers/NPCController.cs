using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class NPCController : BaseController
{
    private Transform target;

    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Start()
    {
        target = GameManager.Instance.Player;
    }

    private void FixedUpdate()
    {
        Rotate(DirectionToTarget());
    }

    private void Rotate(Vector2 dir)
    {
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        spriteRenderer.flipX = Mathf.Abs(angle) > 90f;
    }

    private float DistanceToTarget()
    {
        return Vector3.Distance(transform.position, target.position);
    }

    private Vector2 DirectionToTarget()
    {
        return (target.position - transform.position).normalized;
    }
}
