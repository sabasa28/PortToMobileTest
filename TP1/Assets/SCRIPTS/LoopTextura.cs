using UnityEngine;
using System.Collections;

public class LoopTextura : MonoBehaviour 
{
	public float Intervalo = 1;
	float Tempo = 0;
	
	public Texture2D[] Imagenes;
	int Contador = 0;

	// Use this for initialization
	void Start () 
	{
		if(Imagenes.Length > 0)
			GetComponent<Renderer>().material.mainTexture = Imagenes[0];
	}
	
	// Update is called once per frame
	void Update () 
	{
		Tempo += Time.deltaTime;
		
		if(Tempo >= Intervalo)
		{
			Tempo = 0;
			Contador++;
			if(Contador >= Imagenes.Length)
			{
				Contador = 0;
			}
			GetComponent<Renderer>().material.mainTexture = Imagenes[Contador];
		}
	}
}
