using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public int damage = 10; // Damage yang diberikan Fireball

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Cek jika Fireball menabrak musuh dengan tag "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Ambil komponen Enemy dari objek yang ditabrak dan berikan damage
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();

            if (enemy != null)
            {
                // Panggil fungsi untuk memberikan damage pada musuh
                enemy.TakeDamage(damage);
            }

            // Hancurkan Fireball setelah mengenai musuh
            Destroy(gameObject);
        }
        // Cek jika Fireball menabrak objek dengan tag "Object"
        else if (collision.gameObject.CompareTag("Object"))
        {
            // Hancurkan Fireball setelah mengenai objek
            Destroy(gameObject);
        }
    }
}
