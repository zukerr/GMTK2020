using UnityEngine.Audio;
using UnityEngine;
using System;
using Onion;
public class AudioManager : MonoBehaviour
{

    [SerializeField]bool muted=false;
    [SerializeField]bool playThemeOnStart=false;
    [Space]
    public Sound[] sounds;
    public static AudioManager instance;
    public Sound theme;
    [Range(0,1)]
    public float volume=1f;
    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = muted?0:s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        theme.source = gameObject.AddComponent<AudioSource>();
        theme.source.clip = theme.clip;

        theme.source.volume = muted ? 0 : theme.volume;
        theme.source.pitch = theme.pitch;
        theme.source.loop = theme.loop;
        DontDestroyOnLoad(gameObject);
        
    }
    public void PlayRandomSquashSound()
    {
        int rand = UnityEngine.Random.Range(1,6);
        Play("Squash"+rand);
    }
    private void Start()
    {
        ChangeVolume(volume);
      if(playThemeOnStart){
            theme.source?.Play();
        }
    }
   public void PlayTheme()
    {
        theme.source.Play();
    }
    public void StopTheme()
    {
        theme.source.Stop();

    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s?.source.Play();
    }
    public bool IsPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        return s.source.isPlaying;
    }
    public bool IsThemePlaying()
    {
       
        return theme.source.isPlaying;
    }
    public void StopPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s?.source.Stop();
    }
    public void ChangeVolume(float vol)
    {
        volume=vol;
        vol = Mathf.Clamp(vol,0,1f);
        foreach (var item in sounds)
        {
            item.source.volume = item.volume*vol;
        }
        theme.source.volume = theme.volume*vol;
    }
}