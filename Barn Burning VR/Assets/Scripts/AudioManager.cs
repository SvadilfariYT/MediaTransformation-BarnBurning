using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;

    //Awake is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject); //makes it Scene-persistent

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            //s.source.clip = s.clips[0];

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        //Play("ThemeMain");
        Play("FieldAmbiance");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name); //Searches for an element(Sound) named name (finds sound, where sound.name equals name)
        if (s == null) //check for NullPointerException
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        int randomnumber = UnityEngine.Random.Range(0, s.clips.Length);

        Debug.Log(randomnumber);

        //s.source.clip = s.clips[UnityEngine.Random.Range(0, s.clips.Length)];
        s.source.clip = s.clips[randomnumber];
        Debug.Log(s.source.clip);
        s.source.pitch = s.pitch + UnityEngine.Random.Range(-s.rdmPitch, s.rdmPitch);
        
        s.source.Play();

        //s.source.pitch = s.pitch;

        //Call FindObjectOfType<AudioManager>().Play("nameOfSound"); to play sound with name
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name); //Searches for an element(Sound) named name (finds sound, where sound.name equals name)
        if (s == null) //check for NullPointerException
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Stop();

        //Call FindObjectOfType<AudioManager>().Stop("nameOfSound"); to play sound with name
    }

    public void DeactivateLoop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name); //Searches for an element(Sound) named name (finds sound, where sound.name equals name)
        if (s == null) //check for NullPointerException
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.loop = false;
    }

    public void ActivateLoop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name); //Searches for an element(Sound) named name (finds sound, where sound.name equals name)
        if (s == null) //check for NullPointerException
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.loop = true;
    }

    public bool IsPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name); //Searches for an element(Sound) named name (finds sound, where sound.name equals name)
        if (s == null) //check for NullPointerException
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return false;
        }

        return s.source.isPlaying;
    }
}
