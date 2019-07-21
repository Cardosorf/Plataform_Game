using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public float runSpeed = 400;

    private Rigidbody2D rb;

    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void FixedUpdate()
    {

        float move = Input.GetAxisRaw("Horizontal");

        

        rb.velocity = new Vector2(runSpeed * move * Time.fixedDeltaTime, rb.velocity.y);

        Flip(move);
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

}
