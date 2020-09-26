using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    public List<WheelCollider> throttleWheels = new List<WheelCollider>();
    public List<WheelCollider> steeringWheels = new List<WheelCollider>();
    public float throttleCoefficient = 20000f;
    public float maxTurn;
    float giro = 0f;
    float acel = 1f;
	
	void Update () { //update o fixed? 
        foreach (var wheel in throttleWheels) {
            wheel.motorTorque = throttleCoefficient * Time.fixedDeltaTime * acel;
        }
        foreach (var wheel in steeringWheels) {
            wheel.steerAngle = maxTurn * giro;
        }
        giro = 0f;
    }

    public void SetGiro(float _giro) {
        giro = _giro;
    }
    public void SetAcel(float val) {
        acel = val;
    }
}
