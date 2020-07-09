using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class Fader : MonoBehaviour
{
    CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    
    public IEnumerator FadeTo(float target, float time)
    {
        while (!Mathf.Approximately(canvasGroup.alpha, target))
        {
            canvasGroup.alpha = Mathf.MoveTowards(canvasGroup.alpha, target, Time.deltaTime / time);
            yield return new WaitForEndOfFrame();
        }
    }
    
    public void FadeIn()
    {
        StartCoroutine(FadeTo(0f, 2f));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeTo(1f, 2f));
    }
    private void Start()
    {
        canvasGroup.alpha = 1;
        FadeIn();
    }
}
