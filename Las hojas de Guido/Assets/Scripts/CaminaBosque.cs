using UnityEngine;
using System.Collections;

public class CaminaBosque : MonoBehaviour {



	public Transform guidoTransform;
	public Animator guidoAnim;
	public float velocidadGuido;
	public Puppet2D_GlobalControl puppetControl;
	public float velocidadCamara;
	[Range(0,2)] public float inclinacionMinima;


	Transform camara;
	bool mirandoDerecha = true;
	Vector3 offset;
	Vector3 originalCamPos;
	Vector3 originalGuidoPos;

	void Awake()
	{
		// obtengo la camara principal
		camara = Camera.main.transform;
		offset = camara.position - guidoTransform.position;
		originalCamPos = camara.position;
		originalGuidoPos = guidoTransform.position;
	}



	void Update()
	{
		print (Input.acceleration.x);
		// asigna la velodidad absoluta Y del acelerometro al float del animator
		guidoAnim.SetFloat("velocidad" , Mathf.Abs(Input.acceleration.x));


		// si estoy mirando a la derecha y muevo el cel a la izquierda
		if(mirandoDerecha && Input.acceleration.x < -inclinacionMinima)
			Flip();
		// si estoy no estoy mirando a la derecha y muevo el cel a la derecha
		else if(!mirandoDerecha && Input.acceleration.x > inclinacionMinima)
			Flip();

		// si la inclinacion del celular es mayor a la inclinacion minima, mueve el bosque en la direccion contraria
		if(Mathf.Abs(Input.acceleration.x) > inclinacionMinima)
			guidoTransform.Translate(Vector3.right * velocidadGuido * Time.deltaTime , Space.Self);

	}

	void FixedUpdate()
	{
		Vector3 camPos = guidoTransform.position + offset;
		camara.position = Vector3.Lerp(camara.position , camPos , velocidadCamara);
		LimitarMovCamara();
	}


	// invertir posicion de Guido dependiendo de la inclinacion del celular
	void Flip()
	{
		mirandoDerecha = !mirandoDerecha;
		puppetControl.flip = !puppetControl.flip;
		velocidadGuido *= -1;
	}

	// limita el movimiento de la camara para que avance hasta cierto punto solamente
	void LimitarMovCamara()
	{
		Vector3 camPos = camara.position;
		camPos.x = Mathf.Clamp(camPos.x , -2.5f , 20);
		camara.position = camPos;
	}

	void OnDisable()
	{
		camara.position = originalCamPos;
		guidoTransform.position = originalGuidoPos;
	}

}
