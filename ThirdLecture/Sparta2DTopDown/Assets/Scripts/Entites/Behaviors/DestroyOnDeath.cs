using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 캐릭터 죽을 때 사용하는 class
/// </summary>
public class DestroyOnDeath : MonoBehaviour
{
    private HealthSystem healthSystem;      //내 체력 시스템 저장 변수
    private Rigidbody2D rb;

    private void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
        rb = GetComponent<Rigidbody2D>();

        healthSystem.OnDeath += OnDeath;
    }

    /// <summary>
    /// 죽었을 때 호출되는 함수
    /// </summary>
    private void OnDeath()
    {
        rb.velocity = Vector2.zero;

        foreach (SpriteRenderer renderer in GetComponentsInChildren<SpriteRenderer>())
        {
            Color color = renderer.color;
            color.a = 0.3f;
            renderer.color = color;
        }

        foreach (Behaviour behaviour in GetComponentsInChildren<Behaviour>())
        {
            behaviour.enabled = false;
        }

        Destroy(gameObject, 2f);
    }
}
