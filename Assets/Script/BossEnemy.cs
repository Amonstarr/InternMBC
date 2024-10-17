using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
    public float speed = 2.0f;            // Kecepatan gerak musuh
    public float attackRange = 1.5f;      // Jarak serang
    public float attackCooldown = 2.0f;   // Waktu jeda antar serangan
    public int damage = 10;               // Jumlah damage

    private Transform target;             // Transform dari player
    private Animator myAnimator;          // Animator musuh
    private float lastAttackTime;         // Waktu serangan terakhir

    void Start()
    {
        // Cari player berdasarkan tag "Player"
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        // Hitung jarak musuh ke player
        float distanceToPlayer = Vector2.Distance(transform.position, target.position);

        if (distanceToPlayer > attackRange)
        {
            // Jika player di luar jarak serang, bergerak mendekat
            MoveTowardsPlayer();
        }
        else
        {
            // Jika dalam jarak serang dan cooldown selesai, serang player
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                StartCoroutine(AttackPlayer());
                lastAttackTime = Time.time; // Reset waktu serangan terakhir
            }
        }
    }

    void MoveTowardsPlayer()
    {
        // Bergerak ke arah player
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        // Aktifkan animasi berjalan (jika ada)
        myAnimator.SetBool("isWalking", true);
    }

    IEnumerator AttackPlayer()
    {
        // Hentikan animasi berjalan
        myAnimator.SetBool("isWalking", false);

        // Mulai animasi serangan
        myAnimator.SetTrigger("Attack");

        // Tunggu sebentar untuk memastikan animasi berjalan sebelum damage
        yield return new WaitForSeconds(0.5f);

        // Jika player masih dalam jarak, berikan damage
        if (Vector2.Distance(transform.position, target.position) <= attackRange)
        {
            PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }

        // Tunggu hingga cooldown selesai
        yield return new WaitForSeconds(attackCooldown - 0.5f);

        // Reset trigger agar bisa dipakai lagi
        myAnimator.ResetTrigger("Attack");
    }
}
