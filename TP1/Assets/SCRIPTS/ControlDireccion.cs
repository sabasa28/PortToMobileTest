using UnityEngine;
using System.Collections;

public class ControlDireccion : MonoBehaviour 
{
	public enum TipoInput {Mouse, Kinect, AWSD, Arrows}
	public TipoInput InputAct = ControlDireccion.TipoInput.Mouse;

	public Transform ManoDer;
	public Transform ManoIzq;
	
	public float MaxAng = 90;
	public float DesSencibilidad = 90;
	
	float Giro = 0;
	
	public enum Sentido {Der, Izq}
	Sentido DirAct;
	
	public bool Habilitado = true;
	//float Diferencia;
		
	//---------------------------------------------------------//
	
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch(InputAct)
		{
		case TipoInput.Mouse:
			if(Habilitado) 
				gameObject.SendMessage("SetGiro", MousePos.Relation(MousePos.AxisRelation.Horizontal));//debe ser reemplanado
			break;
			
		case TipoInput.Kinect:
			
			//print("Angulo: "+Angulo());
			/*
			if(ManoIzq.position.y > ManoDer.position.y)
			{
				DirAct = Sentido.Der;
				Diferencia = ManoIzq.position.y - ManoDer.position.y;
			}
			else
			{
				DirAct = Sentido.Izq;
				Diferencia = ManoDer.position.y - ManoIzq.position.y;
			}
			*/
			
			if(ManoIzq.position.y > ManoDer.position.y)
			{
				DirAct = Sentido.Der;
			}
			else
			{
				DirAct = Sentido.Izq;
			}
			
			switch(DirAct)
			{
			case Sentido.Der:
				if(Angulo() <= MaxAng)
					Giro = Angulo() / (MaxAng + DesSencibilidad);
				else
					Giro = 1;
				
				if(Habilitado)
					gameObject.SendMessage("SetGiro", Giro);//debe ser reemplanado
				
				break;
				
			case Sentido.Izq:
				if(Angulo() <= MaxAng)
					Giro = (Angulo() / (MaxAng + DesSencibilidad)) * (-1);
				else
					Giro = (-1);
				
				if(Habilitado)
					gameObject.SendMessage("SetGiro", Giro);//debe ser reemplanado
				
				break;
			}
			break;
            case TipoInput.AWSD:
                if (Habilitado) {
                    if (Input.GetKey(KeyCode.A)) {
                        gameObject.SendMessage("SetGiro", -1);
                    }
                    if (Input.GetKey(KeyCode.D)) {
                        gameObject.SendMessage("SetGiro", 1);
                    }
                }
                break;
            case TipoInput.Arrows:
                if (Habilitado) {
                    if (Input.GetKey(KeyCode.LeftArrow)) {
                        gameObject.SendMessage("SetGiro", -1);
                    }
                    if (Input.GetKey(KeyCode.RightArrow)) {
                        gameObject.SendMessage("SetGiro", 1);
                    }
                }
                break;
        }		
	}

	public float GetGiro()
	{
		/*
		switch(DirAct)
			{
			case Sentido.Der:
				if(Angulo() <= MaxAng)
					return Angulo() / MaxAng;
				else
					return 1;
				break;
				
			case Sentido.Izq:
				if(Angulo() <= MaxAng)
					return (Angulo() / MaxAng) * (-1);
				else
					return (-1);
				break;
			}
		*/
		
		return Giro;
	}
	
	float Angulo()
	{
		Vector2 diferencia = new Vector2(ManoDer.localPosition.x, ManoDer.localPosition.y)
						   - new Vector2(ManoIzq.localPosition.x, ManoIzq.localPosition.y);
		
		return Vector2.Angle(diferencia,new Vector2(1,0));
	}
	
}
