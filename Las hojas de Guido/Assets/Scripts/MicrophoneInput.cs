using UnityEngine;
using System.Collections;

public class MicrophoneInput : MonoBehaviour {

	public static MicrophoneInput instance;

	public float sensibilidad = 100;
	public float ruido = 0;

	AudioSource audioSource;

	void Awake()
	{
		// singleton
		if(instance == null) instance = this; else if(instance != this) Destroy(gameObject);

		audioSource = GetComponent<AudioSource>();
	}

	void OnEnable()
	{
		audioSource.clip = Microphone.Start(null, true, 10, 44100);
		audioSource.loop = true;
		audioSource.mute = true;
		while(!(Microphone.GetPosition(null) > 0))
			audioSource.Play();
	}

	void Update()
	{
		ruido = ObtenerVolumenPromedio() * sensibilidad;
	}


	float ObtenerVolumenPromedio()
	{
		float[] datos = new float[256];
		float a = 0;
		audioSource.GetOutputData(datos , 0);

		foreach(float s in datos)
		{
			a += Mathf.Abs(s);
		}

		return a / datos.Length;
	}

}
