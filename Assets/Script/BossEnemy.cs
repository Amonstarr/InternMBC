using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public float speed = 2.0f;            
    public float attackRange = 1.5f;      
    public float attackCooldown = 2.0f;   
    public int damage = 10;               

    private Transform target;             
    private Animator myAnimator;          
    private float lastAttackTime;         

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, target.position);

        if (distanceToPlayer > attackRange)
        {
            MoveTowardsPlayer();
        }
        else
        {
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                StartCoroutine(AttackPlayer());
                lastAttackTime = Time.time;
            }
        }
    }

    void MoveTowardsPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        myAnimator.SetBool("isWalking", true);
    }

    IEnumerator AttackPlayer()
    {
        myAnimator.SetBool("isWalking", false);
        myAnimator.SetTrigger("Attack");
        yield return new WaitForSeconds(0.5f);

        if (Vector2.Distance(transform.position, target.position) <= attackRange)
        {
            PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
        yield return new WaitForSeconds(attackCooldown - 0.5f);
        myAnimator.ResetTrigger("Attack");
    }
}
