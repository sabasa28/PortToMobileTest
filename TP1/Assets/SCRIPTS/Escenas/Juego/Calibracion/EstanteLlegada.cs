using UnityEngine;
using System.Collections;

public class EstanteLlegada : ManejoPallets
{

	public GameObject Mano;
	public ContrCalibracion ContrCalib;
	
	public override bool Recibir(Pallet p)
	{
        p.Portador = this.gameObject;
        base.Recibir(p);
        ContrCalib.FinTutorial();
        return true;
    }
}
