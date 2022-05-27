using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    private Animator animator;

    public float horizontal;
    private static readonly int Horizontal = Animator.StringToHash("Horizontal");

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        animator.SetFloat(Horizontal, horizontal);
    }
}
