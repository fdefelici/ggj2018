using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayerBehaviour : MonoBehaviour {

    private EffectsCamera effects;
    void Awake()
    {
        effects = GameObject.FindObjectOfType<EffectsCamera>();

    }

    void OnTriggerEnter(Collider other) {
        Destroy(this.gameObject);
        //TODO: Switch Players Path
        effects.SwitchPlayer();
    }
}
