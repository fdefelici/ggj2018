using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[CreateAssetMenu(fileName = "New Environment Properties", menuName = "XJam/EnvironmentProps")]
public class EnvironmentProps : ScriptableObject {

    [Header("Ground Dimensions")]
    [SerializeField]
    private int heightInBlock = 3;
    [SerializeField]
    private int widthInBlock = 4;
    [SerializeField]
    private int lengthInBlock = 4;
    [SerializeField]
    private float blockSizeInMeters = 2.5f;

    [Header("Rhythm Parameters")]
    [SerializeField]
    private float baseSpeed = 2.0f;
    [SerializeField]
    private float perkRotationSpeed = 2.0f;

    [Header("Disaster Parameters")]
    [SerializeField]
    private int rotateCameraAfterSeconds = 60;
    [SerializeField]
    private int resizeCameraAfterSeconds = 120;

    
    public float GetBaseSpeed() {
        return baseSpeed;
    }

    public float GetBlockSizeInMeters() {
        return blockSizeInMeters;
    }

    public int GetWidthInBlock() {
        return widthInBlock;
    }

    public int GetHeightInBlock() {
        return heightInBlock;
    }

    public float GetWidthInMeters() {
        return widthInBlock * blockSizeInMeters;
    }
    public float GetLengthInMeters() {
        return lengthInBlock * blockSizeInMeters;
    }

    public float GetPerkRotationSpeed()
    {
        return perkRotationSpeed;
    }

    public int GetRotateCameraAfterSeconds()
    {
        return rotateCameraAfterSeconds;
    }

    public int GetResizeCameraAfterSeconds()
    {
        return resizeCameraAfterSeconds;
    }
}
