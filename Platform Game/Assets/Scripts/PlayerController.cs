using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public float runSpeed = 400;
    private float waterSpeed = 1;
    public float jumpForce = 600;
    
    private bool facingRight = true;
    private bool isJumping = false;

    float move;
    float jump;

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
        move = Input.GetAxisRaw("Horizontal");
        jump = Input.GetAxisRaw("Jump");
    }

    private void FixedUpdate()
    {

        rb.velocity = new Vector2(runSpeed * waterSpeed * move * Time.fixedDeltaTime, rb.velocity.y);

        PlayerAnimation(rb.velocity);

        Flip(move);

        //Call Jump() if player press space.
        if (jump != 0) { 
            Jump();
        }

        //transform.Translate(Input.GetAxisRaw("Horizontal") * runSpeed * Time.fixedDeltaTime,0f,0f);

    }

    private void Flip(float move)
    {
        if (move > 0 && !facingRight || move < 0 && facingRight)
        {
            facingRight = !facingRight;
            //Vector3 scale = transform.localScale;
            //scale.x *= -1;
            //transform.localScale = scale;

            transform.Rotate(0f,180f,0f);

        }
    }

    private void Jump()
    {
        if (!isJumping)
        {
            isJumping = true;
            //animator.SetBool("isJumping", true);
            rb.AddForce(new Vector2(0f, jumpForce));
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.name);

        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("WaterGround"))
        {
            isJumping = false;
            rb.velocity = Vector2.zero;
            //rb.angularVelocity = 0f;

        }

    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Hello");
        if (collision.gameObject.CompareTag("WaterGround"))
        {
            waterSpeed = 0.45f;
        }

        if (!collision.gameObject.CompareTag("WaterGround"))
        {
            waterSpeed = 1f;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.name);

        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("WaterGround"))
        {
            isJumping = true;
        }
    }


    private void PlayerAnimation(Vector2 vector)
    {

        animator.SetFloat("Speed", Mathf.Abs(move));

        if (vector.y == 0f)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", false);
        }

        if (vector.y > 0f)
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("isFalling", false);
            // Debug.Log("Jumping");
            // Debug.Log(rb.velocity.y);

        }

        if (vector.y < 0f)
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", true);
            //Debug.Log("Falling");
            //Debug.Log(rb.velocity.y);
        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyMovement enemyMovement = collision.GetComponent<EnemyMovement>();

        if (collision.CompareTag("Enemy"))
        {
            animator.SetBool("isDead", true);
            enemyMovement.hitPlayer = true;
            rb.velocity = Vector2.zero;
            runSpeed = 0;
            rb.gravityScale = 0;
            Invoke("CallScene", 2);


        }
    }

    void CallScene()
    {
        SceneManager.LoadScene(1);
    }


}
