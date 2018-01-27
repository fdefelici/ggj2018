using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvScrolling : MonoBehaviour {

    private Material material;

    [SerializeField]
    private Vector2 scrolling;

    void Awake()
    {
        material = GetComponent<Renderer>().material;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        material.mainTextureOffset += scrolling * Time.deltaTime;
	}
}
