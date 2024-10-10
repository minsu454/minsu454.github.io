using System;
using UnityEngine;

public class TopDownAimRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer armRenderer;
    [SerializeField] private Transform armPivot;

    [SerializeField]
    private SpriteRenderer characterRenderer;

    private TopDownController controller;

    public void Awake()
    {
        controller = GetComponent<TopDownController>();
    }

    public void Start()
    {
        controller.OnLookEvent += OnAnim;
    }

    private void OnAnim(Vector2 dir)
    {
        RotationArm(dir);
    }

    private void RotationArm(Vector2 dir)
    {
        float rotZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
        armRenderer.flipY = characterRenderer.flipX;

        armPivot.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
