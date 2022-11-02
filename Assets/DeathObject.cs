using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathObject : MonoBehaviour
{
    private SpriteRenderer spriteToFade;

    void Start()
    {
        spriteToFade = gameObject.GetComponentInChildren<SpriteRenderer>();
        Invoke(nameof(FadeOut), 3f);
    }
    void FadeOut()
    {
        StartCoroutine(LerpFunction(Color.clear, 5));

    }
    IEnumerator LerpFunction(Color endValue, float duration)
    {
        float time = 0;
        Color startValue = spriteToFade.color;
        while (time < duration)
        {
            spriteToFade.color = Color.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        spriteToFade.color = endValue;
        Destroy(gameObject);
    }
}
