using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject player;

    [SerializeField] TextMeshProUGUI scoreText, waveText;

    public int score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            player = FindObjectOfType<PlayerMove>().gameObject;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int score)
    {
        this.score += score;
        scoreText.text = "Score: " + this.score.ToString();
    }
    public void SetWaveNr(int waveNr)
    {
        waveText.text = "Wave: " + waveNr.ToString();
    }
}
