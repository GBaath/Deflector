using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCatch : MonoBehaviour
{
    public List<GameObject> bulletsInRange = new List<GameObject>();
    public List<GameObject> carriedBullets = new List<GameObject>();
    private bool catchBuffer;
    [SerializeField] private float catchBufferTime = .5f;
    [SerializeField] private Transform bulletParent;

    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetButtonDown(("Fire2")))
        {
            catchBuffer = true;
            StartCoroutine(VarChange(result => catchBuffer = result, catchBufferTime, false));
        }
        else if(Input.GetButtonDown("Fire1"))
        {
            Throw();
        }

        if (catchBuffer)
        {
            Catch();
        }
    }
    void Catch()
    {
        foreach (var bullet in bulletsInRange)
        {
            if (!bullet.GetComponent<Bullet>().isplayerOwened)
            {
                var rb = bullet.GetComponent<Rigidbody2D>();
                var _bullet = bullet.GetComponent<Bullet>();

                //stop movement and physics
                _bullet.isplayerOwened = true;
               // rb.velocity = Vector3.zero;
                //rb.isKinematic = true;
                //for rotation
                bullet.transform.parent = bulletParent;
                carriedBullets.Add(bullet);

                rb.drag = 50;
                StartCoroutine(VarChange(result => rb.isKinematic = result, .5f, true));

            }
        }
    }
    void Throw()
    {
        float fireDelay = 0;

        foreach (var bullet in carriedBullets)
        {
            var _bullet = bullet.GetComponent<Bullet>();
            var rb = bullet.GetComponent<Rigidbody2D>();
            rb.isKinematic = false;
            rb.drag = 0;

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
        carriedBullets.Remove(bullet.gameObject);

    }
    IEnumerator VarChange(System.Action<bool> boolVar, float cooldown, bool endValue)
    {
        yield return new WaitForSeconds(cooldown);
        boolVar(endValue);
    }

}
