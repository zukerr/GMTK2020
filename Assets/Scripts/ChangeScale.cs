using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScale : MonoBehaviour
{
    public float tickTime=1;
    private float timer;
    private void Start()
    {
        timer = tickTime;
    }
    // Update is called once per frame
    void Update()
    {
     timer-=Time.deltaTime;
        if (timer <= 0)
        {
        Scale();
            timer = tickTime;
        }
    }

    private void Scale()
    {
        transform.localScale  = new Vector3(-transform.localScale.x,1,1);

    }
}
