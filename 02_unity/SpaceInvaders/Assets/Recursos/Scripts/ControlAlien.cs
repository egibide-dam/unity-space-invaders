using UnityEngine;
using System.Collections;

public class ControlAlien : MonoBehaviour
{
	// Conexión al marcador, para poder actualizarlo
	public GameObject marcador;

	// Por defecto, 100 puntos por cada alien
	public int puntos = 100;

	// Use this for initialization
	void Start ()
	{
		// Localizamos el objeto que contiene el marcador
		marcador = GameObject.Find ("Marcador");
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnCollisionEnter (Collision coll)
	{
		// Detectar la colisión entre el alien y otros elementos

		// Necesitamos saber contra qué hemos chocado
		if (coll.gameObject.tag == "player") {

			// Sonido de explosión
			GetComponent<AudioSource> ().Play ();

			// El alien desaparece (hay que añadir un retraso, si no, no se oye la explosión)

			// Lo ocultamos...
			GetComponent<Renderer> ().enabled = false;
			GetComponent<Collider> ().enabled = false;

			// ... y lo destruímos al cabo de 5 segundos, para dar tiempo al efecto de sonido
			Destroy (gameObject, 2f);
		}
	}
}
