using UnityEngine;
using System.Collections;

public class Escena : MonoBehaviour {

	public enum Transiciones{ Corte, FadeInBlanco, FadeOutBlanco, FadeInNegro, FadeOutNegro}

	public Transiciones transicionEntrada, transicionSalida, transicionVuelta;
}
