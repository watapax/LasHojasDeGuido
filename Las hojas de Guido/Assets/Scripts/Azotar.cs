using UnityEngine;
using System.Collections;

public class Azotar : MonoBehaviour {

	public float limite;
	public Animator otroAnim;
	public string triggerName;

	private Vector3 deviceAcceleration;
	private bool shaking;
	private bool isShaking;



	void Update()
	{
		deviceAcceleration = Input.acceleration;
		shaking = (deviceAcceleration.z < -limite || deviceAcceleration.z > limite) ? true : false;
		if(shaking && !isShaking)StartCoroutine(Shake ());

	}

	IEnumerator Shake()
	{

		otroAnim.SetTrigger(triggerName);
		while(shaking)
		{
			isShaking = true;
			yield return new WaitForSeconds(2);
		}

		isShaking = false;
	}

}
