using UnityEngine;
using System.Collections;

public class Frenado : MonoBehaviour 
{
	public float VelEntrada = 0;
	public string TagDeposito = "Deposito";
	
	ControlDireccion KInput;
	
	
	float DagMax = 15f;
	float DagIni = 1f;
	int Contador = 0;
	int CantMensajes = 10;
	float TiempFrenado = 0.5f;
	float Tempo = 0f;
	
	Vector3 Destino;
	
	public bool Frenando = false;
	bool ReduciendoVel = false;
	
	//-----------------------------------------------------//
	
	// Use this for initialization
	void Start () 
	{
		//RestaurarVel();
		Frenar();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void FixedUpdate ()
	{
		if(Frenando)
		{
			Tempo += T.GetFDT();
			if(Tempo >= (TiempFrenado / CantMensajes) * Contador)
			{
				Contador++;
				//gameObject.SendMessage("SetDragZ", (float) (DagMax / CantMensajes) * Contador);
			}
			if(Tempo >= TiempFrenado)
			{
				//termino de frenar, que haga lo que quiera
			}
		}
	}
	
	void OnTriggerEnter(Collider other) 
	{
		if(other.tag == TagDeposito)
		{
			Deposito2 dep = other.GetComponent<Deposito2>();
			if(dep.Vacio)
			{	
				if(this.GetComponent<Player>().ConBolasas())
				{
					dep.Entrar(this.GetComponent<Player>());
					Destino = other.transform.position;
					transform.forward = Destino - transform.position;
					Frenar();
				}				
			}
		}
	}
	
	//-----------------------------------------------------------//
	
	public void Frenar()
	{
		//Debug.Log(gameObject.name + "frena");
		GetComponent<ControlDireccion>().enabled = false;
		gameObject.SendMessage("SetAcel", 0f);
		GetComponent<Rigidbody>().velocity = Vector3.zero;
		
		Frenando = true;
		
		//gameObject.SendMessage("SetDragZ", 25f);
		Tempo = 0;
		Contador = 0;
	}
	
	public void RestaurarVel()
	{
		//Debug.Log(gameObject.name + "restaura la velociad");
		GetComponent<ControlDireccion>().enabled = true;
		gameObject.SendMessage("SetAcel", 1f);
		Frenando = false;
		Tempo = 0;
		Contador = 0;
		//gameObject.SendMessage("SetDragZ", 1f);
	}
}
