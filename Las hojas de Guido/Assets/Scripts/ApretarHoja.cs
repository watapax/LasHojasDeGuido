using UnityEngine;
using System.Collections;

public class ApretarHoja : MonoBehaviour {

	public RecojerHojas recojerHojas;
	public int id;

	void OnMouseDown()
	{
		recojerHojas.Caminar(id);
	}

}
