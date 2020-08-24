using UnityEngine;
using System.Collections;

public class EstanteLlegada : ManejoPallets
{

	public GameObject Mano;
	public ContrCalibracion ContrCalib;
	
	//-----------------------------------------------//

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	//--------------------------------------------------//
	
	public override bool Recibir(Pallet p)
	{
        p.Portador = this.gameObject;
        base.Recibir(p);
        ContrCalib.FinTutorial();

        return true;
    }
}
