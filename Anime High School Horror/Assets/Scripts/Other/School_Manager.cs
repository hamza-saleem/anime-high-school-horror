using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class School_Manager : MonoBehaviour
{
    #region Singleton
    private static School_Manager _Instance;
    public static School_Manager Instance
    {
        get
        {

            if (!_Instance) _Instance = FindObjectOfType<School_Manager>();

            return _Instance;
        }
    }


    public GameObject Population;
    private void Awake()
    {
        if (!_Instance) _Instance = this;

    }
    #endregion


    public void Active_Population(bool isActive) 
    {
        Population.SetActive(isActive);
    }

    public void Active_School(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public void Change_Pos(Transform Pos)
    {
        transform.position = Pos.position;
        transform.rotation = Pos.rotation;
        transform.localScale = Pos.localScale;
    }
}
