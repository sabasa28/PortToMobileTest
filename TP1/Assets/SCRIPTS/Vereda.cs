using UnityEngine;
using System.Collections;

public class Vereda : MonoBehaviour 
{
	public string PlayerTag = "Player";
	public float GiroPorSeg = 0;
	public float RestGiro = 0; // valor que se le suma al giro cuando sale para restaurar la estabilidad

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	
	void OnTriggerStay(Collider other)
	{
		if(other.tag == PlayerTag)
		{
			other.SendMessage("SumaGiro", GiroPorSeg * T.GetDT());
		}	
	}
	
	void OnTriggerExit(Collider other)
	{
		if(other.tag == PlayerTag)
		{
			other.SendMessage("SumaGiro", RestGiro);
		}	
	}
}
