using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PageHandler : MonoBehaviour
{
    public Transform pageSpawn;
    public GameObject page;
    private GameObject lastPage;
    public List<PagePanel> pages;
    int index = 0;
    private float timer=2;
    private float firstTimer=15f;
    private void Start()
    {
        pages[index].StartPage();
        Invoke("PlayIntroTheme",16f);
    }
    private void PlayIntroTheme()
    {
        AudioManager.instance.Play("Napisy");
    }
    public void NextPage()
    {
        StartCoroutine(EndPage(index));
        if(++index < pages.Count)
        {
            if(lastPage != null)
            {
                Destroy(lastPage);
            }
        lastPage = Instantiate(page,pageSpawn.position,Quaternion.identity);
            pages[index].StartPage();
            AudioManager.instance.Play("Page");
        }
        else
        {
            AudioManager.instance.StopPlaying("Napisy");
            AudioManager.instance.PlayTheme();
            SceneManager.LoadScene("Level0");
        }
  
    }
    IEnumerator EndPage(int indx)
    {
        yield return new WaitForSeconds(.35f);
        pages[indx].EndPage();

    }
    private void Update()
    {
        timer-=Time.deltaTime;
        firstTimer-=Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && timer <=0 && firstTimer <=0)
        {
            NextPage();
            timer=2;
        }
    }
    public void PlayBobIsNotYou()
    {
        AudioManager.instance.Play("Bobnotu");
    }
}
