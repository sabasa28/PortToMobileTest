using UnityEngine;
using System.Collections;

public class AnimMngDesc : MonoBehaviour 
{
	public string AnimEntrada = "Entrada";
	public string AnimSalida = "Salida";
	public ControladorDeDescarga ContrDesc;
	
	enum AnimEnCurso{Salida,Entrada,Nada}
	AnimEnCurso AnimAct = AnimMngDesc.AnimEnCurso.Nada;
	
	public GameObject PuertaAnimada;
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Z))
			Entrar();
		if(Input.GetKeyDown(KeyCode.X))
			Salir();
		
		switch(AnimAct)
		{
		case AnimEnCurso.Entrada:
			
			if(!GetComponent<Animation>().IsPlaying(AnimEntrada))
			{
				AnimAct = AnimMngDesc.AnimEnCurso.Nada;
				ContrDesc.FinAnimEntrada();
				print("fin Anim Entrada");
			}
			
			break;
			
		case AnimEnCurso.Salida:
			
			if(!GetComponent<Animation>().IsPlaying(AnimSalida))
			{
				AnimAct = AnimMngDesc.AnimEnCurso.Nada;
				ContrDesc.FinAnimSalida();
				print("fin Anim Salida");
			}
			
			break;
			
		case AnimEnCurso.Nada:
			break;
		}
	}
	
	public void Entrar()
	{
		AnimAct = AnimMngDesc.AnimEnCurso.Entrada;
		GetComponent<Animation>().Play(AnimEntrada);
		
		if(PuertaAnimada != null)
		{
			PuertaAnimada.GetComponent<Animation>()["AnimPuerta"].time = 0;
			PuertaAnimada.GetComponent<Animation>()["AnimPuerta"].speed = 1;
			PuertaAnimada.GetComponent<Animation>().Play("AnimPuerta");
		}
	}
	
	public void Salir()
	{
		AnimAct = AnimMngDesc.AnimEnCurso.Salida;	
		GetComponent<Animation>().Play(AnimSalida);
		
		if(PuertaAnimada != null)
		{
			PuertaAnimada.GetComponent<Animation>()["AnimPuerta"].time = PuertaAnimada.GetComponent<Animation>()["AnimPuerta"].length;
			PuertaAnimada.GetComponent<Animation>()["AnimPuerta"].speed = -1;
			PuertaAnimada.GetComponent<Animation>().Play("AnimPuerta");
		}
	}
}
