using UnityEngine;
using System.Collections;

public class GotaLluvia : MonoBehaviour {

	public float velocidad;
	public float limite;

	SpriteRenderer[] sprites;
	bool cayendo;
	Animator anim;

	void Awake()
	{
		sprites = GetComponentsInChildren<SpriteRenderer>();
		anim = GetComponent<Animator>();
		RandomSort();
	}

	void FixedUpdate()
	{
		transform.Translate(Vector2.down * velocidad, Space.Self);
		if(transform.position.y <= limite)
		{
			if(!cayendo)
			{
				velocidad = 0;
				transform.eulerAngles = Vector3.zero;
				anim.SetTrigger("cae");
				cayendo = true;
			}
		}

	}

	void OnDisable()
	{
		cayendo = false;
		RandomSort();
	}

	void RandomSort()
	{
		int sort = Random.Range(0 , 100);
		if(sort > 50)
			sort = 10;
		else
			sort = -10;


		for(int i = 0; i < sprites.Length; i++)
		{
			sprites[i].sortingOrder = sort;
		}
	}
}
