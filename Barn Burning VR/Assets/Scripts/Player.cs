using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int barnState;

    private void Start()
    {
        barnState = 0;
    }

    private void setBarnState(int state)
    {
        if(barnState <= state)
        {
            barnState += 1;
        }
    }
}