using UnityEngine;
using UnityEngine.InputSystem;

public class ControlNave : MonoBehaviour
{
    // Velocidad a la que se desplaza la nave (medido en u/s)
    private readonly float velocidad = 20f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Calculamos la anchura visible de la cámara en pantalla
        float distanciaHorizontal = Camera.main.orthographicSize * Screen.width / Screen.height;

        // Calculamos el límite izquierdo y el derecho de la pantalla
        float limiteIzq = -1.0f * distanciaHorizontal;
        float limiteDer = 1.0f * distanciaHorizontal;

        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        // Tecla: Izquierda
        if (keyboard.leftArrowKey.isPressed)
        {
            // Nos movemos a la izquierda hasta llegar al límite para entrar por el otro lado
            if (transform.position.x > limiteIzq)
            {
                transform.Translate(Vector2.left * velocidad * Time.deltaTime);
            }
            else
            {
                transform.position = new Vector2(limiteDer, transform.position.y);
            }
        }

        // Tecla: Derecha
        if (keyboard.rightArrowKey.isPressed)
        {
            // Nos movemos a la derecha hasta llegar al límite para entrar por el otro lado
            if (transform.position.x < limiteDer)
            {
                transform.Translate(Vector2.right * velocidad * Time.deltaTime);
            }
            else
            {
                transform.position = new Vector2(limiteIzq, transform.position.y);
            }
        }

        // Disparo
        if (keyboard.spaceKey.wasPressedThisFrame)
        {
            disparar();
        }
    }

    void disparar()
    {
        Debug.Log("¡Boom!");
    }

}
