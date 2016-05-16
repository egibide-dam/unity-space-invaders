using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 90;

    void Start()
    {
        rb.velocity = transform.forward * speed;
    }
}