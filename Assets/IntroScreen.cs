using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       Invoke("NextScene",1f);
    }
    public void NextScene()
    {
         UIHandler.instance.FadeOut();
    }
    
}
