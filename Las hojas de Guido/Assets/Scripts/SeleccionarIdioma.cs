using UnityEngine;
using System.Collections;

public class SeleccionarIdioma : MonoBehaviour {

	public static SeleccionarIdioma instance;

	public TextAsset español, ingles, japones;
	string[] txtEspañol, txtIngles, txtJapones;
	[HideInInspector] public string[] idiomaFinal;

	void Awake()
	{
		if(instance == null)
			instance = this;
		else if(instance != this)
			Destroy(gameObject);


		CargarTextos();
		ElejirIdioma(0); // idioma por defecto es español
	}



	void CargarTextos()
	{
		txtEspañol = español.text.Split('\n');
		txtIngles = ingles.text.Split('\n');
		txtJapones = japones.text.Split('\n');
	}

	public void ElejirIdioma(int idioma)
	{
		switch(idioma)
		{
		case 0:
			idiomaFinal = txtEspañol;
			break;
		case 1:
			idiomaFinal = txtIngles;
			break;
		case 2:
			idiomaFinal = txtJapones;
			break;
		}
	}




}
