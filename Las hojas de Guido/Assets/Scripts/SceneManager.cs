using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

	public static SceneManager instance;

	void Awake()
	{
		DontDestroyOnLoad(this);

		if(instance == null)
		{
			instance = this;
		}
		else if(instance != this)
		{
			Destroy(gameObject);
		}
	}

	public void CargarEscena(int indice)
	{
		Application.LoadLevel(indice);
	}

}
