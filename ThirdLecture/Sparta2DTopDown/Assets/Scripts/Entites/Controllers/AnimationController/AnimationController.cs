using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// base 애니메이션 컨트롤러 class
/// </summary>
public class AnimationController : MonoBehaviour
{
    protected Animator animator;
    protected TopDownController controller;

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<TopDownController>();
    }
}
