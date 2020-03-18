using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveSphere : MonoBehaviour
{
    Material mat;

    [SerializeField]
    Material dissolveMaterial;
   
    public Material materialTwo;
    public GameObject text1;
    public GameObject text2;
  
    public void Dissolve() {
        foreach (Transform child in transform)
        {
            if(child.GetComponent<Renderer>() != null)
            {
                child.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                child.GetComponent<Renderer>().receiveShadows = false;
                child.GetComponent<Renderer>().material = dissolveMaterial;
                StartCoroutine(ChangeDissolve(0f, 1f, 5f, child));
            }
        }
        mat = GetComponent<Renderer>().material;
        //StartCoroutine(ChangeDissolve(0f, 1f, 5f));
    }

    void DisolveAnimation(float floatNumber)
    {
        mat.SetFloat("_DissolveAmount", floatNumber);
    }

    IEnumerator ChangeDissolve(float start, float end, float duration, Transform go)
    {
        yield return new WaitForSeconds(3f);

        //used to capture elapsed time
        float elapsed = 0.0f;

        //main
        while (elapsed < duration)
        {
            float fl = Mathf.Lerp(start, end, elapsed / duration);
            go.GetComponent<Renderer>().material.SetFloat("_DissolveAmount", fl);
            elapsed += Time.deltaTime;
            yield return null;
        }
        DisolveAnimation(end);

        gameObject.SetActive(false);
    }

}
