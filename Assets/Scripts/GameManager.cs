using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public GameObject player;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            player = FindObjectOfType<PlayerMove>().gameObject;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
