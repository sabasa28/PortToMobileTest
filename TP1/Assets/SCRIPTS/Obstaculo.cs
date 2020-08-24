using UnityEngine;
using System.Collections;

public class Obstaculo : MonoBehaviour 
{
	public float ReduccionVel = 0;
	public float TiempEmpDesapa = 1;
	float Tempo1 = 0;
	public float TiempDesapareciendo = 1;
	float Tempo2 = 0;
	public string PlayerTag = "Player";
	
	bool Chocado = false;
	bool Desapareciendo = false;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Chocado)
		{
			Tempo1 += T.GetDT();
			if(Tempo1 > TiempEmpDesapa)
			{
				Chocado = false;
				Desapareciendo = true;
				GetComponent<Rigidbody>().useGravity = false;
				GetComponent<Collider>().enabled = false;
			}
		}
		
		if(Desapareciendo)
		{
			//animacion de desaparecer
			
			Tempo2 += T.GetDT();
			if(Tempo2 > TiempDesapareciendo)
			{
				gameObject.SetActiveRecursively(false);
			}
		}
	}
	
	void OnCollisionEnter(Collision coll)
	{
		if(coll.transform.tag == PlayerTag)
		{
			Chocado = true;
		}
	}
	
	//------------------------------------------------//
	
	protected virtual void Desaparecer()
	{}
	
	protected virtual void Colision()
	{}
}
