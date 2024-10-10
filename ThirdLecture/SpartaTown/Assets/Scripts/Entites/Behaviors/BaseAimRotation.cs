using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAimRotation : MonoBehaviour
{
    private Vector2 target;

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

    public void Look(Vector2 target)
    {
        this.target = target;
    }

    private void LookAim(Vector2 target)
    {
        target = (target - (Vector2)transform.position).normalized;

        float rotZ = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg; 
        mySpriteRenderer.flipX = Mathf.Abs(rotZ) > 90;
    }
}
