using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    [SerializeField] private Slider hpSlider;
    public int hp, maxHp;
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
        }
    }
    public void TakeDamage(int dmg)
    {
        SetHp(hp - dmg);
    }
}
