using UnityEngine;
using System.Collections;

public static class T 
{
	static float FDT;
	static float DT;
	
	
	
	public static float GetDT()
	{
		if(!FifadoDT)
			DT = Time.deltaTime * FactorDT;
		
		return DT;
	}
	
	public static float GetFDT()
	{
		if(!FifadoFDT)
			FDT = Time.fixedDeltaTime * FactorFDT;
		
		return FDT;
	}	
	
	//----------
	//fixed delta time
	public static float FactorFDT = 1;
	static bool FifadoFDT = false;
	public static void FijarFDT(float valor)
	{
		FifadoFDT = true; 
		FDT = valor;
	}
	public static void RestaurarFDT()
	{
		FifadoFDT = false; 
		FDT = Time.fixedDeltaTime;
		FactorFDT = 1;
	}
	
	//----------
	//delta time
	public static float FactorDT = 1;
	static bool FifadoDT = false;
	public static void FijarDT(float valor)
	{
		FifadoDT = true; 
		DT = valor;
	}
	public static void RestaurarDT()
	{
		FifadoDT = false; 
		DT = Time.deltaTime;
		FactorDT = 1;
	}
}
