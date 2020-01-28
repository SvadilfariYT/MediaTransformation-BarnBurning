using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudio : MonoBehaviour
{
    [SerializeField]
    private string audioName;
    [SerializeField]
    private bool loopAudio;

    public void OnTriggerEnter(Collider other)
    {
        if (!FindObjectOfType<AudioManager>().IsPlaying(audioName))
        {
            FindObjectOfType<AudioManager>().Play(audioName);
        }
        if (loopAudio)
        {
            FindObjectOfType<AudioManager>().ActivateLoop(audioName);
        }
        
    }

    public void OnTriggerExit(Collider other)
    {
        FindObjectOfType<AudioManager>().DeactivateLoop(audioName);
    }
}
