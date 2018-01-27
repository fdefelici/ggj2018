using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    public Transform player;
    public Vector3 offset;

	// Use this for initialization
	void Start () {
        transform.position = player.position + offset;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
