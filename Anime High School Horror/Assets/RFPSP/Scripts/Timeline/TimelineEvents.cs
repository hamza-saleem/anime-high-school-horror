using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimelineEvents : MonoBehaviour
{
    public GameObject CutsceneCamera;
    public GameObject Vcams;
    [Space(10
        )]
    public UnityEvent OnTimelineStart;
    [Space(10)]
    public UnityEvent OnTimelineEnd;

    private void OnEnable()
    {
        if(OnTimelineStart!=null)
        {
            OnTimelineStart.Invoke();
        }
    }

    private void OnDisable()
    {
        if(OnTimelineEnd!=null)
        {
            OnTimelineEnd.Invoke();
        }
    }
}
