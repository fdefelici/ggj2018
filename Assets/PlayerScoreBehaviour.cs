using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScoreBehaviour : MonoBehaviour {

    public Text _pointText;

    void OnTriggerEnter(Collider aCollider) {
        PerkBeahviour perk = aCollider.GetComponent<PerkBeahviour>();
        if (perk != null) return; //Se è un perk non influisce sui punti

        int currentPoints = int.Parse(_pointText.text);
        currentPoints -= 100;
        _pointText.text = currentPoints+"";
    }

}
