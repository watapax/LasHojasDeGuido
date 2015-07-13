/*
 * Clase solo para funciones de animaciones
*/

using UnityEngine;
using System.Collections;

public class AnimationFunction : MonoBehaviour {


	AudioSource audioS;
	Animator anim;

	void Awake()
	{
		anim = GetComponent<Animator>();
	}


	// REPRODUCE UN SONDIDO
	public void PlaySound(AudioClip audioclip)
	{
		// chequea si exist el componente AudioSource
		if(gameObject.GetComponent<AudioSource>() == null)
			audioS =  gameObject.AddComponent<AudioSource>();

		audioS.PlayOneShot(audioclip);
	}


	// REPRODUCE UNA ANIMACION CON TRIGGER
	public void PlayAnimation(string triggerName)
	{
		anim.SetTrigger(triggerName);
	}


}
