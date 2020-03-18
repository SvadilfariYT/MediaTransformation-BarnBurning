using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordPlayer : MonoBehaviour
{
    AudioSource[] audios;

    // Start is called before the first frame update
    void Start()
    {
        audios = GetComponents<AudioSource>();
        foreach (AudioSource audio in audios)
        {
            audio.Stop();
        }
    }

    public void PlayMusic()
    {
        float randomNumber = Random.Range(0, 2);

        if (randomNumber >= 1){
            audios[1].Stop();
            audios[0].Play();
        } else
        {
            audios[0].Stop();
            audios[1].Play();
        }
    }
}
