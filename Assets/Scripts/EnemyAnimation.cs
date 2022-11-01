using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public Animator enemyAnim;

    public void ShootAnim()
    {
        enemyAnim.SetTrigger("Shoot");
    }

    public void MoveAnim()
    {
        enemyAnim.SetTrigger("Move");
    }
}
