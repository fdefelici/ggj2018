using UnityEngine;

public class ObstacleBeahviour : MonoBehaviour {

    [SerializeField]
    private ObstaclePlacementEnum placement;
    [SerializeField]
    private EnvironmentProps envConfig;

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


}
