using UnityEngine;
using System.Collections;

public class TransitionManager : MonoBehaviour {

	public static  TransitionManager instance;
	Animator anim;


	void Awake()
	{
		if(instance == null) instance = this; else if(instance != this) Destroy(gameObject);

		anim = GetComponent<Animator>();
	}

	//Transiciones transicion = Transiciones.Corte;

	public void EjecutarTransicion(string _trigger)
	{
		print (_trigger);
		anim.SetTrigger(_trigger);

	}


	public void CambiarSigEscena(bool _volver)
	{
		// chequea primero si la escena tiene un evento que gatillar
		// antes de seguir a la otra escena
		if(!_volver && EventManager.eventManager.HasEvent())
		{
			// peo
		}
		else
		GameManager.instance.EjecutarTransicionSalida(_volver);
	}

	public void EjecutarTransicionEntrada()
	{
		GameManager.instance.EjecutarTransicionEntrada();
	}
}
