using UnityEngine;
using System.Collections;

public class ControlAlien : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

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

            // El disparo desaparece (cuidado, si tiene eventos no se ejecutan)
            Destroy(coll.gameObject);

            // El alien desaparece
            Destroy(gameObject);
        }
    }
}
