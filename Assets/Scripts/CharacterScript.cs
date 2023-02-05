using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Animator animator;
    private SpriteRenderer sprite;
    private BoxCollider2D PlayerColl;
    [SerializeField] private LayerMask jumpableTerrain;
    
    public PlayerStatusController playerStatusController;
    
    public GameObject weapon;
    private BoxCollider2D WeaponCol;

    private float xDir = 0f;
    private float rightOffset = 0.6771092f;
    private float leftOffset = -0.6771092f;
    private bool running;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        WeaponCol = weapon.GetComponent<BoxCollider2D>();
        PlayerColl = GetComponent<BoxCollider2D>();

        running = false;
    }

    // Update is called once per frame
    void Update()
    {

        // Check if player is dead. Disable movement if true
        if (!playerStatusController.dead)
        {
            PlayerMovement();
        }
    }

    private void PlayerMovement() 
    {
        // Horizontal movement
        xDir = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) // Running
        {
            if (isGrounded())
            {
                rigidbody.velocity = new Vector2(xDir * 10f, rigidbody.velocity.y);
                running = true;
            }
        } else // Walking
        {
            rigidbody.velocity = new Vector2(xDir * 5f, rigidbody.velocity.y);
            running = false;
        }

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, 12f);
        }

        // Attacking
        if (Input.GetMouseButtonDown(0)) 
        {
            animator.SetTrigger("Attacking");
        }

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        // Walking
        if (xDir > 0f && !running) // Walking right
        {
            sprite.flipX = true;
            if (!isGrounded())
            {
                animator.SetBool("IsWalking", false);
            } else
            {
                animator.SetBool("IsWalking", true);
            }
            WeaponCol.offset = new Vector2(rightOffset, WeaponCol.offset.y);
        }
        else if (xDir < 0f && !running) // Walking left
        {
            sprite.flipX = false;
            if (!isGrounded())
            {
                animator.SetBool("IsWalking", false);
            } else
            {
                animator.SetBool("IsWalking", true);
            }
            WeaponCol.offset = new Vector2(leftOffset, WeaponCol.offset.y);
        } else if (xDir > 0f && running) // Run right
        {
            sprite.flipX = true;
            if (!isGrounded())
            {
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsRunning", false);
            }
            else
            {
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsRunning", true);
            }
            WeaponCol.offset = new Vector2(rightOffset, WeaponCol.offset.y);
        } else if (xDir < 0f && running) // Run left
        {
            sprite.flipX = false;
            if (!isGrounded())
            {
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsRunning", false);
            }
            else
            {
                animator.SetBool("IsWalking", false);
                animator.SetBool("IsRunning", true);
            }
            WeaponCol.offset = new Vector2(leftOffset, WeaponCol.offset.y);
        }
        else // Idle
        {
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsRunning", false);
        }
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(PlayerColl.bounds.center, PlayerColl.bounds.size, 0f, Vector2.down, 0.1f, jumpableTerrain);
    }

    public void PlayFootstepSound()
    {
        audioSource.PlayOneShot(AudioController.playerFootsteps[Random.Range(0, AudioController.playerFootsteps.Length)], .5f);
    }
    public void PlayAttackSound()
    {
        audioSource.clip = AudioController.playerAttack[Random.Range(0, AudioController.playerAttack.Length)];
        audioSource.Play();
    }
    public void PlayHurtSound()
    {
        audioSource.clip = AudioController.playerHurt[Random.Range(0, AudioController.playerHurt.Length)];
        audioSource.Play();
    }
    public void PlayDeathSound()
    {
        audioSource.clip = AudioController.playerDeath[Random.Range(0, AudioController.playerDeath.Length)];
        audioSource.Play();
    }
}
