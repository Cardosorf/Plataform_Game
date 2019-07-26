using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    public float speed = 20f;
    public float lifeTime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;
    //public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBullet", lifeTime);
    }


    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Destroy(gameObject);
    //}


    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        
        if (hitInfo.collider != null)
        {
            Debug.Log(hitInfo.collider.name);
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                Debug.Log("enemy");
            }
            DestroyBullet();
        }

        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.name);

        Enemy enemy = collision.GetComponent<Enemy>();

        if (collision.CompareTag("Enemy"))
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }

    }

}
