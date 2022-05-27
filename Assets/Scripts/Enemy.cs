using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
   Transform targetDestination;
   private GameObject targetGameObject;
   private Character targetCharacter;
   [SerializeField] private float speed;

   private Rigidbody2D rgdb2d;

   [SerializeField] private int hp = 10;
   [SerializeField] private int damage = 1;
   [SerializeField] private int experience_reward = 400;

   private void Awake()
   {
      rgdb2d = GetComponent<Rigidbody2D>();
      
   }

   public void SetTarget(GameObject target)
   {
      targetGameObject = target;
      targetDestination = target.transform;
   }

   private void FixedUpdate()
   {
      Vector3 direction = (targetDestination.position - transform.position).normalized;
      rgdb2d.velocity = direction * speed;
   }

   private void OnCollisionStay2D(Collision2D collision)
   {
      if (collision.gameObject == targetGameObject)
      {
         Attack();
      }
   }

   private void Attack()
   {
      //Debug.Log("Attacking the character!");
      if (targetCharacter == null)
      {
         targetCharacter = targetGameObject.GetComponent<Character>();
      }
      
      targetCharacter.TakeDamage(damage);
   }

   public void TakeDamage(int damage)
   {
      hp -= damage;

      if (hp < 1)
      {
         targetGameObject.GetComponent<Level>().AddExperience(experience_reward);
         GetComponent<DropOnDestroy>().CheckDrop();
         Destroy(gameObject);
      }
   }
}
