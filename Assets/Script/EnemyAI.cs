using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;
    private Transform target;
    private Animator myAnimator;

    void Start() {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        myAnimator = GetComponent<Animator>();
    }

    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
