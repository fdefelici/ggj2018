using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisasterBeahviour : MonoBehaviour {

    [SerializeField]
    private EnvironmentProps envConfig;

    private float elapsedTime;

    private EffectsCamera effects;
    private bool _cameraRotateDone;
    private bool _cameraResizeDone;

    void Awake() {
        effects = GameObject.FindObjectOfType<EffectsCamera>();
        _cameraRotateDone = false;
        _cameraResizeDone = false;
    }

    void Update () {
        if (effects == null) return;
        if (_cameraResizeDone && _cameraRotateDone) return;

        elapsedTime += Time.deltaTime;
        if (isTimeForCameraResize()) { _cameraResizeDone = true; effects.CameraResize();}
        else if (isTimeForCameraRotate()) { _cameraRotateDone = true; effects.CameraRotate(); }

    }

    private bool isTimeForCameraRotate() {
        if (_cameraRotateDone) return false;
        if (elapsedTime < envConfig.GetRotateCameraAfterSeconds()) return false;
        return true;
    }

    private bool isTimeForCameraResize() {
        if (_cameraResizeDone) return false;
        if (elapsedTime < envConfig.GetResizeCameraAfterSeconds()) return false;
        return true;
    }
}
