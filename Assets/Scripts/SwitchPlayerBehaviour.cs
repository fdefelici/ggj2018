using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayerBehaviour : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        Destroy(this.gameObject);
        //TODO: Switch Players Path
    }
}
