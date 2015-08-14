using UnityEngine;
using System.Collections;

public class SonidoLluvia : MonoBehaviour {

	public AudioClip audio1, audio2;
	public float speedVolumen;
	AudioSource audioSource;


	void Awake()
	{
		audioSource = GetComponent<AudioSource>();
	}




	void Update()
	{
		if(Input.GetKeyDown(KeyCode.A))FadingOut();
	}

	public void Loopear()
	{
		StartCoroutine(LoopearAudio(audio1 , audio2));
	}

	public void FadingOut()
	{
		StartCoroutine(FadeOut());
	}



	IEnumerator LoopearAudio(AudioClip clip1 , AudioClip clip2)
	{
		audioSource.clip = clip1;
		audioSource.Play();
		audioSource.loop = false;

		while(audioSource.isPlaying)
		{
			yield return null;
		}

		audioSource.clip = clip2;
		audioSource.Play();
		audioSource.loop = true;
	}



	IEnumerator FadeOut()
	{
		StopCoroutine("LoopearAudio");
		while(audioSource.volume > 0.01)
		{
			audioSource.volume -= speedVolumen;
			yield return null;
		}
		audioSource.clip = null;
		audioSource.volume = 1;

	}



}
