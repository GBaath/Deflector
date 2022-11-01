using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchAura : MonoBehaviour
{
    [SerializeField] private BulletCatch catchScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            catchScript.bulletsInRange.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            catchScript.bulletsInRange.Remove(collision.gameObject);
        }
    }
}
