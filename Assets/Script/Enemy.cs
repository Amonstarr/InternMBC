using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 50;
    private LevelManager levelManager;
    private MissionManager missionManager;

    void Start()
    {
        levelManager = FindAnyObjectByType<LevelManager>(); 
        missionManager = FindObjectOfType<MissionManager>();
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
        levelManager.EnemyDefeated(); 

        if (missionManager != null)
        {
            missionManager.EnemyDefeated(); // Panggil fungsi di MissionManager
        }


        Destroy(gameObject);
    }
}
