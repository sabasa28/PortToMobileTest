using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour 
{
	CheakPoint CPAct;
	CheakPoint CPAnt;
	
	public float AngMax = 90;//angulo maximo antes del cual se reinicia el camion
	int VerifPorCuadro = 20;
	int Contador = 0;
	
	public float RangMinDer = 0;
	public float RangMaxDer = 0;
	
	bool IgnorandoColision = false;
	public float TiempDeNoColision = 2;
	float Tempo = 0;
	
	//--------------------------------------------------------//

	// Use this for initialization
	void Start () 
	{
		/*
		//a modo de prueba
		TiempDeNoColision = 100;
		IgnorarColision(true);
		*/
		
		//restaura las colisiones
		Physics.IgnoreLayerCollision(8,9,false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(CPAct != null)
		{
			Contador++;
			if(Contador == VerifPorCuadro)
			{
				Contador = 0;
				if(AngMax < Quaternion.Angle(transform.rotation, CPAct.transform.rotation))
				{
					Respawnear();
				}
			}
		}
		
		if(IgnorandoColision)
		{
			Tempo += T.GetDT();
			if(Tempo > TiempDeNoColision)
			{
				IgnorarColision(false);
			}
		}
		
	}
	
	//--------------------------------------------------------//
	
	public void Respawnear()
	{
		GetComponent<Rigidbody>().velocity = Vector3.zero;
		
		gameObject.SendMessage("SetGiro", 0f);
		
		if(CPAct.Habilitado())
		{
			if(GetComponent<Visualizacion>().LadoAct == Visualizacion.Lado.Der)
				transform.position = CPAct.transform.position + CPAct.transform.right * Random.Range(RangMinDer, RangMaxDer);
			else 
				transform.position = CPAct.transform.position + CPAct.transform.right * Random.Range(RangMinDer * (-1), RangMaxDer * (-1));
			transform.forward = CPAct.transform.forward;
		}
		else if(CPAnt != null)
		{
			if(GetComponent<Visualizacion>().LadoAct == Visualizacion.Lado.Der)
				transform.position = CPAnt.transform.position + CPAnt.transform.right * Random.Range(RangMinDer, RangMaxDer);
			else
				transform.position = CPAnt.transform.position + CPAnt.transform.right * Random.Range(RangMinDer * (-1), RangMaxDer * (-1));
			transform.forward = CPAnt.transform.forward;
		}
		
		IgnorarColision(true);
		
		//animacion de resp
		
	}
	
	public void Respawnear(Vector3 pos)
	{
		GetComponent<Rigidbody>().velocity = Vector3.zero;
		
		gameObject.SendMessage("SetGiro", 0f);
		
		transform.position = pos;
		
		IgnorarColision(true);
	}
	
	public void Respawnear(Vector3 pos, Vector3 dir)
	{
		GetComponent<Rigidbody>().velocity = Vector3.zero;
		
		gameObject.SendMessage("SetGiro", 0f);
		
		transform.position = pos;
		transform.forward = dir;
		
		IgnorarColision(true);
	}
	
	public void AgregarCP(CheakPoint cp)
	{
		if(cp != CPAct)
		{
			CPAnt = CPAct;
			CPAct = cp;
		}
	}
	
	void IgnorarColision(bool b)
	{
		//no contempla si los dos camiones respawnean relativamente cerca en el espacio 
		//temporal y uno de ellos va contra el otro, 
		//justo el segundo cancela las colisiones e inmediatamente el 1º las reactiva, 
		//entonces colisionan, pero es dificil que suceda. 
		
		Physics.IgnoreLayerCollision(8,9,b);
		IgnorandoColision = b;	
		Tempo = 0;
	}
	
	
	
	
}
