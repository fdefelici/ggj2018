using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Post Processing Properties", menuName = "XJam/PostProcessing")]
public class PostProcessingConfig : ScriptableObject {

    [Header("CRT color grading")]
    [SerializeField]
    private Vector3 crtRed;
    [SerializeField]
    private Vector3 crtGreen;
    [SerializeField]
    private Vector3 crtBlue;


    [Header("Default color grading")]
    [SerializeField]
    private Vector3 defaultRed;
    [SerializeField]
    private Vector3 defaultGreen;
    [SerializeField]
    private Vector3 defaultBlue;

    //crt
    public Vector3 GetCrtRed()
    {
        return crtRed;
    }
    public Vector3 GetCrtGreen()
    {
        return crtGreen;
    }
    public Vector3 GetCrtBlue()
    {
        return crtBlue;
    }

    //default
    public Vector3 GetDefaultRed()
    {
        return defaultRed;
    }
    public Vector3 GetDefaultGreen()
    {
        return defaultGreen;
    }
    public Vector3 GetDefaultBlue()
    {
        return defaultBlue;
    }
}
