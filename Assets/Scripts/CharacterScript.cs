using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Animator animator;
    private float xDir = 0f;
    private SpriteRenderer sprite;
    // private static Timer myTimer;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        // myTimer = new Timer(2000);
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal movement
        xDir = Input.GetAxisRaw("Horizontal");
        rigidbody.velocity = new Vector2(xDir * 5f, rigidbody.velocity.y);

        // Jumping
        if (Input.GetButtonDown("Jump"))
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, 10f);
            // animator.SetBool("IsJumping", true);
            // Use Raycast to determine when to set IsJumping to true and false
        }

        if (Input.GetMouseButtonDown(0)) // Attacking
        {
            animator.SetTrigger("Attacking");
        }

        UpdateAnimation();
    }
    private void UpdateAnimation()
    {
        // Walking
        if (xDir > 0f) // Walking right
        {
            sprite.flipX = true;
            animator.SetBool("IsWalking", true);
        }
        else if (xDir < 0f) // Walking left
        {
            sprite.flipX = false;
            animator.SetBool("IsWalking", true);
        }
        else // Idle
        {
            animator.SetBool("IsWalking", false);
        }
    }
}
