using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSomethingOn : MonoBehaviour
{
    [SerializeField]
    private bool turnOn;
    [SerializeField]
    private GameObject[] objects;

    private void Start()
    {
        foreach (GameObject go in objects)
        {
            go.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" && turnOn)
        {
            foreach(GameObject go in objects)
            {
                go.SetActive(true);
            }
        }
    }
}
