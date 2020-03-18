using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearObjectWhenLookDown : MonoBehaviour
{
    public Transform vrCamera;

    [SerializeField]
    public float toggleAngle = 80f;
    public float speed = 3.0f;
    public bool moveForward;
    public CharacterController cc;
    public GameObject objectToBeDestroyed;
    public bool alreadyActivated;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponentInParent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerStay(Collider other)
    {
        if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90.0f && !alreadyActivated)
        {
            //Do Something
            FindObjectOfType<Flash>().FlashPlayer();
            objectToBeDestroyed.GetComponent<DissolveSphere>().Dissolve();
            alreadyActivated = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {

    }
}
