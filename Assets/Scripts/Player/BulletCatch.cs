using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCatch : MonoBehaviour
{
    public List<GameObject> bulletsInRange = new List<GameObject>();

    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetButtonDown(("Fire2")))
        {
            Catch();
        }
        else if(Input.GetButtonDown("Fire1"))
        {
            Throw();
        }
    }
    void Catch()
    {
        foreach (var bullet in bulletsInRange)
        {
            var rb = bullet.GetComponent<Rigidbody2D>();

            rb.velocity = Vector3.zero;
            rb.isKinematic = true;
            bullet.transform.parent = transform;
        }
    }
    void Throw()
    {
        float fireDelay = 0;

        foreach (var bullet in bulletsInRange)
        {
            var _bullet = bullet.GetComponent<Bullet>();

            //dont fire all bullet at the same time
            StartCoroutine(FireDelay(_bullet, fireDelay));
            //TODO MAKE VARIABLE
            fireDelay += .1f;
        }
    }
    IEnumerator FireDelay(Bullet bullet,float delay)
    {
        yield return new WaitForSeconds(delay);
       
        //detach from parent and eable physics
        var rb = bullet.GetComponent<Rigidbody2D>();
        rb.isKinematic = false;
        bullet.transform.parent = null;

        //vector towards mouse
        bullet.Fire(-(transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition)).normalized);

    }
}
