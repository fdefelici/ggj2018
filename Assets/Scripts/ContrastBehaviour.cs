using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContrastBehaviour : MonoBehaviour {

    private EffectsCamera effects;
    void Awake()
    {
        effects = GameObject.FindObjectOfType<EffectsCamera>();

    }

    void OnTriggerEnter(Collider other) {
        Destroy(this.gameObject);
        //TODO: Contrast Effect on Other Player
        effects.CameraCosePazze(other.gameObject);

    }
}
