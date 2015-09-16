using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

	public static EventManager eventManager;

	public delegate void Eventos();
	public static event Eventos EventoEscena;


	void Awake()
	{
		eventManager = this;
	}


	// Chequea si el evento es null o tiene algun evento registrado
	public bool HasEvent()
	{
		bool tieneEvento = false;

		if(EventoEscena == null)
			tieneEvento = false;
		else if(EventoEscena != null)
		{
			tieneEvento = true;
			EventoEscena();
		}
			

		return tieneEvento;
	}


}
