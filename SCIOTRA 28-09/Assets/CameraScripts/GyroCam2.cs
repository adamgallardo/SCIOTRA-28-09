using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using static System.Net.Mime.MediaTypeNames;

public class GyroCam2 : MonoBehaviour
{
    private float initialYAngle = 0f;
    private float appliedGyroYAngle = 0f;
    private float calibrationYAngle = 0f;

    void Start()
    {
        Input.gyro.enabled = true;
        Input.compass.enabled = true;
        transform.rotation = Quaternion.Euler(0, -Input.compass.trueHeading, 0);
        initialYAngle = transform.eulerAngles.y;
    }

    void Update()
    {
        ApplyGyroRotation();
        ApplyCalibration();
    }

    void OnGUI()
    {
        if (GUILayout.Button("Calibrate", GUILayout.Width(300), GUILayout.Height(100)))
        {
            CalibrateYAngle();
        }
    }

    public void CalibrateYAngle()
    {
        transform.rotation = Quaternion.Euler(0, -Input.compass.trueHeading, 0);
        calibrationYAngle = appliedGyroYAngle - initialYAngle; // Offsets the y angle in case it wasn't 0 at edit time.
    }

    void ApplyGyroRotation()
    {
        transform.rotation = Input.gyro.attitude;
        transform.Rotate(0f, 0f, 180f, Space.Self); // Swap "handedness" of quaternion from gyro.
        transform.Rotate(270f, 180f, 180f, Space.World); // Rotate to make sense as a camera pointing out the back of your device.
        appliedGyroYAngle = transform.eulerAngles.y; // Save the angle around y axis for use in calibration.
    }

    void ApplyCalibration()
    {
        transform.Rotate(0f, -calibrationYAngle, 0f, Space.World); // Rotates y angle back however much it deviated when calibrationYAngle was saved.
    }
    
}
