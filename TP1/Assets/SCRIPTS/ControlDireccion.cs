using UnityEngine;
using System.Collections;

public class ControlDireccion : MonoBehaviour 
{
	public enum TipoInput {Mouse, Kinect, AWSD, Arrows}
	public TipoInput InputAct = TipoInput.Mouse;
	public CarController carController;
	public int playerNum;

	public Transform ManoDer;
	public Transform ManoIzq;
	
	public float MaxAng = 90;
	
	float Giro = 0;
	
	public enum Sentido {Der, Izq}
	
	public bool Habilitado = true;
	void Update () 
	{
		float axis = InputManager.Instance.GetAxis("Horizontal" + playerNum);
		//Debug.Log(InputManager.Instance.GetAxis("Horizontal" + playerNum));
		carController.SetGiro(axis);
	}

	public float GetGiro()
	{
		return Giro;
	}	
}
