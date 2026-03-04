using UnityEngine;
using UnityEngine.InputSystem;

public class ControlCamara : MonoBehaviour
{
    // Referencia al objeto en la escena
    private GameObject alien;

    // Velocidad a la que se desplaza el alien
    private readonly float velocidad = 20f;

    // Use this for initialization
    void Start()
    {
        // Conectamos con la instancia que hemos creado en el editor
        alien = GameObject.Find("Alien1");
    }

    // Update is called once per frame
    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        // Tecla: Izquierda
        if (keyboard.leftArrowKey.isPressed)
        {
            alien.transform.Translate(Time.deltaTime * velocidad * Vector2.left);
        }

        // Tecla: Derecha
        if (keyboard.rightArrowKey.isPressed)
        {
            alien.transform.Translate(Time.deltaTime * velocidad * Vector2.right);
        }
    }
}
