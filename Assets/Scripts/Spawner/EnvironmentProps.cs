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
}
