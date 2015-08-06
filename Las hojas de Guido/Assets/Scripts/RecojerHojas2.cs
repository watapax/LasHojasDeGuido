using UnityEngine;
using System.Collections;

public class RecojerHojas2 : MonoBehaviour {

	public Transform destello;
	public Transform[] hojas;
	public AudioSource audioSource;
	public AudioClip sonidoHoja;

	private Vector2 posDestello, posHoja0, posHoja1, posHoja2, alaChucha;
	private int count = 0;

	void Awake()
	{
		audioSource = GetComponent<AudioSource>();
		posDestello = destello.position;
		posHoja0 = hojas[0].position;
		posHoja1 = hojas[1].position;
		posHoja2 = hojas[2].position;
		alaChucha = Vector2.one * 1000;
		destello.position = hojas[0].position;

	}

	public void MoverDestello(int idHoja)
	{
		if(idHoja != count) return;
		else
		{
			audioSource.PlayOneShot(sonidoHoja);
			hojas[idHoja].position = alaChucha;
			count++;
			if(count == 3)
				destello.position = alaChucha;
			else
				destello.position = hojas[count].position;
		}
	}


	void OnDisable()
	{
		// Resetea las posiciones
		destello.position = posDestello;
		hojas[0].position = posHoja0;
		hojas[1].position = posHoja1;
		hojas[2].position = posHoja2;
		destello.position = hojas[0].position;
		count = 0;
	}


}
