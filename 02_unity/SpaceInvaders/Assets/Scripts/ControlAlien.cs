using UnityEngine;
using System.Collections;

public class ControlAlien : MonoBehaviour
{
    // Conexión al marcador, para poder actualizarlo
    public GameObject marcador;

    // Por defecto, 100 puntos por cada alien
    public int puntos = 100;

    // Use this for initialization
    void Start()
    {
        // Localizamos el objeto que contiene el marcador
        marcador = GameObject.Find("Marcador");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // Detectar la colisión entre el alien y otros elementos

        // Necesitamos saber contra qué hemos chocado
        if (coll.gameObject.tag == "disparo")
        {

            // Sumar la puntuación al marcador
            marcador.GetComponent<ControlMarcador>().puntos += puntos;

            // El disparo desaparece (cuidado, si tiene eventos no se ejecutan)
            Destroy(coll.gameObject);

            // El alien desaparece
            Destroy(gameObject);
        }
    }
}
