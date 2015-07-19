using UnityEngine;
using System.Collections;

public class MoverConViento : MonoBehaviour {

	float randomSpeed;

	void Awake()
	{
		randomSpeed = Random.Range(0.01f , 0.02f);
	}

	void FixedUpdate()
	{
		float fuerza = MicrophoneInput.instance.ruido * randomSpeed;
		if(fuerza > 0.01)
			transform.localPosition = new Vector3(0 , transform.localPosition.y + fuerza , 0);
		print (fuerza);

	}

}
