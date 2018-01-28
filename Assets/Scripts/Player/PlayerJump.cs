using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(PlayerMovement))]
public class PlayerJump : MonoBehaviour
{

    [SerializeField]
    private Vector3 gravity;
    private Vector3 gravityAccumulator;

    [SerializeField]
    private Vector3 jumpForce;

    private CharacterController controller;
    private PlayerMovement movement;
    private bool gravityEnabled;

    public AudioClip jumpClip;
    private AudioSource audioSource;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        movement = GetComponent<PlayerMovement>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(gravityEnabled)
        {
            gravityAccumulator += gravity * Time.deltaTime;
            CollisionFlags flags = controller.Move(gravityAccumulator * Time.deltaTime);

            if((flags & (CollisionFlags.Below | CollisionFlags.CollidedBelow)) != 0)
            {
                gravityEnabled = false;
                gravityAccumulator = Vector3.zero;
            }
        }

        if(!gravityEnabled && GetJump())
        {
            gravityEnabled = true;
            gravityAccumulator = jumpForce;
            //play sound
            audioSource.clip = jumpClip;
            audioSource.Play();
        }
    }

    private bool GetJump()
    {
        int p = movement.GetPlayer();
        if(p == 1)
        {
            return (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button1));    //recalibration
        }
        else if(p == 2)
        {
            return (Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.Joystick2Button1));    //recalibration
        }
        return false;
    }
}