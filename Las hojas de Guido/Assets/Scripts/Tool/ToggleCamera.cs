using UnityEngine;
using System.Collections;

public class ToggleCamera : MonoBehaviour {

	public Camera mainCamara;


	void Update()
	{
		if(Input.GetKeyDown(KeyCode.O))
			mainCamara.orthographic = true;

		if(Input.GetKeyDown(KeyCode.P))
			mainCamara.orthographic = false;
	}

}
