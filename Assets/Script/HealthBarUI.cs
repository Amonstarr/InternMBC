using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Slider healthSlider;
    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>();

        healthSlider.maxValue = playerHealth.maxHealth;
        healthSlider.value = playerHealth.GetCurrentHealth();
    }

    private void Update()
    {
        healthSlider.value = playerHealth.GetCurrentHealth();
    }
}
