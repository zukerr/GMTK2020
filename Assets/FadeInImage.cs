using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInImage : MonoBehaviour
{
    public SpriteRenderer image;
    float alpha = 0;
    public float speed;
    public float offset = 5f;
    private float offsetTimer;
    private void Start()
    {
        offsetTimer = offset;
    }
    // Update is called once per frame
    void Update()
    {
        
        if (offsetTimer <= 0)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, alpha);
            alpha += Time.deltaTime * speed;
        }
        else
        {
            offsetTimer -= Time.deltaTime;
        }

    }
}
