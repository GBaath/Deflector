using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 1;
    private Vector2 move;
    private Vector2 automove;
    private float moveX, moveY;
    private Rigidbody2D rb;
    [SerializeField] ParticleSystem runParticles;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveY = Input.GetAxis("Vertical");
        moveX = Input.GetAxis("Horizontal");

        move = moveX * Vector3.right + moveY * Vector3.up;

        if (Input.GetButton("Horizontal"))
        {
            if (moveX < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                runParticles.transform.localEulerAngles = new Vector3(0, 180, 0);
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
                runParticles.transform.localEulerAngles = new Vector3(0, 0, 0);
            }
        }
        if(move != Vector2.zero)
        {
            //runParticles.gameObject.SetActive(true);
            runParticles.enableEmission = true;
        }
        else
        {
            runParticles.enableEmission = false;
            //runParticles.gameObject.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = move * speed + automove;
    }

    private IEnumerator LerpAutomove(Vector2 startValue, Vector2 endVal, float duration)
    {
        float time = 0;
        while (time < duration)
        {
            automove = Vector2.Lerp(startValue, endVal, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        automove = endVal;
    }
    IEnumerator VarChange(System.Action<bool> boolVar, float cooldown, bool endValue)
    {
        yield return new WaitForSeconds(cooldown);
        boolVar(endValue);
    }
}
