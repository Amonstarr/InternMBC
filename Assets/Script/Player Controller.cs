using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private int slashDamage = 20; // Damage yang diberikan oleh slashing
    [SerializeField] private Transform slashHitbox; // Hitbox untuk slashing
    [SerializeField] private float slashRadius = 0.5f; // Radius hitbox untuk slashing
    [SerializeField] private AudioClip slashSound; // Suara untuk slash
    [SerializeField] private AudioClip shootSound; // Suara untuk shoot

    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator myAnimator;
    private SpriteRenderer mySpriteRender;
    private AudioSource audioSource; // AudioSource untuk memutar suara

    private void Awake() {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mySpriteRender = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>(); // Inisialisasi AudioSource
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
        if (Input.GetMouseButtonDown(0)) { // Slash attack
            myAnimator.SetBool("isSlashing", true);
            PlaySound(slashSound); // Mainkan suara slash
            StartCoroutine(DelaySlash());
            SlashAttack(); // Panggil fungsi serangan slashing
        }
        else if (Input.GetMouseButtonDown(1)) { // Shoot attack
            myAnimator.SetBool("isShooting", true);
            PlaySound(shootSound); // Mainkan suara shoot
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

    // Fungsi untuk serangan slashing
    void SlashAttack() {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(slashHitbox.position, slashRadius);

        foreach (Collider2D enemy in hitEnemies) {
            if (enemy.CompareTag("Enemy")) {
                enemy.GetComponent<Enemy>().TakeDamage(slashDamage); // Berikan damage
            }
        }
    }

    // Fungsi untuk memainkan suara
    private void PlaySound(AudioClip clip) {
        if (clip != null) {
            audioSource.PlayOneShot(clip); // Memainkan suara sekali
        }
    }

    // Debugging untuk melihat area hitbox di scene view
    private void OnDrawGizmosSelected() {
        if (slashHitbox != null) {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(slashHitbox.position, slashRadius);
        }
    }

    //UpDown Animation
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
