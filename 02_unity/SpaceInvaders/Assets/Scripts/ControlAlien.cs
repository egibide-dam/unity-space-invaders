using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControlAlien : MonoBehaviour
{
	


	// Conexión al marcador, para poder actualizarlo
	private GameObject marcador;

	// Por defecto, 100 puntos por cada alien

	private int puntos1 = 100;
	private int puntos2 = 200;
	private int puntos3 = 300;
	// Objeto para reproducir la explosión de un alien
	private GameObject efectoExplosion;

	// Use this for initialization
	void Start ()
	{
		// Localizamos el objeto que contiene el marcador
		marcador = GameObject.Find ("Marcador");

		// Objeto para reproducir la explosión de un alien
		efectoExplosion = GameObject.Find ("EfectoExplosion");
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		// Detectar la colisión entre el alien y otros elementos

		// Necesitamos saber contra qué hemos chocado
		if (coll.gameObject.tag == "disparo") {

			if (gameObject.tag == "alien1") {
				
				// Sonido de explosión
				GetComponent<AudioSource> ().Play ();

				// Sumar la puntuación al marcador
				marcador.GetComponent<ControlMarcador> ().puntos += puntos1;

				// El disparo desaparece (cuidado, si tiene eventos no se ejecutan)
				Destroy (coll.gameObject);

				// El alien desaparece (no hace falta retraso para la explosión, está en otro objeto)
				efectoExplosion.GetComponent<AudioSource> ().Play ();
				Destroy (gameObject);	
			} else if (gameObject.tag == "alien2") {
				// Sonido de explosión
				GetComponent<AudioSource> ().Play ();

				// Sumar la puntuación al marcador
				marcador.GetComponent<ControlMarcador> ().puntos += puntos2;

				// El disparo desaparece (cuidado, si tiene eventos no se ejecutan)
				Destroy (coll.gameObject);

				// El alien desaparece (no hace falta retraso para la explosión, está en otro objeto)
				efectoExplosion.GetComponent<AudioSource> ().Play ();
				Destroy (gameObject);


			}else if (gameObject.tag == "alien3") {
				// Sonido de explosión
				GetComponent<AudioSource> ().Play ();

				// Sumar la puntuación al marcador
				marcador.GetComponent<ControlMarcador> ().puntos += puntos3;

				// El disparo desaparece (cuidado, si tiene eventos no se ejecutan)
				Destroy (coll.gameObject);

				// El alien desaparece (no hace falta retraso para la explosión, está en otro objeto)
				efectoExplosion.GetComponent<AudioSource> ().Play ();
				Destroy (gameObject);


			}

			} else if (coll.gameObject.tag == "nave") {
				SceneManager.LoadScene ("Nivel1");
			}
			



	}
	}
