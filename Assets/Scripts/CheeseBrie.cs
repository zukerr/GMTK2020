using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseBrie : MonoBehaviour
{
    [SerializeField]
    private float timeToDestroy = 20f;

    private bool isAutodestroying = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!isAutodestroying)
        {
            isAutodestroying = true;
            StartCoroutine(AutodestrCor());
        }
    }

    private IEnumerator AutodestrCor()
    {
        float maxTimeConst = timeToDestroy;
        while(timeToDestroy > 0)
        {
            timeToDestroy -= Time.deltaTime;
            float tempColor = GetComponent<SpriteRenderer>().color.g;
            tempColor -= Time.deltaTime / maxTimeConst;
            GetComponent<SpriteRenderer>().color = new Color
                (GetComponent<SpriteRenderer>().color.r, 
                tempColor, 
                GetComponent<SpriteRenderer>().color.b, 
                GetComponent<SpriteRenderer>().color.a);
            yield return null;
        }
        Destroy(gameObject);
    }
}
