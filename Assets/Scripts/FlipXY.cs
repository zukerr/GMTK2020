using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipXY : MonoBehaviour
{
    SpriteRenderer sr;
    public float timeBtwChange;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        timer = timeBtwChange;
    }

    // Update is called once per frame
    void Update()
    {
        timer-=Time.deltaTime;
        if(timer <= 0)
        {
            timer = timeBtwChange;
            int rand = Random.Range(0,2);
            if(rand == 1)
            {

            sr.flipX = !sr.flipX;
            }
            else
            {
            sr.flipY = !sr.flipY;

            }
        }
    }
}
