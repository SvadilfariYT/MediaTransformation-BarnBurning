using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputType { LookDown, PS4 }

public class VRMoveCharacter : MonoBehaviour
{
    

    public Transform vrCamera;
    public CharacterController cc;

    [Header("Overall Settings")]
    public InputType inputType;
    public float speed = 3.0f;
    public bool moveForward;
    public Vector3 input;
    public Vector3 moveDirection = Vector3.zero;

    [Header("LookDown Settings")]
    [SerializeField]
    public float toggleAngle = 30.0f;
    
    

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
            input = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            //moveDirection = Vector3.Scale(vrCamera.forward, new Vector3(Input.GetAxis("Vertical"), 0.0f, Input.GetAxis("Horizontal")));
            moveDirection = transform.TransformDirection(input);
            moveDirection.y = -5f;
            cc.Move(moveDirection * Time.deltaTime * speed);

            //Walking Sound Management
            if (input.z > 0.2f )
            {
                moveForward = true;
            } else
            {
                moveForward = false;
            }
        }
        

        //Only for LookDown
        if (moveForward)
        {
            //Vector3 forward = vrCamera.TransformDirection(Vector3.forward);

            //cc.SimpleMove(forward * speed);

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
