using UnityEngine;
using System.Collections;

public class ManoRecept : ManejoPallets 
{
	public bool TengoPallet = false;
	
	void FixedUpdate () 
	{
		TengoPallet = Tenencia();
	}
	
	void OnTriggerEnter(Collider other)
	{
		ManejoPallets recept = other.GetComponent<ManejoPallets>();
		if(recept != null)
		{
			Dar(recept);
		}
		
	}
	
	//---------------------------------------------------------//	
	
	public override bool Recibir(Pallet pallet)
	{
		if(!Tenencia())
		{
			pallet.Portador = this.gameObject;
			base.Recibir(pallet);
			return true;
		}
		else
			return false;
	}
	
	public override void Dar(ManejoPallets receptor)
	{
		//Debug.Log(gameObject.name+ " / Dar()");
		switch (receptor.tag)
		{
		case "Mano":
			if(Tenencia())
			{
				//Debug.Log(gameObject.name+ " / Dar()"+" / Tenencia=true");
				if(receptor.name == "Right Hand")
				{
					if(receptor.Recibir(Pallets[0]))
					{
						//Debug.Log(gameObject.name+ " / Dar()"+" / Tenencia=true"+" / receptor.Recibir(Pallets[0])=true");
						Pallets.RemoveAt(0);
						//Debug.Log("pallet entregado a Mano de Mano");
					}
				}
				
			}
			break;
			
		case "Cinta":
			if(Tenencia())
			{
				if(receptor.Recibir(Pallets[0]))
				{
					Pallets.RemoveAt(0);
					//Debug.Log("pallet entregado a Cinta de Mano");
				}
			}
			break;
			
		case "Estante":
			break;
		}
	}
}
