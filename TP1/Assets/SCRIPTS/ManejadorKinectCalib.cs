using UnityEngine;
using System.Collections;

public class ManejadorKinectCalib : MonoBehaviour 
{
	public GameObject[] ParaAct;

	// Use this for initialization
	void Start ()
	{
		for(int i = 0; i < ParaAct.Length; i++)
		{
			ParaAct[i].SetActiveRecursively(false);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		//DISTINTAS CAMARAS
		if(Input.GetKeyDown(KeyCode.Keypad1))
		{
			for(int i = 0; i < ParaAct.Length; i++)
			{
				ParaAct[i].SetActiveRecursively(false);
			}
			
			if(ParaAct.Length >= 1)
				ParaAct[0].SetActiveRecursively(true);
		}
		if(Input.GetKeyDown(KeyCode.Keypad2))
		{
			for(int i = 0; i < ParaAct.Length; i++)
			{
				ParaAct[i].SetActiveRecursively(false);
			}
			
			if(ParaAct.Length >= 2)
				ParaAct[1].SetActiveRecursively(true);
		}
		if(Input.GetKeyDown(KeyCode.Keypad3))
		{
			for(int i = 0; i < ParaAct.Length; i++)
			{
				ParaAct[i].SetActiveRecursively(false);
			}
			
			if(ParaAct.Length >= 3)
				ParaAct[2].SetActiveRecursively(true);
		}
		
		//SALE AL VIDEO DE INTRO
		if(Input.GetKeyDown(KeyCode.Return) ||
		   Input.GetKeyDown(KeyCode.Backspace) ||
		   Input.GetKeyDown(KeyCode.KeypadEnter) ||
		   Input.GetKeyDown(KeyCode.Mouse0))
		{
			Application.LoadLevel(0);
		}
		//SALIR
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			Application.Quit();
		}
		
		//REINICIAR
		if(Input.GetKeyDown(KeyCode.Mouse1) ||
		   Input.GetKeyDown(KeyCode.Keypad0))
		{
			Application.LoadLevel(Application.loadedLevel);
		}
		
	}
}
