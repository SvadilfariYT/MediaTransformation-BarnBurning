using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GvrBtn : MonoBehaviour
{
    public void onGazeEnter()
    {
        SceneManager.LoadScene("Main");
    }
}
