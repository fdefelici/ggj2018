using UnityEngine;

public class ObstacleBeahviour : MonoBehaviour {

    [SerializeField]
    private ObstaclePlacementEnum placement;
    [SerializeField]
    private EnvironmentProps envConfig;

    public float originalZ;

    public void Await() {
        originalZ = transform.position.z;
    }


    public ObstaclePlacementEnum GetPlacement() {
        return placement;
    }

    public void SetPlacement(ObstaclePlacementEnum aPlacement)  {
        placement = aPlacement;
    }

    public float GetSpeed() {
        return envConfig.GetBaseSpeed();
    }

    public EnvironmentProps GetEnvConfig() {
        return envConfig;
    }

    void LateUpdate() {
        //Distruggi se oltrepassa il giocatore.
        float offsetZ = GetEnvConfig().GetSpawnDepthOffset() + GetEnvConfig().GetLengthInMeters();
        if (transform.position.z < originalZ - offsetZ) { Destroy(gameObject); }
    }


}
