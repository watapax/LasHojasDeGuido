using UnityEngine;
using System.Collections;

public class GuidoComiendo : MonoBehaviour {



	public static GameObject hoja;
	public Transform posBoca;
	public float minDistance;
	public AudioClip comiendo;

	bool estaComiendo;
	Animator anim;
	AudioSource audioSource;

	void Awake()
	{
		anim = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
	}


	void Update()
	{
		if(PuedeComer())
		{
			anim.SetTrigger("comer");
			audioSource.PlayOneShot(comiendo);
			hoja.SetActive(false);
			hoja = null;
		}
	}



	bool PuedeComer()
	{
		if(estaComiendo)
		{
			hoja = null;
			return false;
		}
		else if(hoja == null) return false;

		else if(Vector3.Distance(hoja.transform.position , posBoca.position) < minDistance)
			return true;
		else
			return false;
	}



	public void EstaComiendo(int _comiendo)
	{
		estaComiendo = _comiendo > 0 ? true: false;
		print ("esta comiendo: " + estaComiendo);
	}


}
