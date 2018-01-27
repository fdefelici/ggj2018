using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    [Range(1, 2)]
    private int player;                                 //number of player


    [SerializeField]
    private bool smoothAcceleration;
    [SerializeField]
    [Tooltip("Is ignored if smoothAcceleration param is toggled off")]
    private float smoothDelta;
    [SerializeField]
    private float speed;

    private float hor;
    private float ver;
    private CharacterController controller;


    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    // Use this for initialization
    void Start()
    {
        foreach (var item in Input.GetJoystickNames())
        {
            Debug.Log(item);
        }
    }

    // Update is called once per frame
    void Update()
    {

        float _hor = Clamp(Input.GetAxis(GetHorizontal()));
        float _ver = Clamp(Input.GetAxis(GetVertical()));
        if (smoothAcceleration)
        {
            hor = Mathf.Lerp(hor, _hor, Time.deltaTime * smoothDelta);
            ver = Mathf.Lerp(ver, _ver, Time.deltaTime * smoothDelta);
        }
        else
        {
            hor = _hor;
            ver = _ver;
        }

        Vector3 dir = GetMovementDirection();

        Vector3 newPos = transform.position + (dir * speed * Time.deltaTime);

       // if (IsInScreen(newPos))
            controller.Move(dir * speed * Time.deltaTime);
    }

    private string GetVertical()
    {
        if (player == 1) return "Vertical1";
        return "Vertical2";
    }
    private string GetHorizontal()
    {
        if (player == 1) return "Horizontal1";
        return "Horizontal2";
    }
    private float Clamp(float value)
    {
        if (value >= -0.2f && value <= 0.2f)
            return 0;
        return value;
    }
    private bool IsInScreen(Vector3 pos)
    {
        if (player == 1)
        {
            Vector3 sPos = GameObject.FindGameObjectWithTag("Camera1").GetComponent<Camera>().WorldToScreenPoint(pos);
            if (!(sPos.x <= 0 + 25 || sPos.x > Screen.width / 2 - 25) && !(sPos.y <= 0 || sPos.y > Screen.height / 2 + 25))                           //not out of window
                return true;
            return false;
        }
        else if (player == 2)
        {
            Vector3 sPos = GameObject.FindGameObjectWithTag("Camera2").GetComponent<Camera>().WorldToScreenPoint(pos);
            if (!(sPos.x <= Screen.width / 2 + 25 || sPos.x > Screen.width - 25) && !(sPos.y <= 0 || sPos.y > Screen.height / 2 + 25))                           //not out of window
                return true;
            return false;
        }
        return false;
    }
    private Vector3 GetMovementDirection()
    {
        Camera c = null;
        if (player == 1)
        {
            c = GameObject.FindGameObjectWithTag("Camera1").GetComponent<Camera>();
        }
        else if (player == 2)
        {
            c = GameObject.FindGameObjectWithTag("Camera2").GetComponent<Camera>();
        }
        //Vector3 dir = hor * c.transform.right + ver * c.transform.forward;
        Vector3 dir = Vector3.right * hor + Vector3.forward * ver;
        dir.y = 0;
        return dir;
    }




    public int GetPlayer()
    {
        return player;
    }
}
