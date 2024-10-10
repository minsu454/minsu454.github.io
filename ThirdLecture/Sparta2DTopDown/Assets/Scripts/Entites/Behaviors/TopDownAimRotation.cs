using System;
using UnityEngine;

/// <summary>
/// 무기회전 class
/// </summary>
public class TopDownAimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer armRenderer;    //무기랜더러
    [SerializeField] private Transform armPivot;            //무기위치

    [SerializeField]
    private SpriteRenderer characterRenderer;               //해당 캐릭터랜더러

    private TopDownController controller;                   //해당 컨트롤러

    public void Awake()
    {
        controller = GetComponent<TopDownController>();
    }

    public void Start()
    {
        controller.OnLookEvent += OnAnim;
    }

    /// <summary>
    /// 공격방향 바라볼 때 Action 추가 함수
    /// </summary>
    private void OnAnim(Vector2 dir)
    {
        RotationArm(dir);
    }

    /// <summary>
    /// 무기 공격 방향에 맞춰서 돌아가는 함수
    /// </summary>
    private void RotationArm(Vector2 dir)
    {
        float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
        armRenderer.flipY = characterRenderer.flipX;

        armPivot.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
