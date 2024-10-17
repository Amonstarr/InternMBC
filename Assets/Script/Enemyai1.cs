using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyai1 : MonoBehaviour
{
    public float speed;
    private Transform target;
    private Animator myAnimator;

    void Start() {
        // Find the player's transform by the tag "Player"
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        myAnimator = GetComponent<Animator>();
    }

    void Update() {
        // Move the enemy towards the player's position
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
