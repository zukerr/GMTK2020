using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
	private Rigidbody2D rbody;
	private Animator anim;

    public float speed = 1f;
    public float radius = 2f;

    private Vector2 movementVector = Vector2.zero;

    public static PlayerMovement instance;
    private void Awake()
    {
        //instance = this;
    }
    // Use this for initialization
    void Start ()
    {
		rbody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
        movementVector = Vector2.up;
	}
	
	// Update is called once per frame
	void Update ()
    {
        LiveMovement();
	}

    private void RandomizeMovementVector(Collision2D collision)
    {
        Vector3 dir = collision.contacts[0].normal;
        float angle = Random.Range(-35f,35f);
        /*
        float angle = -Vector3.Angle(movementVector, dir);
        if(angle == -180f)
        {
            angle = Random.Range(-35f, 35f);
        }
        */
        //Debug.Log(angle);
        Vector2 rngPos = MoveVectorByAngle(dir,angle);
        movementVector = rngPos.normalized;
    }
    
    private Vector2 MoveVectorByAngle(Vector2 vector,float angle)
    {
        float rad = Mathf.Deg2Rad*angle;
        Vector2 rotatedVector = new Vector2(vector.x*Mathf.Cos(rad)-vector.y*Mathf.Sin(rad),vector.x*Mathf.Sin(rad)+vector.y*Mathf.Cos(rad));
        return rotatedVector;
    }
    private void LiveMovement()
    {
        if (movementVector != Vector2.zero)
        {
            anim.SetBool("iswalking", true);
            anim.SetFloat("input_x", movementVector.x);
            anim.SetFloat("input_y", movementVector.y);

            if (movementVector.x > 0f)
            {
                anim.SetBool("last_dir_right", true);
            }

            if (movementVector.x < 0f)
            {
                anim.SetBool("last_dir_right", false);
            }
        }
        else
        {
            anim.SetBool("iswalking", false);
        }

        rbody.MovePosition(rbody.position + movementVector.normalized * Time.fixedDeltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Door door = collision.gameObject.GetComponent<Door>();
        if(door != null)
        {
            if (door.locked)
            {
                
                    RandomizeMovementVector(collision);
                
            }
        }
        else
        {
            
                RandomizeMovementVector(collision);
            
        }
    }

    public void ChangeMovementVector(Vector2 newDirection) => movementVector = newDirection;
}
