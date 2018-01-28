using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehaviour : MonoBehaviour {

    [SerializeField]
    private EnvironmentProps envConfig;

    [SerializeField]
    List<GameObject> obstacles;
    [SerializeField]
    List<GameObject> perks;

    private float spawnTimer = 0.0f;
    private float elapsedTimer = 0.0f;

    private static int EASY_MODE = 1;
    private static int MEDI_MODE = 2;
    private static int HARD_MODE = 3;

    //[SerializeField]
    //[Range(1, 3)]
    private int difficulty = EASY_MODE;

    void Update() {
        elapsedTimer += Time.deltaTime;
        if (elapsedTimer >= 0 && elapsedTimer < 30) difficulty = EASY_MODE;
        else if (elapsedTimer >= 30 && elapsedTimer < 90) difficulty = MEDI_MODE;
        else difficulty = HARD_MODE;

        if (spawnTimer < envConfig.GetSpawnTimeRateInSeconds()) {
            spawnTimer += Time.deltaTime;
            return;
        }
        spawnTimer = 0;

        int numberOfMaxSpawn = 0;
        if (difficulty == EASY_MODE) numberOfMaxSpawn = 1;
        else if (difficulty == MEDI_MODE) numberOfMaxSpawn = 2;
        else numberOfMaxSpawn = 3;

        int numberOfSpawn = UnityEngine.Random.Range(1, numberOfMaxSpawn);

        int i = 0;
        int initialXBlock = UnityEngine.Random.Range(0, envConfig.GetWidthInBlock());
        float width = envConfig.GetWidthInMeters();
        float length = envConfig.GetLengthInMeters();
        do {
            GameObject obstaclePrefab = pickObjToSpawn();
            ObstacleBeahviour obs = obstaclePrefab.GetComponent<ObstacleBeahviour>();
            float randomXBlock = (initialXBlock + i) % envConfig.GetWidthInBlock();
            float randomYBlock = (int)obs.GetPlacement();
            float xPos = transform.position.x - width / 2 + (randomXBlock * envConfig.GetBlockSizeInMeters() + envConfig.GetBlockSizeInMeters() / 2);
            float yPos = transform.position.y + randomYBlock * envConfig.GetBlockSizeInMeters() + envConfig.GetBlockSizeInMeters() / 2;
            float zPos = transform.position.z + length / 2 + envConfig.GetSpawnDepthOffset();

            GameObject instance = Instantiate(obstaclePrefab, transform, true);
            instance.transform.position = new Vector3(xPos, yPos, zPos);
            instance.transform.rotation = Quaternion.identity;

            i++;
        } while (i < numberOfSpawn);
    }

    private GameObject pickObjToSpawn() {
        GameObject picked = null;
        float drawDice = UnityEngine.Random.Range(1, 100) / 100.0f;
        if (drawDice <= envConfig.GetSpawnObstacleChance()) {
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
