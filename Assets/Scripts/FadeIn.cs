using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    public TextMeshProUGUI tm;
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
            tm.color = new Color(tm.color.r, tm.color.g, tm.color.b, alpha);
            alpha += Time.deltaTime * speed;
        }
        else
        {
            offsetTimer -= Time.deltaTime;
        }

    }
}
