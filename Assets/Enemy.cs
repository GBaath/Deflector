using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject bullet;
    Rigidbody2D rgbd;
    public float fireRate = 1;
    public float walkStep = 1;
    public float walkDistMult = 1;
    public Transform playerPos;
    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();

        Invoke(methodName: "FireBullet", Random.Range(fireRate, fireRate + 1));
        Invoke(methodName: "Walk", Random.Range(fireRate, fireRate + 1));
    }

    public void FireBullet()
    {
        Debug.Log("Fired");
        Instantiate(bullet, gameObject.transform);
        Invoke(methodName: "FireBullet", Random.Range(fireRate, fireRate + 1));
    }

    public void Walk()
    {
        Debug.Log("Walked");
        Vector2 walkDir = (playerPos.position - transform.position).normalized;
        walkDir = new Vector2(Random.Range(walkDir.x - 0.5f, walkDir.x + 0.5f), Random.Range(walkDir.y - 0.5f, walkDir.y + 0.5f))*walkDistMult;

        rgbd.velocity = walkDir;
        Invoke(methodName: "Walk", Random.Range(walkStep, walkStep + 1));
    }

    public void Die()
    {
        CancelInvoke();
        GameObject.Destroy(gameObject);
    }
}
