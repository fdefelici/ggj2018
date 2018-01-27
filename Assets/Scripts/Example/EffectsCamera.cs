using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsCamera : MonoBehaviour {


    public Transform player1;
    public Transform player2;

    public float swapSpeed;
    [Tooltip("Also define the speed of rotation. (ex. 3 seconds have a 120 degree per second of speed)")]
    public float rotateDuration;



    private IEnumerator swap;
    private IEnumerator rot;





    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.M))
        {
            CameraSwap();
        }
    }

    public void CameraSwap()
    {
        swap = Swap();
        StartCoroutine(swap);
    }

    private IEnumerator Swap()
    {
        Vector3 oldP1 = player1.position;
        Vector3 oldP2 = player2.position;
        bool p1Done = false;
        bool p2Done = false;
        player1.GetComponent<PlayerMovement>().enabled = false;
        player2.GetComponent<PlayerMovement>().enabled = false;
        player1.GetComponent<PlayerJump>().enabled = false;
        player2.GetComponent<PlayerJump>().enabled = false;


        while (true)
        {
            if (Vector3.Distance(player1.position, oldP2) > 0.2f)
                player1.position = Vector3.Slerp(player1.position, oldP2, Time.deltaTime * swapSpeed);
            else
            {
                player1.position = oldP2;
                p1Done = true;
            }

            if (Vector3.Distance(player2.position, oldP1) > 0.2f)
                player2.position = Vector3.Slerp(player2.position, oldP1, Time.deltaTime * swapSpeed);
            else
            {
                player2.position = oldP1;
                p2Done = true;
            }

            if (p1Done && p2Done)
                break;

            yield return null;
        }


        //swap completed
        player1.GetComponent<PlayerMovement>().enabled = true;
        player2.GetComponent<PlayerMovement>().enabled = true;
        player1.GetComponent<PlayerJump>().enabled = true;
        player2.GetComponent<PlayerJump>().enabled = true;

    }

    //private IEnumerator Rotate()
    //{
    //    for (int i = 0; i < length; i++)
    //    {

    //    }
    //}

}
