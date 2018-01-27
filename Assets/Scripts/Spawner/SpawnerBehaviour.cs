using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehaviour : MonoBehaviour {

    [SerializeField]
    private GameObject level;
    [SerializeField]
    private EnvironmentProps envConfig;

    private float width;
    private float lenght;

    //TODO: Spawning Algorithm
    //TODO: Destroy linked with pooling
    //TODO: After spawning set Visible when enter the background?!
    [SerializeField]
    List<GameObject> obstacles;

    [SerializeField]
    private float spawnTimeRateInSeconds = 2.0f;

    private float elapsedTime = 0.0f;

    void Awake() {
        Renderer render = level.GetComponent<Renderer>();
        Vector3 size = render.bounds.size;
        //Debug.Log("Render size: " + size);
        width = size.x;
        lenght = size.z;
    }
	
	void Update() {
        if (elapsedTime < spawnTimeRateInSeconds) {
            elapsedTime += Time.deltaTime;
            return;
        }

        elapsedTime = 0;

        GameObject obstaclePrefab = pickObstacleToSpawn();
        ObstacleBeahviour obs = obstaclePrefab.GetComponent<ObstacleBeahviour>();
        
        float randomXBlock = UnityEngine.Random.Range(0, envConfig.GetWidthInBlock());
        float randomYBlock = (int)obs.GetPlacement();
        float randomX = -width/2 + (randomXBlock * envConfig.GetBlockSizeInMeters() + envConfig.GetBlockSizeInMeters() /2);
        float randomY = randomYBlock * envConfig.GetBlockSizeInMeters() + envConfig.GetBlockSizeInMeters()/2;

        GameObject instance = Instantiate(obstaclePrefab, transform, true);
        //GameObject instance = Instantiate(obstaclePrefab, level.transform, true);
        instance.transform.position = new Vector3(randomX, randomY, lenght/2);
        instance.transform.rotation = Quaternion.identity;

    }

    private GameObject pickObstacleToSpawn() {
        int size = obstacles.Count;
        int index = UnityEngine.Random.Range(0, size);
        return obstacles[index];
    }
}
