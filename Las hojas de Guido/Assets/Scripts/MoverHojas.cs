using UnityEngine;
using System.Collections;

public class MoverHojas : MonoBehaviour {

	Vector2 offset;
	[HideInInspector] public Vector2 posOriginal;

	void OnMouseDown()
	{

		GuidoComiendo.hoja = null;
		offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
	}

	void OnMouseDrag()
	{
		GetComponent<SpriteRenderer>().sortingOrder = 10;
		Vector2 posicionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = posicionMouse + offset;
	}

	void OnMouseUp()
	{
		GetComponent<SpriteRenderer>().sortingOrder = 3;
		GuidoComiendo.hoja = gameObject;
	}



}
