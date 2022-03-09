﻿using UnityEngine;
using System.Collections;

public class GeneradorAliens : MonoBehaviour
{

    // Publicamos la variable para conectarla desde el editor
    public Rigidbody2D prefabAlien1;

    // Use this for initialization
    void Start()
    {
        // Rejilla de 4x7 aliens
        generarAliens(4, 7, 1.5f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void generarAliens(int filas, int columnas, float espacioH, float espacioV, float escala = 1.0f)
    {
        /* Creamos una rejilla de aliens a partir del punto de origen
		 * 
		 * Ejemplo (2,5):
		 *   A A A A A
		 *   A A O A A
		 */

        // Calculamos el punto de origen de la rejilla
        Vector2 origen = new Vector2(transform.position.x - (columnas / 2.0f) * espacioH + (espacioH / 2), transform.position.y);

        // Generamos los objetos
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                // Posición de cada alien
                Vector2 posicion = new Vector2(origen.x + (espacioH * j), origen.y + (espacioV * i));

                // Instanciamos el objeto partiendo del prefab
                Rigidbody2D alien = (Rigidbody2D)Instantiate(prefabAlien1, posicion, transform.rotation);

                // Escala opcional, por defecto 1.0f (sin escala)
                // Nota: El prefab original ya está escalado a 0.2f
                alien.transform.localScale = new Vector2(0.2f * escala, 0.2f * escala);
            }
        }

    }

}
