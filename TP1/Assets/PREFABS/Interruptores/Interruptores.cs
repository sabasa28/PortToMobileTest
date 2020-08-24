using UnityEngine;
using System.Collections;

public class Interruptores : MonoBehaviour 
{
	public string TagPlayer = "Player";
	
	public GameObject[] AActivar;
	
	public bool Activado = false;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnTriggerEnter(Collider other) 
	{
		if(!Activado)
		{
			if(other.tag == TagPlayer)
			{
				Activado = true;
				print("activado interrutor");
				for(int i = 0; i < AActivar.Length; i++)
				{
					AActivar[i].SetActiveRecursively(true);
				}
			}
		}
	}
}
