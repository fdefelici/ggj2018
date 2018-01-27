using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateMesh : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MeshRenderer[] rends = transform.GetComponentsInChildren<MeshRenderer>();
        foreach (var item in rends)
        {
            item.enabled = false;
        }
	}
	
	
}
