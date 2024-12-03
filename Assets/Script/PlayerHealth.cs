using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public float invincibleTime = 2f;
    private bool isInvincible = false;
    public GameOverManager gameOverManager;

    private SpriteRenderer spriteRenderer;
    public Transform spawnPoint;

    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible) return;

        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            gameOverManager.ActivateGameOver();
        }

        StartCoroutine(InvincibilityAndFlicker());
    }

    IEnumerator InvincibilityAndFlicker()
    {
        isInvincible = true;

        for (float i = 0; i < invincibleTime; i += 0.2f)
        {
            spriteRenderer.enabled = false; 
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.enabled = true; 
            yield return new WaitForSeconds(0.1f);
        }

        isInvincible = false; 
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

     public void ResetHealthAndPosition()
    {
        currentHealth = maxHealth; 
        transform.position = spawnPoint.position; 
    }
}
