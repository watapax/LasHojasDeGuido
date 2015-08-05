using UnityEngine;
using System.Collections;

public class ApretarHoja2 : MonoBehaviour {

	public int id;

	private RecojerHojas2 recojerHojas;

	void Awake()
	{
		recojerHojas = GetComponentInParent<RecojerHojas2>();
	}

	void OnMouseDown()
	{
		recojerHojas.MoverDestello(id);
	}
}
