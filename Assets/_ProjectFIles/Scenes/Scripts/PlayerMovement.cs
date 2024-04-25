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

    [Range(1f, 20f)]
    public float dashFillAnimationSpeed = 5;
    
    public float maxDash = 1f;
    public float currentDash;
    public bool flipAttackArea;
    
    [Header("UI Components")]
    public UI_SliderController dashSliderUI;

    [Header("Audio Components")]
    //footsteps sound controller
    public FootstepsController footstepsController; // component should be attached to player
    
    

    private void Start()
    {
        animator = GetComponent<Animator>();

        //get the footsteps controller from the player gameobject
        footstepsController = this.GetComponent<FootstepsController>();

        //set the max dash value and set the slider value to the max dash value
        currentDash = maxDash;

        if (dashSliderUI != null)
        {
            dashSliderUI.SetMax(maxDash);
            dashSliderUI.SetFill(currentDash);
        }
        else
        {
            Debug.Log("Dash Slider UI is not set in the inspector: This is a UI component to show the dash bar.");
        }

        if (gameObject.GetComponent<FootstepsController>())
        {
           footstepsController = gameObject.GetComponent<FootstepsController>(); 
        }
        else
        {
            Debug.Log("Footsteps Controller script is not attached to the player gameobject: This is a script to control the footstep sounds.");
        }
    }

    private void Update()
    {

        

        if (rb.velocity.x != 0f && IsGrounded())
        {
            animator.SetBool("IsWalking", true);
            //call footsteps sound controller here
            if (footstepsController)
            {
                footstepsController.walking = true;
            }
            

        }
        else
        {
            animator.SetBool("IsWalking", false);
            if (footstepsController)
            {
                footstepsController.walking = false;
            }
        }

        if (isDashing)
        {
            return;
        }
       
   

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            //check the audio manager is present in the scene before playing the sound
            if (FindObjectOfType<AudioManager>())
            {
                FindObjectOfType<AudioManager>().Play("Jump");
            }

        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (rb != IsGrounded())
        {
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            //check the audio manager is present in the scene before playing the sound
            if (FindObjectOfType<AudioManager>())
            {
                FindObjectOfType<AudioManager>().Play("DashWoosh");
            }
            
            animator.SetBool("InDash", true) ;
            StartCoroutine(Dash());
            {
                
            }
        }
        else
        {
            animator.SetBool("InDash", false) ;
        }



        Flip();
        
      

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
            flipAttackArea = true;
        }
    }

    private IEnumerator Dash()
    {
        SetDashBar(0, dashFillAnimationSpeed);

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
        SetDashBar(1f, dashFillAnimationSpeed/4);
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
        if(dashSliderUI != null)
        {
            print("Start Dash - Call Dash UI Empty");
            currentDash = dashValue;
            dashSliderUI.SetFill(currentDash, sliderSpeed);
        }

    }
}
