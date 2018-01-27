using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[CreateAssetMenu(fileName = "New Environment Properties", menuName = "XJam/EnvironmentProps")]
class EnvironmentProps : ScriptableObject {

    [SerializeField]
    private int heightInBlock = 3;
    [SerializeField]
    private int widthInBlock = 4;
    [SerializeField]
    private float blockSizeInMeters = 2.5f;

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
}
