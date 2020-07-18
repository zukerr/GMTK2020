using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public int firstLevelIndex;
    public Slider slider;
    public void StartFromFirstLevel()
    {
        SceneManager.LoadScene(firstLevelIndex);
        AudioManager.instance.StopPlaying("Napisy");
    }
    public void ExitQuit()
    {
        Application.Quit();
    }
    public void ChangeVolume()
    {
        float f = slider.value;
        AudioManager.instance.ChangeVolume(f);
    }
    private void Start()
    {
        AudioManager.instance.Play("Napisy");
        AudioManager.instance.StopPlaying("Theme");
    }
}
