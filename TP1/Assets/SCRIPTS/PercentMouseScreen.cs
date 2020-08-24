using UnityEngine;
using System.Collections;

public class MousePos : MonoBehaviour 
{

	public enum AxisRelation{Horizontal, Vertical}

    static public float RelCalibration()
    {
        return 0.5f;//devuelve el centro de la pantalla, el mouse siempre deberia arrancar en el medio
    }

	static public float Relation(AxisRelation axisR)
	{
		float res;
		switch(axisR)
		{
		case AxisRelation.Horizontal:
			res = ((float)(Input.mousePosition.x / Screen.width)) *2 -1;
				return res;
				break;
			
			
		case AxisRelation.Vertical:
			res = ((float)(Input.mousePosition.y / Screen.height)) *2 -1;
			return res;
				break;
		}
		return -1;
	}
}
