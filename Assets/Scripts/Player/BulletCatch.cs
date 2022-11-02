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

    [SerializeField] private ParticleSystem magicParticles;

    public float dragValue = 0;

    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetButtonDown(("Fire2")))
        {
            catchBuffer = true;
            StartCoroutine(VarChange(result => catchBuffer = result, catchBufferTime, false));
            magicParticles.Stop();
            magicParticles.Play();
            
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
                bullet.transform.parent = bulletParent;
                rb.drag = dragValue;
                StartCoroutine(VarChange(result => rb.isKinematic = result, .25f, true));

                //no collision while carried
               // bullet.GetComponent<Collider2D>().enabled = false;

                //player takes no damage from own
                _bullet.isplayerOwened = true;
                carriedBullets.Add(bullet);

                //new rotatin when carried
                _bullet.GetComponentInChildren<RotationLocker>().lockedRotation = Quaternion.LookRotation(Vector3.forward,Vector3.right);

                //switch animations
                bullet.transform.GetChild(0).gameObject.SetActive(true);
                bullet.transform.GetChild(1).gameObject.SetActive(false);
            }
        }
    }
    void Throw()
    {
        magicParticles.Stop();
        magicParticles.Play();
        float fireDelay = 0;

        foreach (var bullet in carriedBullets)
        {
            var _bullet = bullet.GetComponent<Bullet>();
            var rb = bullet.GetComponent<Rigidbody2D>();

            //physics back online
            rb.isKinematic = false;
            rb.drag = 0;

            //dont fire all bullet at the same time
            StartCoroutine(FireDelay(_bullet, fireDelay));
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
        bullet.GetComponentInChildren<RotationLocker>().enabled = false;
        bullet.Fire(-(bullet.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition)).normalized);
        bullet.fired = true;
        carriedBullets.Remove(bullet.gameObject);

    }
    IEnumerator VarChange(System.Action<bool> boolVar, float cooldown, bool endValue)
    {
        yield return new WaitForSeconds(cooldown);
        boolVar(endValue);
    }

}
