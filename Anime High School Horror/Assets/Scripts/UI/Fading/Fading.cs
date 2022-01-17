using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fading : MonoBehaviour
{
    #region Singleton
    private static Fading _Instance;
    public static Fading instance
    {
        get
        {

            if (!_Instance) _Instance = FindObjectOfType<Fading>();

            return _Instance;
        }
    }

    private void Awake()
    {

        if (!_Instance)
            _Instance = this;

        //  Fader = GetComponent<CanvasGroup>();
    }
    #endregion
    #region Variables
    public bool InitFromGameManager = true;
    public CanvasGroup Fader;
    public UnityEvent OnFadeEnd;
    public bool FadeOutOnLoad = false;
    #endregion


    void Start()
    {
        if (!InitFromGameManager)
            Init();
    }

    void Init()
    {
        if (FadeOutOnLoad)
        {
            DoFading(FadingMode.FadeOut, 1);
        }
    }

    public void DoFadingDo()
    {
        DoFading(FadingMode.FadeOut, 1);
    }

    public void DoFading(FadingMode Mode, float Speed, float wait = 1f)
    {
        StopAllCoroutines();

        StartCoroutine(FadingNumerator(Mode, Speed, wait));
    }

    IEnumerator FadingNumerator(FadingMode Mode, float Speed, float wait = 1f)
    {
        Fader.blocksRaycasts = true;

        if (Mode.Equals(FadingMode.FadeOut))
        {
            Fader.alpha = 1;
        }
        else
        {
            Fader.alpha = 0;
        }


        Fader.gameObject.SetActive(true);


        yield return new WaitForSeconds(wait);

        float mode = (float)((int)Mode);


        while (!Mathf.Approximately(Fader.alpha, mode))
        {
            Fader.alpha = Mathf.MoveTowards(Fader.alpha, mode, Time.deltaTime * Speed);
            yield return null;
        }

        Fader.alpha = mode;


        Fader.blocksRaycasts = false;



        if (OnFadeEnd != null)
        {
            OnFadeEnd.Invoke();
        }

    }


    public enum FadingMode
    {
        FadeOut,
        FadeIn
    }
}

