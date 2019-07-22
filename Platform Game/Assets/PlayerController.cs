using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public float runSpeed = 400;
    public float jumpForce = 600;

    private bool facingRight = true;
    private bool isJumping = false;

    private Rigidbody2D rb;

    private Animator animator;


    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void FixedUpdate()
    {

        float move = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(move));

        rb.velocity = new Vector2(runSpeed * move * Time.fixedDeltaTime, rb.velocity.y);

        Flip(move);

        Jump();

        

        if(rb.velocity.y == 0f)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
        }

        if (rb.velocity.y > 0f)
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("isFalling", false);
            Debug.Log("Jumping");
            Debug.Log(rb.velocity.y);

        }

        if (rb.velocity.y < 0f)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", true);
            Debug.Log("Falling");
            Debug.Log(rb.velocity.y);
        }


        //transform.Translate(Input.GetAxisRaw("Horizontal") * runSpeed * Time.fixedDeltaTime,0f,0f);

    }

    private void Flip(float move)
    {

        if (move > 0 && !facingRight || move < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale; 

        }


    }

    private void Jump()
    {

        

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            //animator.SetBool("isJumping", true);
            rb.AddForce(new Vector2(0f, jumpForce));
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        //Debug.Log(collision.gameObject.name);

        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;

            rb.velocity = Vector2.zero;
            //rb.angularVelocity = 0f;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        //Debug.Log(collision.gameObject.name);

        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = true;

        }
    }

}
