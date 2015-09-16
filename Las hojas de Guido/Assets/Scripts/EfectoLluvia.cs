using UnityEngine;
using System.Collections;

public class EfectoLluvia : MonoBehaviour {

	public GameObject lluviaPrefab;
	public Transform suelo;
	[Range(0.2f , 0.4f)] public float velocidadLluvia;
	public float anguloLluvia;
	[Range(0.005f ,0.1f)] public float frecuenciaLluvia;
	public int totalGotas;
	public float min_X, max_X;
	public bool estaLloviendo;
	public SpriteRenderer fondo;

	GameObject[] lluvia;
	public static bool lloviendo;
	Color transparente , colorActual;




	void Awake()
	{
		lluvia = new GameObject[totalGotas];
		transparente = new Color(1 ,1 ,1 ,0);
		colorActual = fondo.color;

		for(int i = 0; i < totalGotas; i++)
		{
			lluvia[i]	= (GameObject) Instantiate(lluviaPrefab);


			lluvia[i].SetActive(false);

		}
	}






	void Update()
	{
		if(estaLloviendo && !lloviendo)
		{
			StartCoroutine(ActivarLluvia());
		}

		if(!estaLloviendo)
			fondo.color = Color.Lerp(fondo.color, transparente , 2 * Time.deltaTime);
		else
			fondo.color = Color.Lerp(fondo.color, colorActual , 2 * Time.deltaTime);
		
	}




	void ActivarGotaLluvia()
	{

		Vector2 randomPos = new Vector2( Random.Range(min_X , max_X) , transform.position.y );
		float randomSpeed = Random.Range( velocidadLluvia - 0.1f , velocidadLluvia + 0.1f);


		for(int i = 0; i < lluvia.Length; i++)
		{
			if(!lluvia[i].activeInHierarchy)
			{
				lluvia[i].transform.position = randomPos;
				lluvia[i].GetComponent<GotaLluvia>().velocidad = randomSpeed;
				lluvia[i].GetComponent<GotaLluvia>().limite = suelo.position.y;
				lluvia[i].transform.eulerAngles = new Vector3(0 , 0 , anguloLluvia);
				lluvia[i].SetActive(true);
				break;
			}
		}
	}


	IEnumerator ActivarLluvia()
	{

		lloviendo = true;
		while(estaLloviendo)
		{
			ActivarGotaLluvia();
			yield return new WaitForSeconds(frecuenciaLluvia);
		}

		lloviendo = false;
	}

	void OnDisable()
	{
		estaLloviendo = false;
		lloviendo = false;
		StopAllCoroutines();
	}





}
