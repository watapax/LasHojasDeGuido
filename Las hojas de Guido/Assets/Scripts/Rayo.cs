using UnityEngine;
using System.Collections;

public class Rayo : MonoBehaviour {

	public GameObject guidoTapandose;
	Animator anim;
	AudioSource audioSource;
	void Awake()
	{
		anim = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
	}


	public void ActivarRayo()
	{
		if(EfectoLluvia.lloviendo)
		{
			anim.SetTrigger("rayo");
			guidoTapandose.SetActive(false);
			audioSource.Play();
		}
	}

	public void DesactivarRayo()
	{
		guidoTapandose.SetActive(true);
	}

}
