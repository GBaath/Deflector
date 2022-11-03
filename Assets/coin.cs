using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{

    void Start()
    {
        Destroy(gameObject, Random.Range(9f, 10f));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);

            FindObjectOfType<GameManager>().AddScore(150);
        }


    }

}
