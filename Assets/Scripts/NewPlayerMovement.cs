using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerMovement : MonoBehaviour
{
    Rigidbody2D body;
    public Vector2 start;
    public float speed;
    private float sqrm;
    public static NewPlayerMovement instance;
    Vector2 dir;
    // Start is called before the first frame update
    private void Awake()
    {
        instance=this;
    }
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = start.normalized*speed;
        sqrm = body.velocity.sqrMagnitude;
    }

    private void Update()
    {
        if(body.velocity.sqrMagnitude < sqrm)
        {
            body.velocity = body.velocity.normalized*speed;
        }
        dir = body.velocity;
    }
    public void ChangeMovementVector(Vector2 dir)
    {
        body.velocity = dir.normalized*speed;
    }
     private void OnCollisionEnter2D(Collision2D collision)
    {
        Door door = collision.gameObject.GetComponent<Door>();
        if(door != null)
        {
            if (!door.locked)
            {
                ChangeMovementVector(dir);
            }
        }

    }
}
