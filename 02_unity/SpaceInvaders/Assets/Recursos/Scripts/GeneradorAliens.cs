using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GeneradorAliens : MonoBehaviour
{

    // Publicamos la variable para conectarla desde el editor
    public Rigidbody ship;
    public Rigidbody2D alien;

    //Tamaño de l rejilla
    public int x;
    public int y;


    // Referencia para guardar una matriz de objetos
    private Rigidbody2D[,] aliens;
    // Enumeración para expresar el sentido del movimiento
    private enum direccion { IZQ, DER };

    // Rumbo que lleva el pack de aliens
    private direccion rumbo = direccion.DER;

    // Posición vertical de la horda (lo iremos restando de la .y de cada alien)
    private float altura = 0.5f;

    // Límites de la pantalla
    private float limiteIzq = - 8;
    private float limiteDer = 8;

    // Velocidad a la que se desplazan los aliens (medido en u/s)
    private float velocidad = 5f;


    // Use this for initialization
    public void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Contador para saber si hemos terminado
        int numAliens = 0;

        // Variable para saber si al menos un alien ha llegado al borde
        bool limiteAlcanzado = false;

        // Recorremos la horda alienígena
        for (int i = 0; i < y; i++)
        {
            for (int j = 0; j < x; j++)
            {

                // Comprobamos que haya objeto, para cuando nos empiecen a disparar
                if (aliens[i, j] != null)
                {

                    // Un alien más
                    numAliens += 1;

                    // ¿Vamos a izquierda o derecha?
                    if (rumbo == direccion.DER)
                    {

                        // Nos movemos a la derecha (todos los aliens que queden)
                        aliens[i, j].transform.Translate(Vector2.right * velocidad * Time.deltaTime);

                        // Comprobamos si hemos tocado el borde
                        if (aliens[i, j].transform.position.x > limiteDer)
                        {
                            limiteAlcanzado = true;
                        }
                    }
                    else {

                        // Nos movemos a la derecha (todos los aliens que queden)
                        aliens[i, j].transform.Translate(Vector2.left * velocidad * Time.deltaTime);

                        // Comprobamos si hemos tocado el borde
                        if (aliens[i, j].transform.position.x < limiteIzq)
                        {
                            limiteAlcanzado = true;
                        }
                    }
                }
            }
        }

        // Si no quedan aliens, hemos terminado
        if (numAliens == 0)
        {
            SceneManager.LoadScene("bossRetro");
        }

        // Si al menos un alien ha tocado el borde, todo el pack cambia de rumbo
        if (limiteAlcanzado == true)
        {
            for (int i = 0; i < y; i++)
            {
                for (int j = 0; j < x; j++)
                {

                    // Comprobamos que haya objeto, para cuando nos empiecen a disparar
                    if (aliens[i, j] != null)
                    {
                        aliens[i, j].transform.Translate(Vector2.down * altura);
                    }
                }
            }


            if (rumbo == direccion.DER)
            {
                rumbo = direccion.IZQ;
            }
            else {
                rumbo = direccion.DER;
            }
        }
    }


    public void generarAliens(int filas, int columnas, float espacioH, float espacioV, float escala = 1.0f)
    {


        if (ship != null)
        {
            // Generamos los objetos
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    /* Creamos una rejilla de aliens a partir del punto de origen
		 * 
		 * Ejemplo (2,5):
		 *   A A A A A
		 *   A A O A A
		 */

                    // Calculamos el punto de origen de la rejilla
                    Vector3 origen = new Vector3(transform.position.x - (columnas / 2.0f) * espacioH + (espacioH / 2), transform.position.y);

                    // Posición de cada alien
                    Vector3 posicion = new Vector3(origen.x + (espacioH * j), origen.y + (espacioV * i));

                    // Instanciamos el objeto partiendo del prefab
                    Rigidbody player = (Rigidbody)Instantiate(ship, posicion, transform.rotation);

                    // Escala opcional, por defecto 1.0f (sin escala)
                    // Nota: El prefab original ya está escalado a 0.2f
                    //alien.transform.localScale = new Vector2 (0.2f * escala, 0.2f * escala);
                }

            }

        }
        else {
 /* Creamos una rejilla de aliens a partir del punto de origen
          * 
          * Ejemplo (2,5):
          *   A A A A A
          *   A A O A A
          */

                    // Calculamos el punto de origen de la rejilla
                    Vector2 origen = new Vector2(transform.position.x - (columnas / 2.0f) * espacioH + (espacioH / 2), transform.position.y);

                    // Instanciamos el array de referencias
                    aliens = new Rigidbody2D[filas, columnas];

                    // Fabricamos un alien en cada posición del array
                    for (int i = 0; i < y; i++)
                    {
                        for (int j = 0; j < x; j++)
                        {

                            // Posición de cada alien
                            Vector2 posicion = new Vector2(origen.x + (espacioH * j), origen.y + (espacioV * i));

                            // Instanciamos el objeto partiendo del prefab
                            Rigidbody2D alien1 = (Rigidbody2D)Instantiate(alien, posicion, transform.rotation);

                            // Guardamos el alien en el array
                            aliens[i, j] = alien1;

                            // Escala opcional, por defecto 1.0f (sin escala)
                            // Nota: El prefab original ya está escalado a 0.2f
                            alien.transform.localScale = new Vector2(0.2f * escala, 0.2f * escala);
                        }
                    }
                }
            }
    public void activar() {
        // Rejilla de 4x7 aliens
        generarAliens(y, x, 1.5f, 1.0f);
    }

        }

            
		

	


