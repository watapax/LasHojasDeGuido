using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObtenerIdioma : MonoBehaviour {


	public int indiceTexto;
	Text texto;

	void Start()
	{
		texto = GetComponent<Text>();
	}

	void Update()
	{
		texto.text = SeleccionarIdioma.instance.idiomaFinal[indiceTexto];
	}

}
