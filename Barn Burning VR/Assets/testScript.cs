﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGaze()
    {
        Debug.Log("This is a barn");
        FindObjectOfType<AudioManager>().Play("ItemFound");
    }
}
