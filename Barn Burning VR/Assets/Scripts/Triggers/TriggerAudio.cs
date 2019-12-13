using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudio : MonoBehaviour
{
    public string audioName;

    public void OnTriggerEnter(Collider other)
    {
        if (!FindObjectOfType<AudioManager>().IsPlaying(audioName))
        {
            FindObjectOfType<AudioManager>().Play(audioName);
        }
        FindObjectOfType<AudioManager>().ActivateLoop(audioName);
    }

    public void OnTriggerExit(Collider other)
    {
        FindObjectOfType<AudioManager>().DeactivateLoop(audioName);
    }
}
