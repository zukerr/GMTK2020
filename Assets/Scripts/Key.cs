using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public int channel;
    public ParticleSystem pickUpParticle;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        NewPlayerMovement player = collision.gameObject.GetComponent<NewPlayerMovement>();
        if(player != null)
        {
            GameEvents.instance.PickUpKey(channel);
            ParticleSystem part = Instantiate(pickUpParticle,transform.position,pickUpParticle.transform.rotation);
            ParticleSystem.MainModule main = part.main;
            main.startColor = GetComponent<SpriteRenderer>().color;
            AudioManager.instance.Play("Key");
            Destroy(gameObject);
        }
    }
}
