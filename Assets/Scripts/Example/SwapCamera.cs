using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapCamera : MonoBehaviour {

    public Transform player1;
    public Transform player2;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

        if(Input.GetKeyDown(KeyCode.M))
        {

            StartCoroutine("Swap");
        }
    }


    private IEnumerator Swap()
    {
        Vector3 oldP1 = player1.position;
        Vector3 oldP2 = player2.position;
        bool p1Done = false;
        bool p2Done = false;

        while(true)
        {
            if (Vector3.Distance(player1.position, oldP2) > 0.2f)
                player1.position = Vector3.Slerp(player1.position, oldP2, Time.deltaTime * 6f);
            else
            {
                player1.position = oldP2;
                p1Done = true;
            }

            if (Vector3.Distance(player2.position, oldP1) > 0.2f)
                player2.position = Vector3.Slerp(player2.position, oldP1, Time.deltaTime * 6f);
            else
            {
                player2.position = oldP1;
                p2Done = true;
            }

            if (p1Done && p2Done)
                break;

            yield return null;
        }
        

    }
}
