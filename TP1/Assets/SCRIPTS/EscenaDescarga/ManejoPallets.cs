using UnityEngine;
using System.Collections;

public class ManejoPallets : MonoBehaviour 
{
	protected System.Collections.Generic.List<Pallet> Pallets = new System.Collections.Generic.List<Pallet>();
	public ControladorDeDescarga Controlador;
	protected int Contador = 0;
	
	public virtual bool Recibir(Pallet pallet)
	{
		Debug.Log(gameObject.name+" / Recibir()");
		Pallets.Add(pallet);
		pallet.Pasaje();
		return true;
	}
	
	public bool Tenencia()
	{
		
		if(Pallets.Count != 0)
			return true;
		else
			return false;
		
		/*
		if(Pallets.Count > Contador)
			return true;
		else
			return false;
			*/
	}
	
	public virtual void Dar(ManejoPallets receptor)
	{
		//es el encargado de decidir si le da o no la bolsa
	}
}
