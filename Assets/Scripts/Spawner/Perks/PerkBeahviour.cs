using UnityEngine;

public class PerkBeahviour : ObstacleBeahviour {

	void Start () {
        SetPlacement(ObstaclePlacementEnum.bottom);
	}
	
	void Update () {
        transform.Rotate(Vector3.up * (GetEnvConfig().GetPerkRotationSpeed() * Time.deltaTime));
        //Non uso transform.Translate poiche altrimenti l'oggetto routerebbe circolarmente
        transform.position += -1 * Vector3.forward * Time.deltaTime * GetSpeed();
    }

}
