using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyAnimation enemyAnim;
    public AudioPlayer audioPlay;
    public GameObject bullet;
    public GameObject coin;
    Rigidbody2D rgbd;
    public float fireRate = 1;
    public float walkStep = 1;
    public float walkDistMult = 1;
    public int scoreOnKill = 100;
    public Transform playerPos;

    [SerializeField] GameObject deathObject, spawningObject;

    void Start()
    {
        playerPos = GameManager.Instance.player.transform;
        rgbd = GetComponent<Rigidbody2D>();

        Instantiate(spawningObject, transform.position, Quaternion.identity);
        Invoke(methodName: "FireBullet", Random.Range(fireRate, fireRate + 1));
        Invoke(methodName: "Walk", Random.Range(fireRate, fireRate + 1));
    }

    public void FireBullet()
    {
        audioPlay.PlayAudio(1, 1);
        enemyAnim.ShootAnim();
        var _bullet = Instantiate(bullet, transform.position, Quaternion.identity);
        _bullet.GetComponent<Bullet>().direction = -(transform.position-playerPos.position).normalized;

        Invoke(methodName: "FireBullet", Random.Range(fireRate, fireRate + 1));
    }

    public void Walk()
    {
        audioPlay.PlayAudio(0, 1);
        enemyAnim.MoveAnim();
        Vector2 walkDir = (playerPos.position - transform.position).normalized;
        walkDir = new Vector2(Random.Range(walkDir.x - 0.5f, walkDir.x + 0.5f), Random.Range(walkDir.y - 0.5f, walkDir.y + 0.5f))*walkDistMult;

        rgbd.velocity = walkDir;
        Invoke(methodName: "Walk", Random.Range(walkStep, walkStep + 1));
    }

    public void Die()
    {
        CancelInvoke();
        Instantiate(coin, transform.position, Quaternion.identity);
        GameManager.Instance.GetComponent<WaveSpawner>().RemoveEnemy(gameObject);
        GameManager.Instance.AddScore(scoreOnKill);
        var death = Instantiate(deathObject, transform.position, Quaternion.identity);
        death.GetComponentInChildren<FloatingNumber>().nrToShow = scoreOnKill;
        GameObject.Destroy(gameObject);
    }
}
