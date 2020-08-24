using UnityEngine;
using System.Collections;

public class Pallet : MonoBehaviour 
{
	public Valores Valor;
	public float Tiempo;
	public GameObject CintaReceptora = null;
	public GameObject Portador = null;
	public float TiempEnCinta = 1.5f;
	public float TempoEnCinta = 0;
	
	public enum Valores {Valor1 = 100000, 
						 Valor2 = 250000, 
						 Valor3 = 500000}
	
	
	public float TiempSmoot = 0.3f;
	float TempoSmoot = 0;
	public bool EnSmoot = false;
	
	//----------------------------------------------//
	
	void Start()
	{
		Pasaje();
	}
	
	void LateUpdate () 
	{
		if(Portador != null)
		{
			if(EnSmoot)
			{
				TempoSmoot += T.GetDT();
				if(TempoSmoot >= TiempSmoot)
				{
					EnSmoot = false;
					TempoSmoot = 0;
				}
				else
				{
					print("smoot");
					
					if(Portador.GetComponent<ManoRecept>() != null)
						transform.position = Portador.transform.position - Vector3.up * 1.2f;
					else
						transform.position = Vector3.Lerp(transform.position, Portador.transform.position, T.GetDT() * 10);
				}
				
			}
			else
			{
				print("crudo");
				
				if(Portador.GetComponent<ManoRecept>() != null)
					transform.position = Portador.transform.position - Vector3.up * 1.2f;
				else
					transform.position = Portador.transform.position;
					
			}
		}
			
	}
	
	//----------------------------------------------//
	
	public float GetBonus()
	{
		if(Tiempo > 0)
		{
			//calculo del bonus
		}
		return -1;
	}
	
	public void Pasaje()
	{
		EnSmoot = true;
		TempoSmoot = 0;
	}
}
