using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Door : MonoBehaviour
{
    public int channel;
    public bool locked { get; private set;} = true;

    private void Start()
    {
        GameEvents.instance.OnKeyPickedUp += Unlock;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        NewPlayerMovement player = collision.gameObject.GetComponent<NewPlayerMovement>();
        if(player != null)
        {
            if (!locked)
            {
                AudioManager.instance.Play("Door");
                Destroy(gameObject);
            }
        }
    }
    

    public void Unlock(int key)
    {
        locked = key == channel ? false : true;
        if(!locked){
            GameEvents.instance.OnKeyPickedUp -= Unlock;
        }
    }
}
