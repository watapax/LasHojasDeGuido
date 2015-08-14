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
			animEsperando.SetTrigger(triggerName);


		StartCoroutine(ToggleLluvia());
		while(shaking)
		{
			isShaking = true;
			yield return new WaitForSeconds(2);
		}

		isShaking = false;
	}




	IEnumerator ToggleLluvia()
	{
		yield return new WaitForSeconds(2);
		efectoLluvia.estaLloviendo = !efectoLluvia.estaLloviendo;
		estaLloviendo = !estaLloviendo;

		if(estaLloviendo)
			sonidoLluvia.Loopear();
		else
			sonidoLluvia.FadingOut();


		yield return new WaitForSeconds(1);
		if(!estaLloviendo)animArbol.SetTrigger("paroLluvia");  
		esperando.SetActive(!estaLloviendo);
		tapandose.SetActive(estaLloviendo);

	}




}
