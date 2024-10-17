using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Perlu untuk UI

public class HealthBarUI : MonoBehaviour
{
    public Slider healthSlider;  // Referensi ke slider UI
    private PlayerHealth playerHealth;  // Referensi ke PlayerHealth

    private void Start()
    {
        // Cari komponen PlayerHealth di player
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();

        // Set initial value of health bar sesuai dengan kesehatan player
        healthSlider.maxValue = playerHealth.maxHealth;
        healthSlider.value = playerHealth.GetCurrentHealth();
    }

    private void Update()
    {
        // Update UI health bar sesuai dengan current health player
        healthSlider.value = playerHealth.GetCurrentHealth();
    }
}
