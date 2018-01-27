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
            ver = Mathf.Lerp(ver,_ver, Time.deltaTime * smoothDelta);
        }
        else
        {
            hor = _hor;
            ver = _ver;
        }

        Vector3 dir = Camera.main.transform.forward * ver + hor * Camera.main.transform.right;
        dir.y = 0;
        controller.Move(dir * speed * Time.deltaTime);
        Debug.Log("moved");
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




    public int GetPlayer()
    {
        return player;
    }
}
