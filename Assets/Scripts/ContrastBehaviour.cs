using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContrastBehaviour : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        Destroy(this.gameObject);
        //TODO: Contrast Effect on Other Player
    }
}
