using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public float invincibleTime = 2f; // Durasi invincible setelah terkena damage
    private bool isInvincible = false;
    public GameOverManager gameOverManager;

    private SpriteRenderer spriteRenderer; // Referensi ke SpriteRenderer
    public Transform spawnPoint; // Referensi ke Spawn Point

    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>(); // Ambil komponen SpriteRenderer
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible) return; // Jika player dalam keadaan invincible, tidak menerima damage

        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            gameOverManager.ActivateGameOver(); // Panggil Game Over
        }

        // Mulai invincibility dan flicker effect
        StartCoroutine(InvincibilityAndFlicker());
    }

    IEnumerator InvincibilityAndFlicker()
    {
        isInvincible = true;

        // Buat player berkedip selama beberapa detik
        for (float i = 0; i < invincibleTime; i += 0.2f)
        {
            // Mengganti alpha sprite renderer untuk membuat efek blink
            spriteRenderer.enabled = false; // Matikan sprite renderer untuk membuatnya hilang
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.enabled = true; // Nyalakan kembali sprite
            yield return new WaitForSeconds(0.1f);
        }

        isInvincible = false; // Invincibility selesai
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

     public void ResetHealthAndPosition()
    {
        currentHealth = maxHealth; // Reset health ke maksimal
        transform.position = spawnPoint.position; // Reset posisi player ke spawn point
    }
}
