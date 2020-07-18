using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!UIHandler.instance.levelComplete)
        {
            if (collision.gameObject == NewPlayerMovement.instance.gameObject)
            {
                NewPlayerMovement.instance.ChangeMovementVector(Vector2.zero);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
