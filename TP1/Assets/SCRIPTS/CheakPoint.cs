using UnityEngine;
using System.Collections;

public class CheakPoint : MonoBehaviour
{
	public string PlayerTag = "Player";
	bool HabilitadoResp = true;
	public float TiempPermanencia = 0.7f;//tiempo que no deja respaunear a un pj desp que el otro lo hizo.
	float Tempo = 0;

	// Use this for initialization
	void Start ()
	{
		GetComponent<Renderer>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!HabilitadoResp)
		{
			Tempo += T.GetDT();
			if(Tempo >= TiempPermanencia)
			{
				Tempo = 0;
				HabilitadoResp = true;
			}
		}
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == PlayerTag)
		{
			other.GetComponent<Respawn>().AgregarCP(this);
		}	
	}
	
	void OnTriggerExit(Collider other)
	{
		if(other.tag == PlayerTag)
		{
			HabilitadoResp = true;
		}
	}
	
	//---------------------------------------------------//
	
	public bool Habilitado()
	{
		if(HabilitadoResp)
		{
			HabilitadoResp = false;
			Tempo = 0;
			return true;
		}
		else
		{
			return HabilitadoResp;
		}
	}
}
