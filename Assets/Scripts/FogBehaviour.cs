using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogBehaviour : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        Destroy(this.gameObject);
        //TODO: Fogging Effect on Other Player
    }
}
