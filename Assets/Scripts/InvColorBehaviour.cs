using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvColorBehaviour : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        Destroy(this.gameObject);
        //TODO: Invert Color Effect on Other Player
    }

}
