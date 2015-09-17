using UnityEngine;
using System.Collections;

public class FuncionEscenas : MonoBehaviour {

	public void CambiarEscena(int indice)
	{
		SceneManager.instance.CargarEscena(indice);

	}



}
