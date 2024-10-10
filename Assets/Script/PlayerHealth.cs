using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Kesehatan maksimal
    private int currentHealth;
    private Animator animator;

    private void Start()
    {
        currentHealth = maxHealth; // Set kesehatan awal
        animator = GetComponent<Animator>(); // Ambil komponen Animator
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Kurangi kesehatan

        // Cek jika player terluka
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die(); // Panggil fungsi mati
        }
        else
        {
            Hurt(); // Panggil fungsi terluka
        }
    }

    private void Hurt()
    {
        animator.SetTrigger("IsHurt"); // Trigger animasi terluka
    }

    private void Die()
    {
        animator.SetBool("IsDead", true); // Trigger animasi mati
        // Disable player movement atau lakukan hal lain yang diperlukan
        this.enabled = false; // Nonaktifkan skrip ini
    }

    public int GetCurrentHealth()
    {
        return currentHealth; // Mengembalikan kesehatan saat ini
    }
}
