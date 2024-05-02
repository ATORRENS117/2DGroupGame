using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementandDoublejump : MonoBehaviour
{
    float h; //Get input horizontal axis
    public float speed;
    Rigidbody2D rb;
    public float jumpForce;
    public Transform groundCheck;
    public LayerMask groundLayer;

    bool doubleJump;
    [SerializeField] bool doubleJumpSkill;
    private void Awake()
    {
      rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    // Update is called once per frame
  private void Update()
    {
        h = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("jump key");
            if (isGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                doubleJump = true;
            }
            else if (doubleJump && doubleJumpSkill)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                doubleJump = false; 
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("doubleJump"))
        {
            doubleJumpSkill = true;
            collision.gameObject.SetActive(false);
        }
    }

  

    bool isGrounded()
    {
        return Physics2D.OverlapBox(groundCheck.position, new Vector2(-0.114f, -0.053f), 0, groundLayer);
    }

}
