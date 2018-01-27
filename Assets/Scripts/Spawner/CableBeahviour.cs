using UnityEngine;

public class CableBeahviour : ObstacleBeahviour {

    [SerializeField]
    private float speed;

	void Start () {
        SetPlacement(ObstaclePlacementEnum.top);
	}
	
	void Update () {
        //SOSTITUIRE CON IL MOVIMENTO USANDO IL RIGIDBODY in FIXED UPDATE
        transform.Translate(-1*Vector3.forward * Time.deltaTime * speed);
    }

}
