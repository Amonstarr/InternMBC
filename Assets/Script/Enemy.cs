using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public int health = 100; // Health dari musuh

    // Fungsi untuk menerima damage dari Fireball
    public void TakeDamage(int damage)
    {
        health -= damage; // Kurangi health musuh berdasarkan damage
        Debug.Log("Enemy took damage: " + damage);

        // Jika health musuh mencapai 0, hancurkan objek musuh
        if (health <= 0)
        {
            Die();
        }
    }

    // Fungsi untuk menghancurkan enemy jika health habis
    void Die()
    {
        Debug.Log("Enemy died.");
        Destroy(gameObject); // Hancurkan objek musuh dari scene
    }
}
