﻿using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip[] clips;

    [Range(0f, 1f)]
    public float volume;
    [Range(0.1f, 3f)]
    public float pitch = 1;
    [Range(0f, 0.5f)]
    public float rdmPitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
}
