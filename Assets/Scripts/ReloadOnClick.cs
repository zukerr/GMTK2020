using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadOnClick : MonoBehaviour
{
    public void Reload()
    {
        if (!AudioManager.instance.IsThemePlaying())
        {
            AudioManager.instance.PlayTheme();
        }
        LevelLoader.ReloadScene();
    }
}
