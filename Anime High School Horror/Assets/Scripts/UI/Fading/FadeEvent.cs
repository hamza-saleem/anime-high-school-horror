using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FadeEvent : MonoBehaviour
{
    public UnityEvent FadeIn;
    public UnityEvent FadeOut;
    private void OnEnable()
    {
        if(FadeIn!=null)
        {
            FadeIn.Invoke();
        }
    }

    private void OnDisable()
    {
        if (FadeOut != null)
        {
            FadeOut.Invoke();
        }
    }
}
