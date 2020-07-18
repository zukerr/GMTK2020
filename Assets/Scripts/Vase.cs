using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase : MonoBehaviour
{
    public Sprite brokenVase;
    SpriteRenderer sr;
    BoxCollider2D box;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        sr.sprite = brokenVase;
        box.isTrigger = true;
        int randX = Random.Range(0,2);
        if(randX == 1)
        {
            sr.flipX = true;
        }
        AudioManager.instance.Play("Vase");
        Destroy(this);
    }
}
