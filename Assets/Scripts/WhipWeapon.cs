using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : MonoBehaviour
{
    [SerializeField] private float timeToAttack = 1.5f;
    private float timer;

    [SerializeField] private GameObject leftWhipObject;
    [SerializeField] private GameObject rightWhipObject;

    private PlayerMove playerMove;
    [SerializeField] private Vector2 whipAttackSize = new Vector2(4f,2f);
    [SerializeField] private int whipDamage = 10;

    /* Start is called before the first frame update
    void Start()
    {
        
    }*/

    // Update is called once per frame

    private void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            Attack();
        }
    }

                                                            // ReSharper disable Unity.PerformanceAnalysis
    private void Attack()
    {
                                                            //Debug.Log("We are Attacking!!!");
        timer = timeToAttack;

        if (playerMove.lastHorizontalVector > 0)
        {
            rightWhipObject.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhipObject.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
        }
        else
        {
            leftWhipObject.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(leftWhipObject.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
        }
    }

                                                            // ReSharper disable Unity.PerformanceAnalysis
    private void ApplyDamage(Collider2D[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
                                                            //Debug.Log(colliders[i].gameObject.name);
            IDamageable e = colliders[i].GetComponent<IDamageable>();
            if (e != null)
            {
                e.TakeDamage(whipDamage);
                                                            // Obsolete//  colliders[i].GetComponent<Enemy>().TakeDamage(whipDamage);
            }
        }
    }
}
