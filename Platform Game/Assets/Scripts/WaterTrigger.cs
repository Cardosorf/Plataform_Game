using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class WaterTrigger : MonoBehaviour
{

    TilemapRenderer rend;

    float f = 0f;

    void Start()
    {
        rend = GetComponent<TilemapRenderer>();
        //Color c = rend.material.color;
        //c.a = 0f;
        //rend.material.color = c;

    }

    IEnumerator FadeOut()
    {
        for(f = 1f; f >= 0.65f; f -= 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    IEnumerator FadeIn()
    {

        for (; f <= 1f; f += 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("entrei");
        if(collision.CompareTag("Player"))
            StartCoroutine("FadeOut");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("sai");
        if(collision.CompareTag("Player"))
            StartCoroutine("FadeIn");
    }




}
