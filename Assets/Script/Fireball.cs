using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject fireballPrefab; 
    public float fireballSpeed = 20f; 
    public Transform firePoint; 
    private Animator myAnimator;

    void Start() {
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            ShootFireball();
        }
    }

    void ShootFireball()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = (mousePos - firePoint.position).normalized;

        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, Quaternion.identity);

        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        rb.velocity = direction * fireballSpeed;
    }
}
