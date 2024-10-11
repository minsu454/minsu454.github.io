using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    protected Animator anim;
    protected BaseController controller;

    protected virtual void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        controller = GetComponent<BaseController>();
    }
}
