using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] private List<WheelCollider> wheelCollider;
    [SerializeField] private List<Transform> wheels;

    public float maxSteerAngle = 34f;

    public float motorTorque = 200f;

    private void Update()
    {
        float motorInput = Input.GetAxis("Vertical");
        float steerInput = Input.GetAxis("Horizontal");

        float steerAngle = maxSteerAngle * steerInput;

        wheelCollider[0].steerAngle = steerAngle;
        wheelCollider[1].steerAngle = steerAngle;

        wheelCollider[2].motorTorque = motorTorque * motorInput;
        wheelCollider[3].motorTorque = motorTorque * motorInput;

        for (int i = 0; i < wheelCollider.Count; i++)
        {
            UpdateWheelVisual(wheelCollider[i], wheels[i]);
        }
    }

    private void UpdateWheelVisual(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;

        wheelCollider.GetWorldPose(out pos, out rot);

        wheelTransform.position = pos;
        wheelTransform.rotation = rot;
    }
}
