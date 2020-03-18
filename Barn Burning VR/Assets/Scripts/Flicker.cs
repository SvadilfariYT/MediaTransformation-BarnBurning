using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    [SerializeField]
    private Light fireLight;
    [SerializeField]
    private float minWaitTime;
    [SerializeField]
    private float maxWaitTime;
    [SerializeField]
    private float minIntensity;
    [SerializeField]
    private float maxIntensity;

    // Start is called before the first frame update
    void Awake()
    {
        fireLight = GetComponent<Light>();
        StartCoroutine(Flashing());
    }

    IEnumerator Flashing()
    {
        float duration = Random.Range(minWaitTime, maxWaitTime);
        float newIntensity = Random.Range(minIntensity, maxIntensity);

        //change values smoothly
        StartCoroutine(ChangeIntensity(fireLight.intensity, newIntensity, duration));

        //wait
        yield return new WaitForSeconds(duration + 0.01f);

        //Loop
        StartCoroutine(Flashing());
    }

    IEnumerator ChangeIntensity(float start, float end, float duration)
    {
        //used to capture elapsed time
        float elapsed = 0.0f;

        //main
        while (elapsed < duration)
        {
            fireLight.intensity = Mathf.Lerp(start, end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        fireLight.intensity = end;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
