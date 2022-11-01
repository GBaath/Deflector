using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public bool isplayerOwened;

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
    public void Fire(Vector2 direction)
    {
        rb.velocity = direction.normalized * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")&&isplayerOwened)
        {
            collision.GetComponent<EnemyHp>().TakeDamage(1);
        }
    }
}
