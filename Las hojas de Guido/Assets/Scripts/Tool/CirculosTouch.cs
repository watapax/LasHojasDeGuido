using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CirculosTouch : MonoBehaviour {

	List <GameObject> circleTouch = new List<GameObject>();

	void Awake()
	{
		foreach(Transform t in transform){ 	circleTouch.Add(t.gameObject); }
		for(int i = 0; i < circleTouch.Count; i++){ circleTouch[i].SetActive(false); }
	}

	void Update()
	{
		if(Input.GetMouseButtonDown(0))MostrarCirculo();

//		if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
//		{
//			MostrarCirculo();
//		}
	}

	// muestra el circulo cuando el user hace un Touch en la posicion del dedo
	void MostrarCirculo()
	{

		for(int i = 0; i < circleTouch.Count; i++)
		{
			if(!circleTouch[i].activeInHierarchy)
			{
				circleTouch[i].SetActive(true);
				Vector2 posicion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				circleTouch[i].transform.position = posicion;
				break;
			}
		}
	}



}
