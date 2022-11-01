using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyAnimation enemyAnim;
    public GameObject bullet;
    Rigidbody2D rgbd;
    public float fireRate = 1;
    public float walkStep = 1;
    public float walkDistMult = 1;
    public Transform playerPos;

    void Start()
    {
        playerPos = GameManager.instance.player.transform;
        rgbd = GetComponent<Rigidbody2D>();

        Invoke(methodName: "FireBullet", Random.Range(fireRate, fireRate + 1));
        Invoke(methodName: "Walk", Random.Range(fireRate, fireRate + 1));
    }

    public void FireBullet()
    {
        enemyAnim.ShootAnim();
        var _bullet = Instantiate(bullet, transform.position, Quaternion.identity);
        _bullet.GetComponent<Bullet>().direction = -(transform.position-playerPos.position).normalized;

        Invoke(methodName: "FireBullet", Random.Range(fireRate, fireRate + 1));
    }

    public void Walk()
    {
        enemyAnim.MoveAnim();
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
