using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Woman : MonoBehaviour
{
    public GameObject objectToBeDestroyed;
    public bool alreadyActivated;

    public void DissolveBarn()
    {
        if (!alreadyActivated)
        {
            FindObjectOfType<Flash>().MineHit();
            objectToBeDestroyed.GetComponent<DissolveSphere>().Dissolve();
            alreadyActivated = true;
            StartCoroutine(Credits());
        }
    }

    IEnumerator Credits()
    {
        Debug.Log("Waiting for a few secs");
        yield return new WaitForSeconds(10f);
        Debug.Log("Loading Scene: 'Credits'");
        SceneManager.LoadScene("Credits");
    }
}
