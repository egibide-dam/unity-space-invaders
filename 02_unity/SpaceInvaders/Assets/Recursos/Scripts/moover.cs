using UnityEngine;
using System.Collections;

public class moover : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 2;

    void Start()
    {
        rb.velocity = transform.forward * speed;
    }
}