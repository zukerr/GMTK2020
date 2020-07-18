using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseDirection : PlacedObject
{
    private int durability = 1;

    [SerializeField]
    private Transform dirTransform = null;

    private Vector3 newDir;
    // Start is called before the first frame update
    void Start()
    {
        SetupNewDir();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleDirectionChange();
    }

    public void GetHit()
    {
        durability--;
        if (durability == 0)
        {
            Destroy(gameObject);
        }
    }

    private void SetupNewDir()
    {
        newDir = (dirTransform.position - transform.position).normalized;
    }

    private void HandleDirectionChange()
    {
        float temp = Vector3.Distance(NewPlayerMovement.instance.transform.position, transform.position);
        if (temp < Time.deltaTime*NewPlayerMovement.instance.speed)
        {
            NewPlayerMovement.instance.ChangeMovementVector(newDir);
            GetHit();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        NewPlayerMovement.instance.ChangeMovementVector((transform.position - NewPlayerMovement.instance.transform.position).normalized);
    }
}
