using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float moveSpeed;

    public float frequency;

    public float magnitude;

    bool facingRight = false;

    public bool hitPlayer = false;

    Vector3 pos, localScale;


    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hitPlayer)
        {
            if (pos.x < 3f)
                facingRight = true;
            else if (pos.x > 18f)
                facingRight = false;

            if (facingRight)
                MoveRight();
            else
                MoveLeft();
        }

    }

    private void MoveRight()
    {
        pos += transform.right * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
    }

    private void MoveLeft()
    {
        pos -= transform.right * Time.deltaTime * moveSpeed;
        transform.position = pos + transform.up * Mathf.Sin(Time.time * frequency) * magnitude;
    }
}
