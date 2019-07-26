using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject chest;
    public Transform chestPlace;
    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(chest, chestPlace.position, chestPlace.rotation);
        GameObject.Find("EnemyDeadSound").GetComponent<AudioSource>().Play();
        GameObject.Find("Music").GetComponent<AudioSource>().Stop();
        GameObject.Find("WinSound").GetComponent<AudioSource>().Play();
        Destroy(gameObject);
    }
}
