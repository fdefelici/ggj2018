using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levitate : MonoBehaviour
{

    private CharacterController controller;
    private PlayerJump playerJump;

    void Awake()
    {
        playerJump = GetComponent<PlayerJump>();
        controller = GetComponent<CharacterController>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (!playerJump.IsGravityEnabled())
            controller.Move(Mathf.Sin(Time.time * 4f) * (Vector3.up / 2f) * Time.deltaTime);

    }
}
