using UnityEngine;
using System.Collections;

public class EaseTypes  {


	public float currentLerpTime;
	public enum LerpType{Linear, In, Out, Smooth};
	
	public float Ease(LerpType type, float duracion)
	{
		float lerpTime = duracion;
		currentLerpTime += Time.deltaTime;
		float t = currentLerpTime / lerpTime;
		
		switch(type)
		{
		case LerpType.Linear:
			return t;
		case LerpType.In:
			t = Mathf.Sin(t * Mathf.PI * 0.5f);
			break;
		case LerpType.Out:
			t = t*t;
			break;
		case LerpType.Smooth:
			t = t*t*t * (t * (6f*t - 15f) + 10f);
			break;
		}
		
		
		if (currentLerpTime > lerpTime) {
			currentLerpTime = lerpTime;
		}
		
		return t;
	}

	public void Resetear()
	{
		currentLerpTime = 0;
	}
}
