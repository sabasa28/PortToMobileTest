using UnityEngine;
using System.Collections;

public class Inventario : MonoBehaviour 
{
	Player Pj;
	
	public Vector2 FondoPos = Vector2.zero;
	public Vector2 FondoEsc = Vector2.zero;
	
	public Vector2 SlotsEsc = Vector2.zero;
	public Vector2 SlotPrimPos = Vector2.zero;
	public Vector2 Separacion = Vector2.zero;
	
	public int Fil = 0;
	public int Col = 0;
	
	public Texture2D TexturaVacia;//lo que aparece si no hay ninguna bolsa
	public Texture2D TextFondo;
	
	Rect R;
	public GUISkin GS;
	
	//------------------------------------------------------------------//
	
	// Use this for initialization
	void Start () 
	{
		Pj = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnGUI()
	{
		
		switch(Pj.EstAct)
		{
		case Player.Estados.EnConduccion:
			GUI.skin = GS;
		
			//fondo
			GS.box.normal.background = TextFondo;
			R.width = FondoEsc.x * Screen.width /100;
			R.height = FondoEsc.y * Screen.height /100;
			R.x = FondoPos.x * Screen.width /100;
			R.y = FondoPos.y * Screen.height /100;
			GUI.Box(R,"");
			
			//bolsas
			R.width = SlotsEsc.x * Screen.width /100;
			R.height = SlotsEsc.y * Screen.height /100;
			int contador = 0;
			for(int j = 0; j < Fil; j++)
			{
				for(int i = 0; i < Col; i++)
				{
					R.x = SlotPrimPos.x * Screen.width / 100 + Separacion.x * i * Screen.width / 100;
					R.y = SlotPrimPos.y * Screen.height / 100 + Separacion.y * j * Screen.height / 100;
					
					if(contador < Pj.Bolasas.Length )//&& Pj.Bolasas[contador] != null)
					{
						if(Pj.Bolasas[contador]!=null)
							GS.box.normal.background = Pj.Bolasas[contador].ImagenInventario;
						else
							GS.box.normal.background = TexturaVacia;
					
					}
					else
					{
						GS.box.normal.background = TexturaVacia;
					}
					GUI.Box(R,"");
					
					contador++;
				}
			}
			GUI.skin = null;
				break;
		}
		
		
	}
	
	//------------------------------------------------------------------//
}
