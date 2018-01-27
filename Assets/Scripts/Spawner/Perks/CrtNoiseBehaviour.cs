using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrtNoiseBehaviour : MonoBehaviour {

    private EffectsCamera effects;
    void Awake()
    {
        effects = GameObject.FindObjectOfType<EffectsCamera>();

    }

    void OnTriggerEnter(Collider other) {
        Destroy(this.gameObject);
        //CRT Effect on Other Player
        effects.CameraCRTNoise(other.gameObject);

    }
}
