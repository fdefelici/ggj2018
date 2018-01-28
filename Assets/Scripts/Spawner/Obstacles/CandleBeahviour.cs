using UnityEngine;

public class CandleBeahviour : ObstacleBeahviour {

	void Start () {
        SetPlacement(ObstaclePlacementEnum.top);
	}

	void Update () {
        transform.Translate(-1*Vector3.forward * Time.deltaTime * GetSpeed());
    }

    void OnTriggerEnter(Collider collider) {
        //play sound
        GetComponent<AudioSource>().Play();
        //player damage

        //Destroy its self
        gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
    }
   
}
