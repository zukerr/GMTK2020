using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class ShowAfter : MonoBehaviour
{
    public float time;
    public MonoBehaviour[] objToShow;
    [Range(0,3)]
    public int popSound = 1;

    // Update is called once per frame
    void Update()
    {
        if (time <= 0)
        {
            foreach (var item in objToShow)
            {
                item.enabled = true;
            }
            if(popSound != 0)
            {

            AudioManager.instance.Play("Pop"+popSound);
            }
            Destroy(this);
        }
        else
        {
        time-=Time.deltaTime;
        }

    }
}
