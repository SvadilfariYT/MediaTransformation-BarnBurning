using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{

    public void PlaySound(string soundName) {

        FindObjectOfType<AudioManager>().Play(soundName);

    }
}
