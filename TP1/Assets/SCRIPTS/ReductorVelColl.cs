using UnityEngine;
using System.Collections;

public class ReductorVelColl : MonoBehaviour 
{
	public float ReduccionVel;
	bool Usado = false;
	public string PlayerTag = "Player";
	
	void OnCollisionEnter(Collision other) 
	{
		if(other.transform.tag == PlayerTag)
		{
			if(!Usado)
			{
				Chocado();
				//other.transform.GetComponent<AcelerAuto>().Chocar(this);
			}
		}
	}
	
	public virtual void Chocado()
	{
		Usado = true;
	}
}
