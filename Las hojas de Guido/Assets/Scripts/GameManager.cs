using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public List <GameObject> escenas = new List<GameObject>();

	int sceneCount = 0;		// que escena se eta viendo
	bool volver;			// se activa si se apreta el boton patras

	void Awake()
	{
		// Singleton
		if(instance == null) instance = this; else if(instance != this) Destroy(gameObject);

		// Desactivar escenas
		for(int i = 0; i < escenas.Count; i++){escenas[i].SetActive(false);}

		ActivarEscena(0);
	}

	// Activa una escena en particular
	void ActivarEscena(int _index)
	{
		escenas[_index].SetActive(true);
	}


	// Ejecuta la transicion de salida de la escena
	public void EjecutarTransicionSalida(bool _volver)
	{
		// no sigue avanzando si llego a la ultima y no sigue retrocediendo si llego a la primera
		if((!_volver && sceneCount == escenas.Count - 1) || (_volver && sceneCount == 0))return;

		volver = _volver;
		string trigger;

		if(!_volver)
			trigger =  escenas[sceneCount].GetComponent<Escena>().transicionSalida.ToString();
		else
			trigger =  escenas[sceneCount].GetComponent<Escena>().transicionVuelta.ToString();

		TransitionManager.instance.EjecutarTransicion(trigger);
	}


	// Avanzar escena siguiente o devolverse escena anterior
	public void EjecutarTransicionEntrada()
	{
		if(volver && sceneCount == 0)
			return; // no sigue retrocediendo si llego a la primera

		escenas[sceneCount].SetActive(false);

		if(!volver)
			sceneCount++;
		else if(volver && sceneCount != 0)
			sceneCount--;

		if(sceneCount == escenas.Count)
		{
			print ("ultima escena");
			return;
		}

		escenas[sceneCount].SetActive(true);
		string trigger =  escenas[sceneCount].GetComponent<Escena>().transicionEntrada.ToString();
		TransitionManager.instance.EjecutarTransicion(trigger);
		volver = false;

	}


	void Update()
	{
		// Salir de la app si el user apreta el Back button en android
		if(Input.GetKeyDown(KeyCode.Escape))Application.Quit();

	}





}
