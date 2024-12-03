using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private int slashDamage = 20; 
    [SerializeField] private Transform slashHitbox; 
    [SerializeField] private float slashRadius = 0.5f; 
    [SerializeField] private AudioClip slashSound; 
    [SerializeField] private AudioClip shootSound; 

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRender;
    private AudioSource audioSource; 

    private void Awake() {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRender = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>(); 
    }

    private void OnEnable() {
        playerControls.Enable();
    }

    private void Update() {
        PlayerInput();
        Attack();
        FaceUpDown();
    }

    void Attack() {
        if (Input.GetMouseButtonDown(0)) { 
            myAnimator.SetBool("isSlashing", true);
            PlaySound(slashSound); 
            StartCoroutine(DelaySlash());
            SlashAttack(); 
        }
        else if (Input.GetMouseButtonDown(1)) { 
            myAnimator.SetBool("isShooting", true);
            PlaySound(shootSound); 
            StartCoroutine(DelayStrike());
        }
    }

    IEnumerator DelaySlash() {
        yield return new WaitForSeconds(0.2f);
        myAnimator.SetBool("isSlashing", false);
    }

    IEnumerator DelayStrike() {
        yield return new WaitForSeconds(0.2f);
        myAnimator.SetBool("isShooting", false);
    }

    void SlashAttack() {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(slashHitbox.position, slashRadius);

        foreach (Collider2D enemy in hitEnemies) {
            if (enemy.CompareTag("Enemy")) {
                enemy.GetComponent<Enemy>().TakeDamage(slashDamage); 
            }
        }
    }

    private void PlaySound(AudioClip clip) {
        if (clip != null) {
            audioSource.PlayOneShot(clip); 
        }
    }

    private void OnDrawGizmosSelected() {
        if (slashHitbox != null) {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(slashHitbox.position, slashRadius);
        }
    }

    void FaceUpDown() {
        if (Input.GetKey(KeyCode.W)) {
            myAnimator.SetBool("FaceUp", true);
            StartCoroutine(ExitFaceUp());
        }
        else if (Input.GetKey(KeyCode.S)) {
            myAnimator.SetBool("FaceDown", true);
            StartCoroutine(ExitFaceDown());
        }
    }

    IEnumerator ExitFaceUp() {
        yield return new WaitForSeconds(0.1f);
        myAnimator.SetBool("FaceUp", false);
    }

    IEnumerator ExitFaceDown() {
        yield return new WaitForSeconds(0.1f);
        myAnimator.SetBool("FaceDown", false);
    }

    private void FixedUpdate() {
        AdjustPlayerFacingDirection();
        Move();
    }

    private void PlayerInput() {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
        
        myAnimator.SetFloat("moveX", movement.x);
        myAnimator.SetFloat("moveY", movement.y);
    }

    private void Move() {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void AdjustPlayerFacingDirection() {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if (mousePos.x < playerScreenPoint.x) {
            mySpriteRender.flipX = true;
        } else {
            mySpriteRender.flipX = false;
        }
    }
}
