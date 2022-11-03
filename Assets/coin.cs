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
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<AudioPlayer>().PlayAudio(0);
            Destroy(gameObject,2f);
            transform.GetChild(0).gameObject.SetActive(true);

            GetComponentInChildren<FloatingNumber>().nrToShow = 150;
            FindObjectOfType<GameManager>().AddScore(150);

        }


    }

}
