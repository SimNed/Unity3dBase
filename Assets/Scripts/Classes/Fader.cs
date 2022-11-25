using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

public class Fader : MonoBehaviour
{
    [field: SerializeField] private float FadeSpeed { get; set; }
    [field: SerializeField] private CanvasGroup CanvasGroup { get; set; }
    
    public IEnumerator FadeInAndOut(Action action)
    {
        while(CanvasGroup.alpha < 1)
        {
            CanvasGroup.alpha += (FadeSpeed * Time.deltaTime);
            yield return null;
        }

        action();

        StartCoroutine(FadeOut());
    }

    public IEnumerator FadeOut()
    {
        while(CanvasGroup.alpha > 0)
        {
            CanvasGroup.alpha -= (FadeSpeed * Time.deltaTime);
            yield return null;
        }   
    }
}