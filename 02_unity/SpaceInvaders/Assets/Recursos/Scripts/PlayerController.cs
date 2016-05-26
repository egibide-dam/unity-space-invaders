using UnityEngine;
using System.Collections;


[System.Serializable]
public class Boundary
{
    public float xMin = -13;
    public float xMax = 13;

    public float zMin = -7;
    public float zMax = 7;
}


public class PlayerController : MonoBehaviour
{


    void Start()
    {
        //inicializar el rigidbody
        rb = GetComponent<Rigidbody>();
        munition = laser;

    }


    public float speed = 15;
    public float tilt = 3;
    public Boundary boundary;
    private Rigidbody rb;
    private GameObject munition;
    //Tipos de armas
    public GameObject laser;
    public GameObject slaser;
    public GameObject flame;
    public GameObject mine;

    private Rigidbody llama;
    public Transform disparador;
    private float cadencia = 0.5f;
    private int armamento = 1;
    private float nextFire = 1;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {

            switch (armamento)
            {
                case 1:
                    nextFire = Time.time + cadencia;
                    Instantiate(munition, disparador.position, disparador.rotation);
                    GetComponent<AudioSource>().Play();
                    break;
                case 2:
                    nextFire = Time.time + cadencia;
                    Instantiate(munition, disparador.position, disparador.rotation);
                    GetComponent<AudioSource>().Play();
                    break;
                case 3:
                    nextFire = Time.time + cadencia;
                    llama = (Rigidbody) Instantiate(munition, disparador.position, disparador.rotation);
                    GetComponent<AudioSource>().Play();
                    break;
                case 4:
                    nextFire = Time.time + cadencia;
                    Instantiate(munition, disparador.position, disparador.rotation);
                    GetComponent<AudioSource>().Play();
                    break;
                case 5:
                    nextFire = Time.time + cadencia;
                    Instantiate(munition, disparador.position, disparador.rotation);
                    GetComponent<AudioSource>().Play();
                    break;
                default:
                    break;
            }
            
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            if (armamento == 1)
            {
                        munition = slaser;
                        armamento = 2;
                        cadencia = 0.7f;

            }else{

                    munition = laser;
                    armamento = 1;
                    cadencia = 0.5f;

            }

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
                case "boost":
                    break;
                default:
                    break;
            }
            
        }
        if (coll.gameObject.tag == "disparoen")
        {
            switch (coll.gameObject.name)
            {
                case "light":
                    break;
                case "normal":
                    break;
                case "heavy":
                    break;
                default:
                    break;
            }
        }

        if (coll.gameObject.tag == "arma")
        {
            switch (coll.gameObject.name)
            {
                case "laser":
                    munition = laser;
                    armamento = 1;
                    cadencia = 1;
                    break;
                case "slaser":
                    munition = slaser;
                    armamento = 2;
                    cadencia = 1.5f;
                    break;
                case "flame":
                    munition = flame;
                    armamento = 3;
                    cadencia = 11;
                    break;
                case "mine":
                    munition = mine;
                    armamento = 4;
                    cadencia = 2;
                    break;
               
                default:
                    break;
            }
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
