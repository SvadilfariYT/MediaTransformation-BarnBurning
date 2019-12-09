using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;

    // Start is called before the first frame update
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
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("ThemeMain");
    }

    public void Play(string name)
    {
        Sound s =Array.Find(sounds, sound => sound.name == name); //Searches for an element(Sound) named name (finds sound, where sound.name equals name)
        if (s == null) //check for NullPointerException
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Play();

        //Call FindObjectOfType<AudioManager>().Play("nameOfSound"); to play sound with name
    }
}
