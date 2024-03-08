using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFader : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] AnimationCurve curve;

    private void Start()
    {
        StartCoroutine(FadeOut());
    }

    public void FadeOn(int indexToFadeTo)
    {
        StartCoroutine(FadeIn(indexToFadeTo));
            
        Debug.Log("Fade on was called");
    }

    IEnumerator FadeOut()
    {
        float t = 1;
        while(t > 0)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);

            image.color = new Color(0, 0, 0, a);
            yield return 0;
        }
    }

    IEnumerator FadeIn(int indexToFadeTo)
    {
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);

            image.color = new Color(0, 0, 0, a);
            yield return 0;
        }

        SceneManager.LoadScene(indexToFadeTo);
        Debug.Log("finished fading");
    }
}
