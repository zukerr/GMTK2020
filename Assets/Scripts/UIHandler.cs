using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    public GameObject levelCompleteGO;
    public Image fader;
    //public string nextLevelName;

    public static UIHandler instance;

    public bool levelComplete = false;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CompleteLevel()
    {
        

        levelCompleteGO.GetComponent<Animator>().SetBool("goingup", true);
        levelComplete = true;
    }

    public void FadeOut()
    {
        fader.gameObject.GetComponent<Animator>().SetBool("fadeout", true);
    }

    public void LoadNextLevel()
    {
        if(AudioManager.instance !=null)AudioManager.instance.PlayTheme();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
