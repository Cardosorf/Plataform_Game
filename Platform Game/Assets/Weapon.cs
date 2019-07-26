using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public float offset;

    public Transform firePoint;
    public GameObject bullet;
    public bool isTrigged = false;
    private float timeBtwShots;
    public float startTimeBtwShots;


    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if(timeBtwShots <= 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }


        
    }

    void Shoot()
    {
        if(isTrigged)
            Instantiate(bullet, firePoint.position, transform.rotation);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            Debug.Log("teste");
            isTrigged = true;
        }
    }

}
