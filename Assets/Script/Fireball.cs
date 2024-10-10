using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject fireballPrefab; // Drag Fireball prefab into this field in the Inspector
    public float fireballSpeed = 20f; // Speed of the Fireball
    public Transform firePoint; // Point where fireball spawns (can be set to the player's hand, for example)

    void Update()
    {
        // Check if the right mouse button (0 = left, 1 = right) is clicked
        if (Input.GetMouseButtonDown(1)) // Right-click is 1
        {
            ShootFireball();
        }
    }

    void ShootFireball()
    {
        // Get the mouse position in the world space
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the player to the mouse position
        Vector2 direction = (mousePos - firePoint.position).normalized;

        // Instantiate the fireball at the firePoint position
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity);

        // Set the velocity of the fireball towards the mouse position
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        rb.velocity = direction * fireballSpeed;
    }
}
