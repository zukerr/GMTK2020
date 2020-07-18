using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : PlacedObject
{
    public float durability = 1;
    private float maxDur;
    private SpriteRenderer spriteRend;

    // Start is called before the first frame update
    void Start()
    {
        maxDur = durability;
        spriteRend = GetComponent<SpriteRenderer>();
        NewPlayerMovement.instance.ChangeMovementVector(GetOppositeVector(NewPlayerMovement.instance.transform.position));
    }

    // Update is called once per frame
    void Update()
    {
        RootingProccess();
    }

    private void FixColor()
    {
        spriteRend.color = new Color(durability/maxDur,1,durability/maxDur,1);
        transform.localScale -= Vector3.one*Time.deltaTime;
    }

    public void RootingProccess()
    {
        durability-= Time.deltaTime;
        FixColor();
        if(durability <= 0)
        {
            Destroy(gameObject);
        }
    }

    public Vector3 GetOppositeVector(Vector3 playerPosition)
    {
        return playerPosition - transform.position;
    }
}
