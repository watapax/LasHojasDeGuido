using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class HojasControl : MonoBehaviour {

	public List<GameObject> hojas = new List<GameObject>();
	MoverConViento moverConViento;

	int index = 0;

	void Awake()
	{
		foreach(Transform t in transform)
		{
			hojas.Add(t.gameObject);
			t.GetComponent<MoverConViento>().enabled = false;


		}



		// ordenar la lista por la posicion Y, el primero es el que esta mas abajo
		hojas.Sort
			(
				delegate(GameObject go1, GameObject go2)
				{
				return go1.transform.position.y.CompareTo(go2.transform.position.y);
				}
			);




	}


	void FixedUpdate()
	{
		ChequearAltura();
	}


	// SI la posicion de la primera hoja supera cierta altura, se activa el componente en el siguiente GameObject de la lista
	void ChequearAltura()
	{
		if(index == hojas.Count) return;

		moverConViento = hojas[index].GetComponent<MoverConViento>();
		moverConViento.enabled = true;

		if(moverConViento.t.localPosition.y > 0.2f)	index++;

	}


	void OnEnable()
	{
		// resetear index y desactivar componentes en lista
		index = 0;
		for(int i = 0; i < hojas.Count; i++)
		{
			hojas[i].GetComponent<MoverConViento>().enabled = false;
		}
	}









}
