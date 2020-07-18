using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public int levelIndex;
    
    public void LoadMyLevel()
    {
                    AudioManager.instance.PlayTheme();
            AudioManager.instance.StopPlaying("Napisy");
        SceneManager.LoadScene(levelIndex);
    }
}
