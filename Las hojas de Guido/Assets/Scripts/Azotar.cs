using UnityEngine;
using System.Collections;

public class Azotar : MonoBehaviour {

	public float limite;
	public string triggerName;
	public EfectoLluvia efectoLluvia;
	public GameObject tapandose;
	public GameObject esperando;
	public SonidoLluvia sonidoLluvia;
	public Animator animArbol;

	private Vector3 deviceAcceleration;
	private bool shaking;
	private bool isShaking;
	private bool estaLloviendo;
	private Animator animEsperando;


	void Awake()
	{
		animEsperando = esperando.GetComponent<Animator>();
		tapandose.SetActive(false);
	}




	void Update()
	{
		deviceAcceleration = Input.acceleration;
		shaking = (deviceAcceleration.z < -limite || deviceAcceleration.z > limite) ? true : false;
		if(shaking && !isShaking)StartCoroutine(Shake ());




	}





	IEnumerator Shake()
	{

		if(esperando.activeInHierarchy)
		{
			animEsperando.SetTrigger(triggerName);
			Invoke("ActivarLluvia" , 1.5f);
		}
		else if(tapandose.activeInHierarchy)
		{
			Invoke("DesactivarLluvia" , 1);
		}
			


		//StartCoroutine(ToggleLluvia());
		while(shaking)
		{
			isShaking = true;
			yield return new WaitForSeconds(2);
		}

		isShaking = false;
	}

	void ActivarLluvia()
	{
		esperando.SetActive(false);
		tapandose.SetActive(true);
		sonidoLluvia.Loopear();
		efectoLluvia.estaLloviendo = true;
		estaLloviendo = true;
	}

	void DesactivarLluvia()
	{
		esperando.SetActive(true);
		tapandose.SetActive(false);
		sonidoLluvia.FadingOut();
		efectoLluvia.estaLloviendo = false;
		estaLloviendo = false;
		animArbol.SetTrigger("paroLluvia");
	}



//	IEnumerator ToggleLluvia()
//	{
//		yield return new WaitForSeconds(2);
//		efectoLluvia.estaLloviendo = !efectoLluvia.estaLloviendo;
//		estaLloviendo = !estaLloviendo;
//
//		if(estaLloviendo)
//			sonidoLluvia.Loopear();
//		else
//			sonidoLluvia.FadingOut();
//
//
//		yield return new WaitForSeconds(1);
//		if(!estaLloviendo)animArbol.SetTrigger("paroLluvia");  
//		esperando.SetActive(!estaLloviendo);
//		tapandose.SetActive(estaLloviendo);
//
//	}

	void OnDisable()
	{
		esperando.SetActive(true);
		tapandose.SetActive(false);
		shaking = false;
		isShaking = false;
		StopAllCoroutines();
	}




}
