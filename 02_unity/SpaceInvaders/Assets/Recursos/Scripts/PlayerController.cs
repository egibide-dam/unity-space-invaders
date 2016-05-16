using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class armamento
{
    public GameObject laser, slaser, mina, bala;
}

public class PlayerController : MonoBehaviour
{

    void Start()
    {
        //inicializar el rigidbody
        rb = GetComponent<Rigidbody>();
        armamento = 1;

    }


    public float speed;
    public float tilt;
    public Boundary boundary;
    private Rigidbody rb;

    //Tipos de armas
    public GameObject laser;
    public GameObject slaser;
    public GameObject shot;
    public GameObject mine;
    public GameObject shocker;
    private float fuerza;
    private GameObject munition;


    public Transform disparador;
    private float cadencia;
    private int armamento;
    private float nextFire;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + cadencia;
            Instantiate(shot, disparador.position, disparador.rotation);
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
    }

    void OnCollisionEnter2D(Collision coll)
    {
        // Detectar la colisión entre el alien y otros elementos

        // si es una mejora
        if (coll.gameObject.tag == "mejora")
        {

            switch (coll.gameObject.name)
            {
                case "reparar":
                    break;
                case "escudo":
                    break;
                case "vida":
                    break;
                case "velocidad":
                    break;
                case "mejora":
                    break;
                default:
                    break;
            }
            
        }
        if (coll.gameObject.tag == "disparoen")
        {

        }


    }
}

// --------------------------------version 2d algo se rompio asi q transforme el juego en 3d con vista ortogonal----------------------------
/*  

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector2
        (
            Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(GetComponent<Rigidbody>().position.y, boundary.yMin, boundary.yMax)
        );

        rb.rotation = Quaternion.Euler(270.0f, 0.0f, rb.velocity.x * -tilt);
    }
*/
