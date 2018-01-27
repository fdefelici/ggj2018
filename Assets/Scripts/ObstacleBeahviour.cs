using UnityEngine;

public class ObstacleBeahviour : MonoBehaviour {

    [SerializeField]
    private ObstaclePlacementEnum placement;

    public ObstaclePlacementEnum GetPlacement() {
        return placement;
    }

    public void SetPlacement(ObstaclePlacementEnum aPlacement)  {
        placement = aPlacement;
    }


}
