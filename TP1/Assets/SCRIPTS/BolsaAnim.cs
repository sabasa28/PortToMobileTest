using UnityEngine;
using System.Collections;

public class BolsaAnim : MonoBehaviour 
{
	public float GiroVel = 1;
	
	public Vector3 Amlitud = Vector3.zero;
	//public float AmplitudVertical = 1;
	public float VelMov = 1;
	
	Vector3 PosIni;
	Vector3 vAuxPos = Vector3.zero;
	//float Aumento = 0;
	bool Subiendo = true;
	Vector3 vAuxGir = Vector3.zero;
	
	public bool Giro = true;
	public bool MovVert = true;
	
	//para que inicien a destiempo
	float TiempInicio;
	bool Iniciado = false;
	
	// Use this for initialization
	void Start ()
	{
		PosIni = transform.position;
		
		TiempInicio = Random.Range(0, 2);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Iniciado)
		{
			if(Giro)
			{
				vAuxGir = Vector3.zero;
				vAuxGir.y = T.GetDT() * GiroVel;
				transform.localEulerAngles += vAuxGir;
			}
			
			if(MovVert)
			{
				if(Subiendo)
				{
					transform.localPosition += Amlitud.normalized * Time.deltaTime * VelMov;
					
					if((transform.position - PosIni).magnitude > Amlitud.magnitude / 2)
					{
						Subiendo = false;
						transform.localPosition -= Amlitud.normalized * Time.deltaTime * VelMov;
					}
						
				}
				else
				{
					transform.localPosition -= Amlitud.normalized * Time.deltaTime * VelMov;
					if((transform.position - PosIni).magnitude > Amlitud.magnitude / 2)
					{
						Subiendo = true;
						transform.localPosition += Amlitud.normalized * Time.deltaTime * VelMov;
					}
						
				}
			}
		}
		else
		{
			TiempInicio -= Time.deltaTime;
			if(TiempInicio <= 0)
				Iniciado = true;
		}
	}
}
