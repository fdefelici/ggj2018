using UnityEngine;

public class SparkBeahviour : ObstacleBeahviour {

    [SerializeField]
    private float speed;

    [SerializeField]
    private EnvironmentProps envConfig;

    private int horizontalDirection = 1; //1=RIGHT, -1=LEFT

    void Update () {
        Vector3 vertical = -1 * Vector3.forward * Time.deltaTime * speed;
        Vector3 horizontal = horizontalDirection * Vector3.right * Time.deltaTime * speed;
        //Debug.Log("X: " + transform.localPosition.x);
        float rightSize = envConfig.GetWidthInMeters() / 2 - envConfig.GetBlockSizeInMeters();
        //Debug.Log("Right: " + rightSize);

        float currentX = transform.localPosition.x;
        float currentXRight = currentX + envConfig.GetBlockSizeInMeters()/2;
        float currentXLeft = currentX - envConfig.GetBlockSizeInMeters() / 2;

        if (horizontalDirection == 1 && currentXRight >= envConfig.GetWidthInMeters()/2) {
            Debug.Log("PORCO");
            horizontalDirection = -1;
            horizontal *= -1;
        } else if (horizontalDirection == -1 && currentXLeft <= -envConfig.GetWidthInMeters() / 2) {
            horizontalDirection = 1;
            horizontal *= -1;
        }
      

        transform.Translate(vertical + horizontal);
    }

}
