using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsCamera : MonoBehaviour {


    public Transform player1;
    public Transform player2;
    public Transform camera1;
    public Transform camera2;
    [Range(-1,1)][Tooltip("The direction of the rotation")]
    public int camera1Direction = -1;
    [Range(-1, 1)][Tooltip("The direction of the rotation")]
    public int camera2Direction = 1;

    public float switchSpeed;
    [Tooltip("Also define the speed of rotation. (ex. 3 seconds have a 120 degree per second of speed)")]
    public float rotateDuration;
    public float resizeSpeed;
    public float halfResizeDuration;
    public float crunchTime;
    public float crunchSpeed;
    public float swapTime;
    public float swapSpeed;
    public float timeBeforeReturn;



    private IEnumerator switchPlayer;
    private IEnumerator rot;
    private IEnumerator resize;
    private IEnumerator swap;





    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.M))
        {
            //CameraSwap();
            //CameraRotate();
            //CameraResize();
            CameraSwapViewport();
        }
    }

    public void CameraSwapViewport()
    {
        swap = SwapViewport();
        StartCoroutine(swap);
    }
    private IEnumerator SwapViewport()
    {
        Camera c1 = camera1.GetComponent<Camera>();
        Camera c2 = camera2.GetComponent<Camera>();

        Vector2 sizeGoal1 = new Vector2(c1.rect.size.x,c1.rect.size.y / 2);
        Vector2 sizeGoal2 = new Vector2(c2.rect.size.x, c2.rect.size.y / 2);

        //schiaccia
        for (float i = 0; i < crunchTime; i+= Time.deltaTime)
        {
            c1.rect = new Rect(c1.rect.position,Vector2.Lerp(c1.rect.size,sizeGoal1, Time.deltaTime * crunchSpeed));
            c2.rect = new Rect(Vector2.Lerp(c2.rect.position, new Vector2(c2.rect.x,0.5f),Time.deltaTime * crunchSpeed), Vector2.Lerp(c2.rect.size, sizeGoal2, Time.deltaTime * crunchSpeed));
            yield return null;
        }
        //swappa
        for (float i = 0; i < swapTime; i+= Time.deltaTime)
        {
            c1.rect = new Rect(Vector2.Lerp(c1.rect.position, new Vector2(0.5f, c1.rect.position.y), Time.deltaTime * swapSpeed), c1.rect.size);
            c2.rect = new Rect(Vector2.Lerp(c2.rect.position, new Vector2(0, c2.rect.position.y), Time.deltaTime * swapSpeed), c1.rect.size);
            yield return null;
        }
        //allarga
        for (float i = 0; i < crunchTime; i+= Time.deltaTime)
        {
            c1.rect = new Rect(c1.rect.position, Vector2.Lerp(c1.rect.size, new Vector2(c1.rect.size.x,1), Time.deltaTime * crunchSpeed));
            c2.rect = new Rect(Vector2.Lerp(c2.rect.position,new Vector2(c2.rect.position.x,0), Time.deltaTime * crunchSpeed), Vector2.Lerp(c2.rect.size, new Vector2(c2.rect.size.x, 1), Time.deltaTime * crunchSpeed));
            yield return null;
        }

        yield return new WaitForSeconds(timeBeforeReturn);


        //rischiaccia
        for (float i = 0; i < crunchTime; i += Time.deltaTime)
        {
            c1.rect = new Rect(c1.rect.position, Vector2.Lerp(c1.rect.size, sizeGoal1, Time.deltaTime * crunchSpeed));
            c2.rect = new Rect(Vector2.Lerp(c2.rect.position, new Vector2(c2.rect.x, 0.5f), Time.deltaTime * crunchSpeed), Vector2.Lerp(c2.rect.size, sizeGoal2, Time.deltaTime * crunchSpeed));
            yield return null;
        }
        //riswappa
        for (float i = 0; i < swapTime; i += Time.deltaTime)
        {
            c1.rect = new Rect(Vector2.Lerp(c1.rect.position, new Vector2(0, c1.rect.position.y), Time.deltaTime * swapSpeed), c1.rect.size);
            c2.rect = new Rect(Vector2.Lerp(c2.rect.position, new Vector2(0.5f, c2.rect.position.y), Time.deltaTime * swapSpeed), c1.rect.size);
            yield return null;
        }
        //riallarga
        for (float i = 0; i < crunchTime; i += Time.deltaTime)
        {
            c1.rect = new Rect(c1.rect.position, Vector2.Lerp(c1.rect.size, new Vector2(c1.rect.size.x, 1), Time.deltaTime * crunchSpeed));
            c2.rect = new Rect(Vector2.Lerp(c2.rect.position, new Vector2(c2.rect.position.x, 0), Time.deltaTime * crunchSpeed), Vector2.Lerp(c2.rect.size, new Vector2(c2.rect.size.x, 1), Time.deltaTime * crunchSpeed));
            yield return null;
        }

        c1.rect = new Rect(new Vector2(), new Vector2(0.5f,1));
        c2.rect = new Rect(new Vector2(0.5f,0), new Vector2(0.5f, 1));
    }

    public void SwitchPlayer()
    {
        switchPlayer = Switch();
        StartCoroutine(switchPlayer);
    }

    private IEnumerator Switch()
    {
        Vector3 oldP1 = player1.position;
        Vector3 oldP2 = player2.position;
        bool p1Done = false;
        bool p2Done = false;
        player1.GetComponent<PlayerMovement>().enabled = false;
        player2.GetComponent<PlayerMovement>().enabled = false;
        player1.GetComponent<PlayerJump>().enabled = false;
        player2.GetComponent<PlayerJump>().enabled = false;


        while (true)
        {
            if (Vector3.Distance(player1.position, oldP2) > 0.2f)
                player1.position = Vector3.Slerp(player1.position, oldP2, Time.deltaTime * switchSpeed);
            else
            {
                player1.position = oldP2;
                p1Done = true;
            }

            if (Vector3.Distance(player2.position, oldP1) > 0.2f)
                player2.position = Vector3.Slerp(player2.position, oldP1, Time.deltaTime * switchSpeed);
            else
            {
                player2.position = oldP1;
                p2Done = true;
            }

            if (p1Done && p2Done)
                break;

            yield return null;
        }


        //swap completed
        player1.GetComponent<PlayerMovement>().enabled = true;
        player2.GetComponent<PlayerMovement>().enabled = true;
        player1.GetComponent<PlayerJump>().enabled = true;
        player2.GetComponent<PlayerJump>().enabled = true;

    }


    public void CameraRotate()
    {
        rot = Rotate();
        StartCoroutine(rot);
    }

    private IEnumerator Rotate()
    {
        Quaternion startRotCamera1 = camera1.rotation;
        Quaternion startRotCamera2 = camera2.rotation;

        for (float i = 0; i < rotateDuration; i+= Time.deltaTime)
        {
            camera1.Rotate(Vector3.forward, 360 / rotateDuration * Time.deltaTime * camera1Direction);
            camera2.Rotate(Vector3.forward, 360 / rotateDuration * Time.deltaTime * camera2Direction);
            yield return null;
        }

        camera1.rotation = startRotCamera1;
        camera2.rotation = startRotCamera2;
    }



    public void CameraResize()
    {
        resize = Resize();
        StartCoroutine(resize);
    }

    private IEnumerator Resize()    //metri / tempo
    {
        Camera c1 = camera1.GetComponent<Camera>();
        Camera c2 = camera2.GetComponent<Camera>();


        for (float i = 0; i < halfResizeDuration; i+= Time.deltaTime)
        {
            Vector2 framePos1 = Vector2.Lerp(c1.rect.position, new Vector2(0.125f, 0.5f), Time.deltaTime * resizeSpeed);
            Vector2 frameSize1 = Vector2.Lerp(c1.rect.size, new Vector2(0.25f, 0.125f), Time.deltaTime * resizeSpeed);
            c1.rect = new Rect(framePos1, frameSize1);

            Vector2 framePos2 = Vector2.Lerp(c2.rect.position, new Vector2(0.65f, 0.5f), Time.deltaTime * resizeSpeed);
            Vector2 frameSize2 = Vector2.Lerp(c2.rect.size, new Vector2(0.25f, 0.125f), Time.deltaTime * resizeSpeed);
            c2.rect = new Rect(framePos2, frameSize2);
            yield return null;
        }

        for (float i = 0; i < halfResizeDuration; i+= Time.deltaTime)
        {
            Vector2 framePos1 = Vector2.Lerp(c1.rect.position, new Vector2(0, 0), Time.deltaTime * resizeSpeed);
            Vector2 frameSize1 = Vector2.Lerp(c1.rect.size, new Vector2(0.5f, 1), Time.deltaTime * resizeSpeed);
            c1.rect = new Rect(framePos1, frameSize1);

            Vector2 framePos2 = Vector2.Lerp(c2.rect.position, new Vector2(0.5f, 0f), Time.deltaTime * resizeSpeed);
            Vector2 frameSize2 = Vector2.Lerp(c2.rect.size, new Vector2(0.5f, 1), Time.deltaTime * resizeSpeed);
            c2.rect = new Rect(framePos2, frameSize2);
            yield return null;
        }

        c1.rect = new Rect(new Vector2(0, 0), new Vector2(0.5f, 1));
        c2.rect = new Rect(new Vector2(0.5f, 0), new Vector2(0.5f, 1));
    }
    
}
