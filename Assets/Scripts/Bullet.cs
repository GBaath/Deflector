using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public bool isplayerOwened,fired;

    private Rigidbody2D rb;

    [SerializeField] GameObject explosion;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Fire();
    }
    public void Fire()
    {
        rb.velocity = direction * speed;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, rb.velocity.normalized);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z + 90);
    }
    public void Fire(Vector2 direction)
    {
        rb.velocity = direction.normalized * speed;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, rb.velocity.normalized);
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z + 90);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")&&isplayerOwened&&fired)
        {
            collision.GetComponent<EnemyHp>().TakeDamage(1);
            Destroy(gameObject);
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
        else if(collision.CompareTag("Player") &!isplayerOwened)
        {
            collision.GetComponent<PlayerHp>().TakeDamage(1);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Obstacle"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
