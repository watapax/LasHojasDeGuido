using UnityEngine;
using System.Collections;

public class RecojerHojas : MonoBehaviour {

	public Transform[] hojas;
	public Transform destello;
	public AudioClip sonidoHoja;

	Animator animGuido;
	int hojaRecojida = 0;
	Vector3 posOriginal;
	AudioSource audioSource;

	void Awake()
	{
		audioSource = GetComponent<AudioSource>();
		posOriginal = transform.position;
		animGuido = GetComponent<Animator>();
		destello.position = hojas[0].position;

	}

	public void Caminar(int idHoja)
	{

		if(idHoja != hojaRecojida) return;
		animGuido.SetTrigger("caminar");

	}

	public void RecojeHoja()
	{
		hojaRecojida++;
		if(hojaRecojida == 3){
			animGuido.SetBool("recogeTodas", true);
			destello.gameObject.SetActive(false);
		}
		else
			destello.position = hojas[hojaRecojida].position;
		
		hojas[hojaRecojida - 1].gameObject.SetActive(false);
		audioSource.PlayOneShot(sonidoHoja);
	}


	void OnDisable()
	{
		transform.position = posOriginal;
		hojaRecojida = 0;
		destello.position = hojas[0].position;
		destello.gameObject.SetActive(true);

		for(int i = 0; i < hojas.Length; i++)
			hojas[i].gameObject.SetActive(true);
	}

	void OnEnable()
	{
		hojaRecojida = 0;
		animGuido.SetTrigger("reset");
	}

}
