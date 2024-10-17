using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 50;
    public LevelManager levelManager;

    void Start()
    {
        // Cari GameManager di scene dan buat referensi
        levelManager = FindObjectOfType<LevelManager>(); // Cari LevelManager di scene
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        levelManager.EnemyDefeated(); // Beritahu LevelManager musuh telah kalah

        // Hancurkan objek musuh
        Destroy(gameObject);
    }
}
