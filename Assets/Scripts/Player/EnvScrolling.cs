using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvScrolling : MonoBehaviour {
    private static float _speed;
    private Material material;

    [SerializeField]
    private Vector2 scrolling;

    public static void SetSpeed(float speed)  {
        _speed = speed;
    }

    void Awake()
    {
        material = GetComponent<Renderer>().material;
        _speed = 1;
    }


	void Update () {
        material.mainTextureOffset += scrolling * Time.deltaTime * _speed;
	}
}
