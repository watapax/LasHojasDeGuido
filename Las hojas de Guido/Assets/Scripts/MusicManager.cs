using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	private AudioSource audioSource;
	private AudioClip musicPlaying;

	public float velocidadTransicion;
	public AudioClip intro, arbolSinHojas, esperando, guidoTriste, incendio, devastacion, final;
	public enum ListaCanciones{ intro, arbolSinHojas, esperando, guidoTriste, incendio, devastacion, final};
	public static MusicManager instance;


	ListaCanciones reproduciendo;


	void Awake()
	{
		musicPlaying = intro;
		instance = this;
		audioSource = GetComponent<AudioSource>();
		audioSource.clip = musicPlaying;
		audioSource.playOnAwake = false;
		reproduciendo = ListaCanciones.intro;
	}

	void Start()
	{
		audioSource.clip = musicPlaying;
		audioSource.PlayDelayed(1);
	}

	public void Transicion(ListaCanciones cancion)
	{
		if(cancion == reproduciendo)
			return;
		else
			StartCoroutine(FadeOut(cancion));
	}

	#region Chequear Cancion
	void ChequearCancion(ListaCanciones cancion)
	{
		switch(cancion)
		{
		case ListaCanciones.intro:
			musicPlaying = intro;
			break;

		case ListaCanciones.arbolSinHojas:
			musicPlaying = arbolSinHojas;
			break;

		case ListaCanciones.esperando:
			musicPlaying = esperando;
			break;

		case ListaCanciones.guidoTriste:
			musicPlaying = guidoTriste;
			break;

		case ListaCanciones.incendio:
			musicPlaying = incendio;
			break;

		case ListaCanciones.devastacion:
			musicPlaying = devastacion;
			break;

		case ListaCanciones.final:
			musicPlaying = final;
			break;
		}
	}
	#endregion




	#region FadeIn FadeOut
	IEnumerator FadeOut(ListaCanciones cancion)
	{
		while(audioSource.volume>0.01f)
		{
			audioSource.volume -= velocidadTransicion;
			yield return new WaitForSeconds(0.2f);
		}

		ChequearCancion(cancion);
		reproduciendo = cancion;
		audioSource.clip = musicPlaying;
		audioSource.volume = 1;
		audioSource.Play();

	}
	#endregion





}
