using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBy : MonoBehaviour
{
    public float rotation = 15;
    public float tickTime=1;
    private float timer;
    private float rot;
    private void Start()
    {
        rot =rotation; 
        timer = tickTime;
    }
    // Update is called once per frame
    void Update()
    {
     timer-=Time.deltaTime;
        if (timer <= 0)
        {
        Rotate();
            timer = tickTime;
        }
    }

    private void Rotate()
    {
        transform.rotation = Quaternion.Euler(0,0,rot);
        rot+= rotation;
        if(rot > rotation)
        {
            rot = -rotation;
        }
    }
}
