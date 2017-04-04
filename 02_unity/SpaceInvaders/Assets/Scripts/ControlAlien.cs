using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControlAlien : MonoBehaviour
{
	// Conexión al marcador, para poder actualizarlo
	private GameObject marcador;

	// Por defecto, 100 puntos por cada alien
	private int puntos = 100;

	private GameObject efectoExplosion;

	public Rigidbody2D disparo1;

	private float fuerza = 0.5f;

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
	 	
		if (Input.GetKeyDown (KeyCode.Space)) {
			disparar ();
		}
			
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		// Detectar la colisión entre el alien y otros elementos
	
		// Necesitamos saber contra qué hemos chocado
		if (coll.gameObject.tag == "disparo") {

			// Sonido de explosión
			GetComponent<AudioSource> ().Play ();
			switch (this.tag) {
			case "alien1":
				puntos = puntos * 1;
					break;
			case "alien2":
				puntos = puntos * 2;
					break;
			case "alien3":
				puntos = puntos * 3;
				break;
			}
			// Sumar la puntuación al marcador
			marcador.GetComponent<ControlMarcador> ().puntos += puntos;

			// El disparo desaparece (cuidado, si tiene eventos no se ejecutan)
			Destroy (coll.gameObject);

			// El alien desaparece (no hace falta retraso para la explosión, está en otro objeto)
			efectoExplosion.GetComponent<AudioSource> ().Play ();
			Destroy (gameObject);

		} else if (coll.gameObject.tag == "nave") {
			SceneManager.LoadScene ("Nivel1");
		}
		if (coll.gameObject.tag == "disparoalien") {
			//coll.gameObject.GetComponents<Rigidbody2D>().
		}
	}

	void disparar ()
	{
		// Hacemos copias del prefab del disparo y las lanzamos
		Rigidbody2D d = (Rigidbody2D)Instantiate (disparo1, transform.position , transform.rotation );

		// Desactivar la gravedad para este objeto, si no, ¡se cae!
		d.gravityScale = 1;

		// Posición de partida, en la punta de la nave
		d.transform.Translate (Vector2.down * 0.1f);
		// Posición de partida, en la punta de la nave
		d.transform.Translate (Vector3.forward*10f);

		// Lanzarlo
		d.AddForce (Vector2.down * 1f, ForceMode2D.Impulse);	
	}
}
