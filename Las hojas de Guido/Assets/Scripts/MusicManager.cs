using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	AudioSource audioSource;
	public AudioClip intro, arbolSinHojas, esperando, guidoTriste, incendio, devastacion, final;


	void Awake()
	{
		audioSource = GetComponent<AudioSource>();
		audioSource.playOnAwake = false;
	}

	void Start()
	{
		audioSource.clip = intro;
		audioSource.PlayDelayed(1);
	}

}
