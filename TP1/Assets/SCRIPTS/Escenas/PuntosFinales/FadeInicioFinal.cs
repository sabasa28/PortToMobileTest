using UnityEngine;
using System.Collections;

public class FadeInicioFinal : MonoBehaviour 
{
	public float Duracion = 2;
	public float Vel = 2;
	float TiempInicial;
	
	MngPts Mng;
	
	Color aux;
	
	bool MngAvisado = false;

	// Use this for initialization
	void Start ()
	{
		//renderer.material = IniFin;
		Mng = (MngPts)GameObject.FindObjectOfType(typeof (MngPts));
		TiempInicial = Mng.TiempEspReiniciar;
		
		aux = GetComponent<Renderer>().material.color;
		aux.a = 0;
		GetComponent<Renderer>().material.color = aux;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if(Mng.TiempEspReiniciar > TiempInicial - Duracion)//aparicion
		{
			aux = GetComponent<Renderer>().material.color;
			aux.a += Time.deltaTime / Duracion;
			GetComponent<Renderer>().material.color = aux;			
		}
		else if(Mng.TiempEspReiniciar < Duracion)//desaparicion
		{
			aux = GetComponent<Renderer>().material.color;
			aux.a -= Time.deltaTime / Duracion;
			GetComponent<Renderer>().material.color = aux;
			
			if(!MngAvisado)
			{
				MngAvisado = true;
				Mng.DesaparecerGUI();
			}
		}
				
	}
}
