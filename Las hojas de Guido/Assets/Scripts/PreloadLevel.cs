using UnityEngine;
using System.Collections;

public class PreloadLevel : MonoBehaviour {

	public Animator menuAnim;

	AsyncOperation async;
	bool puedeCargar;

	void Start()
	{
		StartCoroutine(Preload());
	}

	public void CargarEscena(string trigger)
	{
		menuAnim.SetTrigger(trigger);
		puedeCargar = true;
		async.allowSceneActivation = true;
	}

	IEnumerator Preload()
	{
		async = Application.LoadLevelAsync(1);
		async.allowSceneActivation = false;

		yield return async;
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();

		if(puedeCargar)
		{
			if(async != null && async.isDone)
			{
				print ("peo");
			}
		}
	}

}
