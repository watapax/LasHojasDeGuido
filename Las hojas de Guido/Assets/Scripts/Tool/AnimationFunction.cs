/* ---------------------------------------- 
 * Clase solo para funciones de animaciones 
 * ---------------------------------------- */

using UnityEngine;
using System.Collections;

public class AnimationFunction : MonoBehaviour {

	public Animator otroAnim;

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


	// DESACTIVAR GAMEOBJECT
	public void DesactivarObject()
	{
		gameObject.SetActive(false);
	}


	// DESACTIVAR ANIAMTOR
	public void DesactivarAnimator()
	{
		anim.enabled = false;

	}


	// REPRODUCE UNA ANIMACION DE OTRO ANIMATOR
	public void PlayOtherAnimation(string triggerName)
	{
		otroAnim.SetTrigger(triggerName);
	}


	void OnDisable()
	{
		anim.enabled = true;
	}


}
