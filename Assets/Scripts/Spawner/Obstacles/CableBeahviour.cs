using UnityEngine;

public class CableBeahviour : ObstacleBeahviour
{

    void Start()
    {
        SetPlacement(ObstaclePlacementEnum.bottom);
    }

    void Update()
    {
        transform.Translate(-1 * Vector3.forward * Time.deltaTime * GetSpeed());
    }

    void OnTriggerEnter(Collider col)
    {


        Destroy(gameObject);
    }

}
