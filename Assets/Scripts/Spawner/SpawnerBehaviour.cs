using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehaviour : MonoBehaviour {

    [SerializeField]
    private EnvironmentProps envConfig;

    //TODO: Destroy linked with pooling
    [SerializeField]
    List<GameObject> obstacles;
    [SerializeField]
    List<GameObject> perks;

    [SerializeField]
    private float SpawnObstacleChance = 0.8f;
    [SerializeField]
    private float spawnTimeRateInSeconds = 2.0f;
    [SerializeField]
    private float SpawnDepthOffset = 10f;

    private float elapsedTime = 0.0f;

	void Update() {
        if (elapsedTime < spawnTimeRateInSeconds) {
            elapsedTime += Time.deltaTime;
            return;
        }

        elapsedTime = 0;

        GameObject obstaclePrefab = pickObjToSpawn();
        ObstacleBeahviour obs = obstaclePrefab.GetComponent<ObstacleBeahviour>();


        float width = envConfig.GetWidthInMeters();
        float length = envConfig.GetLengthInMeters();

        float randomXBlock = UnityEngine.Random.Range(0, envConfig.GetWidthInBlock());
        float randomYBlock = (int)obs.GetPlacement();
        float xPos = transform.position.x - width/2 + (randomXBlock * envConfig.GetBlockSizeInMeters() + envConfig.GetBlockSizeInMeters() /2);
        float yPos = transform.position.y + randomYBlock * envConfig.GetBlockSizeInMeters() + envConfig.GetBlockSizeInMeters()/2;
        float zPos = transform.position.z + length / 2 + SpawnDepthOffset;

        GameObject instance = Instantiate(obstaclePrefab, transform, true);
        instance.transform.position = new Vector3(xPos, yPos, zPos);
        instance.transform.rotation = Quaternion.identity;
    }

    private GameObject pickObjToSpawn() {
        GameObject picked = null;
        float drawDice = UnityEngine.Random.Range(1, 100) / 100.0f;
        if (drawDice <= SpawnObstacleChance) {
            int size = obstacles.Count;
            int index = UnityEngine.Random.Range(0, size);
            picked = obstacles[index];
        } else {
            int size = perks.Count;
            int index = UnityEngine.Random.Range(0, size);
            picked = perks[index];
        }
        return picked;
    }

   
}
