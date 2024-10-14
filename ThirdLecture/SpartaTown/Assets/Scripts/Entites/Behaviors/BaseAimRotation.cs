using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 보는 방향 전환 전용 클래스
/// </summary>
public class BaseAimRotation : MonoBehaviour
{
    private Vector2 target;                     //목표지점

    private BaseController myController;
    private SpriteRenderer mySpriteRenderer; 

    private void Awake()
    {
        myController = GetComponent<BaseController>();
        mySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        myController.LookEvent += Look;
    }

    private void Update()
    {
        LookAim(target);
    }

    /// <summary>
    /// target을 바꿔주는 함수
    /// </summary>
    public void Look(Vector2 target)
    {
        this.target = target;
    }

    /// <summary>
    /// target위치에 따라 좌우로 spriteRenderer바꿔주는 함수
    /// </summary>
    private void LookAim(Vector2 target)
    {
        target = (target - (Vector2)transform.position).normalized;

        float rotZ = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg; 
        mySpriteRenderer.flipX = Mathf.Abs(rotZ) > 90;
    }
}
