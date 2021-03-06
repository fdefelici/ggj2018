﻿using UnityEngine;

public class SparkBeahviour : ObstacleBeahviour {

    private int horizontalDirection = 1; //1=RIGHT, -1=LEFT

    void Start() {
        SetPlacement(ObstaclePlacementEnum.middle);
    }

    public void Update () {
        Vector3 vertical = -1 * Vector3.forward * Time.deltaTime * GetSpeed();
        Vector3 horizontal = horizontalDirection * Vector3.right * Time.deltaTime * GetSpeed();

        float currentX = transform.localPosition.x;
        float currentXRight = currentX + GetEnvConfig().GetBlockSizeInMeters()/2;
        float currentXLeft = currentX - GetEnvConfig().GetBlockSizeInMeters() / 2;

        if (horizontalDirection == 1 && currentXRight >= GetEnvConfig().GetWidthInMeters()/2) {
            horizontalDirection = -1;
            horizontal *= -1;
        } else if (horizontalDirection == -1 && currentXLeft <= -GetEnvConfig().GetWidthInMeters() / 2) {
            horizontalDirection = 1;
            horizontal *= -1;
        }
      
        transform.Translate(vertical + horizontal);
    }

    void OnTriggerEnter(Collider collider)
    {
        //play sound
        GetComponent<AudioSource>().Play();
        //player damage

        //Destroy its self
        gameObject.GetComponentInChildren<ParticleSystem>().Stop();
    }

}
