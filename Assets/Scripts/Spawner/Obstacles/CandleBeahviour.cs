﻿using UnityEngine;

public class CandleBeahviour : ObstacleBeahviour {

	void Start () {
        SetPlacement(ObstaclePlacementEnum.top);
	}

	void Update () {
        //SOSTITUIRE CON IL MOVIMENTO USANDO IL RIGIDBODY in FIXED UPDATE
        transform.Translate(-1*Vector3.forward * Time.deltaTime * GetSpeed());
    }

}