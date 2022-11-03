using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingNumber : MonoBehaviour
{
    [HideInInspector] public float nrToShow;
    [SerializeField]private Text numbersText;
    public float fadeTime =  0.5f;
    private Color startColor;
    // Start is called before the first frame update
    void Start()
    {
        numbersText.text = nrToShow.ToString();
        startColor = numbersText.color;
        StartCoroutine(FadeOut(Color.clear, fadeTime));
        //Destroy(gameObject,fadeTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //numbersText.color = Color.Lerp(startColor, Color.clear, fadeTime);
        numbersText.rectTransform.position = new Vector3(numbersText.rectTransform.position.x, numbersText.rectTransform.position.y + 0.02f, numbersText.rectTransform.position.z);
        //Debug.Log(numbersText.color);
    }
    IEnumerator FadeOut(Color endValue, float duration)
    {
        float time = 0;
        Color startValue = numbersText.color;

        while (time < duration)
        {
            numbersText.color = Color.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        numbersText.color = endValue;
    }
}
