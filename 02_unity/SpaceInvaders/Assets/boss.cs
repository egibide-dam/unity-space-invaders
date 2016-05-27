using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;



public class boss : MonoBehaviour {

    public GeneradorAliens2[] gg = new GeneradorAliens2[10];
    public float nextWave = 1;
    public float thisWave = 1;
    public int life ;
    private int wave = 0;
    private AudioSource[] rll = new AudioSource[2];
    private enum direccion { IZQ, DER };

    // Rumbo que lleva el pack de aliens
    private direccion rumbo = direccion.DER;

    // Posición vertical de la horda (lo iremos restando de la .y de cada alien)
    private float altura = 0.5f;

    // Velocidad a la que se desplazan los aliens (medido en u/s)
    private float velocidad = 0.8f;


    // Conexión al marcador, para poder actualizarlo
    private GameObject marcador;
    private GameObject vida;
    private Rigidbody2D rb;
    // Por defecto, 100 puntos por cada alien
    private int puntos = 50;

    // Objeto para reproducir la explosión de un alien
    private GameObject efectoExplosion;

    // Use this for initialization
    void Start () {
        if (life == null)
        {
            life = 150;
        }

        AudioSource[] rll = GetComponents<AudioSource>();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        // Localizamos el objeto que contiene el marcador
        marcador = GameObject.Find("Marcador");
        vida = GameObject.Find("vida");
    // Objeto para reproducir la explosión de un alien
    efectoExplosion = GameObject.Find("EfectoExplosion");
        vida.GetComponent<ControlMarcador>().puntos += life;
    }
	
    

// Update is called once per frame
void Update () {


        if ( Time.time > nextWave)
        {
            gA();
            nextWave = Time.time + thisWave;
            

        }

        // Variable para saber si al menos un alien ha llegado al borde
        bool limiteAlcanzado = false;

        // Calculamos la anchura visible de la cámara en pantalla
        float distanciaHorizontal = Camera.main.orthographicSize * Screen.width / Screen.height;

        // Calculamos el límite izquierdo y el derecho de la pantalla
        float limiteIzq = -1.0f * distanciaHorizontal;
        float limiteDer = 1.0f * distanciaHorizontal;

        // ¿Vamos a izquierda o derecha?
        if (rumbo == direccion.DER)
        {

            // Nos movemos a la derecha
            transform.Translate(Vector2.right * velocidad * Time.deltaTime);

            // Comprobamos si hemos tocado el borde
            if (transform.position.x > limiteDer - 3)
            {
                limiteAlcanzado = true;
            }
        }
        else {

            // Nos movemos a la derecha
            transform.Translate(Vector2.left * velocidad * Time.deltaTime);

            // Comprobamos si hemos tocado el borde
            if (transform.position.x < limiteIzq + 3)
            {
                limiteAlcanzado = true;
            }
        }


        // Si al menos un alien ha tocado el borde, todo el pack cambia de rumbo
        if (limiteAlcanzado == true)
        {

            transform.Translate(Vector2.down * altura);
            if (rumbo == direccion.DER)
            {
                rumbo = direccion.IZQ;
            }else {
                rumbo = direccion.DER;
            }
        }

        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // Detectar la colisión entre el alien y otros elementos

        // Necesitamos saber contra qué hemos chocado
        if (coll.gameObject.tag == "disparo")
        {

            // Sonido de impacto



            // El disparo desaparece (cuidado, si tiene eventos no se ejecutan)
            Destroy(coll.gameObject);

           

            if (life == 0)
            {
                // Sumar la puntuación al marcador
                Destroy(gameObject);
            }

            // Sumar la puntuación al marcador
            marcador.GetComponent<ControlMarcador>().puntos += puntos;
            vida.GetComponent<ControlMarcador>().puntos = life;
            life  = life - 1;

            // Sumar la puntuación al marcador
            //marcador.GetComponent<ControlMarcador>().puntos += puntos;
        }
        else if (coll.gameObject.tag == "nave")
        {
            SceneManager.LoadScene("menu");
        }
    }



    void gA()
    {
        
        gg[wave].activar();
        wave++;
    }
    }

