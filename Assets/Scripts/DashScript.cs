using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Variables
    private float horizontal;  //To hold horizontal anxis input
    private float speed = 8f; //Movement Speed (I input a random value for testing but this can be changed without the code breaking)
    private float jumpingPower = 16f; //Jumping power (also random assigned value)
    private bool isFacingRight = true; //Boolean to determine player's facing direction . This is used in the 'Flip' function.
    [SerializeField] private Rigidbody2D rb; //Serialized Fields to assign components
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;
    private bool canDash = true; //Testing Boolean to register if player can dash 
    private bool isDashing; //Boolean to determine when the dash is being used
    private float dashingPower = 30f; //Dashing Force (randomly assigned)
    private float dashingTime = 0.15f; //Time that 'dash' takes to perform
    private float dashingCooldown = 3f; //Dash cooldown counter

    private void Update()
    {
        if (isDashing) //Prevents dash being spammed 
        {
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal"); //Collecting horizontal axis input and assignbing it to the variable

        if (Input.GetButtonDown("Jump") && IsGrounded()) //Testing if jump can be used
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f) //Allows for different height of jumping if the player holds the key down for longer than just tapping it.
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash) //Key assignment and trigger for the Dash ability
        {
            StartCoroutine(Dash());
        }

        Flip(); //Actively checks if 'Flip' needs to be used
    }

    private void FixedUpdate()
    {
        if (isDashing) //Prevents dash being spammed 
        {
            return;
        }

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y); //Makes the player move 
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); //Returns whether the player is touching the ground or not
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f) //Tests player's facing direction
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale; //Flips player if facing left
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private IEnumerator Dash()  //Coroutine holding the Dash ability 
    {
        canDash = false; //Dash is being triggered so 'canDash' is temporarily disabled
        isDashing = true; //Dash is being triggered so 'isDashing' is changed to true
        float originalGravity = rb.gravityScale; //variaable to hold original gravity
        rb.gravityScale = 0f; //Changes player's gravity to 0 temporarily so it doesn't impact 'dash'
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f); //Moves the player/performs the dash
        tr.emitting = true; //Triggers trail renderer
        yield return new WaitForSeconds(dashingTime); //Makes coroutine wait for the time dash is being performed
        tr.emitting = false; //Deactivates the trail renderer after dash is done
        rb.gravityScale = originalGravity; //Returns player's gravity back to normal
        isDashing = false; //Disables 'isDashing'
        yield return new WaitForSeconds(dashingCooldown); //Triggers cooldown of Dash
        canDash = true; //After cooldown is complete, the player can dash again

    }
}
