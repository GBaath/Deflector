using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    [SerializeField] private Slider hpSlider;
    public int hp, maxHp;
    [SerializeField] AudioPlayer audioPlayer;

    [SerializeField] GameObject gameoverObject, deathObject;
    private void Start()
    {
        hpSlider.maxValue = maxHp;
        hpSlider.value = maxHp;
        hp = maxHp;
    }

    void SetHp(int hp)
    {
        hpSlider.value = hp;
        this.hp = hp;
        if (hp <= 0)
        {
            //GAMEOVER
            gameoverObject.SetActive(true);
            Instantiate(deathObject, transform.position, Quaternion.identity);
            audioPlayer.PlayAudio(2);
            GetComponentInParent<PlayerRotation>().enabled = false;
            GetComponentInParent<SpriteRenderer>().enabled = false;
            GetComponentInParent<PlayerMove>().enabled = false;
            GetComponentInParent<BulletCatch>().enabled = false;
            Camera.main.GetComponent<AudioSource>().enabled = false;
            FindObjectOfType<Menu>().scoreText.text = "Score: " +GameManager.Instance.score.ToString();
            foreach (var enemy in GameManager.Instance.GetComponent<WaveSpawner>().currentEnemies)
            {
                enemy.GetComponent<Enemy>().CancelInvoke();
                enemy.GetComponent<Enemy>().enabled = false;
            }
        }
    }
    public void TakeDamage(int dmg)
    {
        SetHp(hp - dmg);
        audioPlayer.PlayAudio(1);
    }
}
