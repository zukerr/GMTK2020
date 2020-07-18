using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinArea : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool player = NewPlayerMovement.instance.gameObject == collision.gameObject;
        if (player)
        {
            if(!UIHandler.instance.levelComplete)
            {
                NewPlayerMovement.instance.ChangeMovementVector(Vector2.zero);
                AudioManager.instance.StopTheme();
                AudioManager.instance.Play("Win");
                UIHandler.instance.CompleteLevel();
                //LoadNextLevel();
            }
        }
    }
}
