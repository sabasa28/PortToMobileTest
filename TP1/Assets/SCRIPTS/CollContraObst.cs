using UnityEngine;
using System.Collections;

public class CollContraObst : MonoBehaviour 
{
	public float TiempEsp = 1;
	float Tempo1 = 0;
	public float TiempNoColl = 2;
	float Tempo2 = 0;
	
	enum Colisiones {ConTodo, EspDesact, SinObst}
	Colisiones Colisiono = CollContraObst.Colisiones.ConTodo;

	// Use this for initialization
	void Start () 
	{
		Physics.IgnoreLayerCollision(8,10,false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch (Colisiono)
		{
		case Colisiones.ConTodo:
			break;
			
		case Colisiones.EspDesact:
			Tempo1 += T.GetDT();
			if(Tempo1 >= TiempEsp)
			{
				Tempo1 = 0;
				IgnorarColls(true);
			}
			break;
			
		case Colisiones.SinObst:
			Tempo2 += T.GetDT();
			if(Tempo2 >= TiempNoColl)
			{
				Tempo2 = 0;
				IgnorarColls(false);
			}
			break;
		}
	}
	
	void OnCollisionEnter(Collision coll)
	{
		if(coll.gameObject.tag == "Obstaculo")
		{
			ColisionConObst();
		}
	}
	
	//-------------------------//
	
	void ColisionConObst()
	{
		switch (Colisiono)
		{
		case Colisiones.ConTodo:
			Colisiono = CollContraObst.Colisiones.EspDesact;
			break;
			
		case Colisiones.EspDesact:
			break;
			
		case Colisiones.SinObst:
			break;
		}
	}
	
	void IgnorarColls(bool b)
	{
		print("IgnorarColls() / b = " + b);
		
		if(name == "Camion1")
		{
			Physics.IgnoreLayerCollision(8,10,b);
		}
		else
		{
			Physics.IgnoreLayerCollision(9,10,b);
		}
		
		if(b)
		{
			Colisiono = CollContraObst.Colisiones.SinObst;
		}
		else
		{
			Colisiono = CollContraObst.Colisiones.ConTodo;
		}
	}
}
