using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    [SerializeField]
    private GameObject btn;
    [SerializeField]
    private GameObject title;
    [SerializeField]
    private float btnAppearTime;

    private void Start()
    {
        btn.SetActive(false);
        //title.SetActive(true);

        StartCoroutine(btnAppear(btnAppearTime)
);
    }

    IEnumerator btnAppear(float btnAppearTime)
    {
        yield return new WaitForSeconds(btnAppearTime);
        btn.SetActive(true);
    }
}