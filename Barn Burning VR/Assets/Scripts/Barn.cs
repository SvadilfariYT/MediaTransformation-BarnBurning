using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barn : MonoBehaviour
{
    [SerializeField]
    private GameObject oldRestrictions;
    [SerializeField]
    private GameObject newRestrictions;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            
            if(oldRestrictions != null)
            {
                oldRestrictions.SetActive(false);
            }
            if(newRestrictions != null)
            {
                newRestrictions.SetActive(true);
            }
            
        }
    }
}
