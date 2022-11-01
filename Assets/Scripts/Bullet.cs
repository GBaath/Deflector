using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;
    public float speed;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Fire();
    }
    public void Fire()
    {
        rb.velocity = direction * speed;

    }
    public void Fire(Vector3 direction)
    {
        rb.velocity = direction * speed;

    }
}
