using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputType { LookDown, PS4 }

public class VRMoveCharacter : MonoBehaviour
{
    public InputType inputType;

    public Transform vrCamera;

    [SerializeField]
    public float toggleAngle = 30.0f;
    public float speed = 3.0f;
    public bool moveForward;
    public CharacterController cc;

    public string walkSound;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponentInParent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputType == InputType.LookDown)
        {
            if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90.0f)
            {
                moveForward = true;
            }
            else
            {
                moveForward = false;
            }
        }

        if(inputType == InputType.PS4)
        {
            if (Input.GetAxisRaw("Vertical")!= 0)
            {
                moveForward = true;
            }
            else
            {
                moveForward = false;
            }
        }
        

        if (moveForward)
        {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);

            cc.SimpleMove(forward * speed);

            //Plays Walking Sound when its not already Playing and Player is walking
            if (!FindObjectOfType<AudioManager>().IsPlaying(walkSound))
            {
                FindObjectOfType<AudioManager>().Play(walkSound);
            }
            
        }
        else
        {
            //Stops Walking Sound when Player is not moving
            if (FindObjectOfType<AudioManager>().IsPlaying(walkSound))
            {
                FindObjectOfType<AudioManager>().Stop(walkSound);
            }
        }
    }
}
