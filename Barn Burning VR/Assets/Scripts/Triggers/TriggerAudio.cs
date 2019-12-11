using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAudio : MonoBehaviour
{
    public string audioName;

    public void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<AudioManager>().Play(audioName);
    }

    public void OnTriggerExit(Collider other)
    {
        FindObjectOfType<AudioManager>().Stop(audioName);
    }
}
