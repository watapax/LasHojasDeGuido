using UnityEngine;
using System.Collections;

public class Risas : MonoBehaviour {

	public float duracionMovimiento;

	Vector3 posOriginal;
	Vector3 target;
	bool mover;
	float t;

	EaseTypes ease;

	void Awake()
	{
		target = new Vector3(-7.4f , 0 , 0);
		posOriginal = transform.position;
		ease = new EaseTypes();
	}


	void FixedUpdate()
	{


		if(mover)
		{
			transform.localPosition = Vector3.Lerp(posOriginal , target , ease.Ease(EaseTypes.LerpType.Smooth , duracionMovimiento) );
		}




	}



	public void PanRight()
	{
		mover = true;
		// de dessuscribe del evento justo despues que se ejecuta
		EventManager.EventoEscena -= PanRight;

	}






	void OnEnable()
	{
		// subscribir evento
		EventManager.EventoEscena += PanRight;
	}

	void OnDisable()
	{
		// desuscribir evento
		EventManager.EventoEscena -= PanRight;
		transform.position = posOriginal;
		mover = false;
		ease.Resetear();
	}
}
