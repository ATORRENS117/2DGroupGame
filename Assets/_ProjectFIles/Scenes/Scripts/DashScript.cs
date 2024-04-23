using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private TrailRenderer tr;
    private Animator animator;
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 30f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 3f;
    
    public float maxDash = 1f;
    public float currentDash;
    [FormerlySerializedAs("uiSliderController")] [FormerlySerializedAs("dashUI")] public UI_SliderController dashSliderUI;

    private void Start()
    {
        animator = GetComponent<Animator>();
        
        //set the max dash value and set the slider value to the max dash value
        currentDash = maxDash;
        dashSliderUI.SetMax(maxDash);
        dashSliderUI.SetFill(currentDash);
    }

    // not sure what this is for?
    // private void OnConnectedToServer() 
    // {
    //     currentDash = maxDash;
    //     dashSliderUI.SetMax(maxDash);
    // }
    private void Update()
    {
      
        if (isDashing)
        {
            animator.SetBool("InDash", true);
            return;
        }
        else
        {
            animator.SetBool("InDash", false);
        }
   

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
            {
                SetDashBar(0,dashingCooldown*4);
            }
        }
       



        Flip();

        if (rb.velocity.x != 0f)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
        
        if (rb != IsGrounded())
        {
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y); 

       
       
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private IEnumerator Dash()
    {

        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;

        print("End Dash - Reset Dash UI Fill");
        SetDashBar(1f, dashingCooldown);
    }

    // add a plus or minus value to set the dash bar 
    void SetDashBar(float dashValue)
    {
        print("Start Dash - Call Dash UI Empty");
        currentDash = dashValue;
        dashSliderUI.SetFill(currentDash);
    }
    // add a plus or minus value to set the dash bar - sliderspeed is optional override to set the speed of the bar refill
    void SetDashBar(float dashValue, float sliderSpeed)
    {
        print("Start Dash - Call Dash UI Empty");
        currentDash = dashValue;
        dashSliderUI.SetFill(currentDash, sliderSpeed);
    }

}
